namespace AtolOnline.Unofficial;

/// <summary>
/// Клиент для отправки чеков
/// </summary>
public class AtolClient
{

    private readonly HttpClient _httpClient;
    private readonly string? _baseAddress;
    private readonly bool _v4;
    private readonly AtolSerializer _serializer;

    /// <summary>
    ///  Конструктор, параметры, переданные "по умолчанию" могут быть опущены, или переопределены в соотвествующих методах
    /// </summary>
    /// <param name="httpClient">Клиетн для выполнения запросов</param>
    /// <param name="baseAddress">Базовый адрес сервера
    /// <para>
    /// По умолчанию <value>https://online.atol.ru/possystem/v5</value>
    /// </para>
    /// </param>
    /// <param name="v4">Признак использования V4 ФФД 1.05
    /// <para>
    /// По умолчанию определяется из <paramref name="baseAddress"/>
    /// </para>
    /// </param>
    public AtolClient(
        HttpClient httpClient,
        string? baseAddress = "https://online.atol.ru/possystem/v5",
        bool? v4 = null
        )
    {
        _httpClient = httpClient;
        if (string.IsNullOrEmpty(baseAddress))
            baseAddress = "https://online.atol.ru/possystem/v5";

        if (baseAddress != null)
        {
            _baseAddress = baseAddress.TrimEnd('/');
            _v4 = baseAddress.Contains("/v4");
        }
        else
        {
            _v4 = _httpClient.BaseAddress?.LocalPath?.Contains("/v4") ?? false;
        }
        if (v4.HasValue)
        {
            _v4 = v4.Value;
        }

        _serializer = _v4 
            ? AtolSerializer.V4 
            : AtolSerializer.V5;
    }

    private string Serialize(object obj)
        => _serializer.Serialize(obj);

    private T Deserialize<T>(string json)
        => _serializer.Deserialize<T>(json);

    private StringContent Content(object obj)
        => new StringContent(Serialize(obj),
            System.Text.Encoding.UTF8,
            "application/json");

    private Task<T> ReadAsync<T>(HttpResponseMessage response)
        where T : ResponseBase
        => ReadAsync<T, ResponseBase>(response);

    private async Task<T> ReadAsync<T, Ex>(HttpResponseMessage response)
        where T : ResponseBase
        where Ex : ResponseBase
    {
        var text = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            if (!string.IsNullOrEmpty(text))
                throw new AtolClientException(Deserialize<Ex>(text), response.StatusCode);

            throw new AtolClientException(text, response.StatusCode);
        }

        var res = Deserialize<T>(text);

        if (res.Error != null)
        {
            throw new AtolClientException(res, response.StatusCode);
        }

        return res;
    }

    private string GetUrl(string part)
        => _baseAddress == null
            ? part
            : _baseAddress + "/" + part;


    /// <summary>
    /// Получение токена авторизации, после вызова метода токен сохраняется и будет использован как токен для авторизации по умолчанию
    /// </summary>
    /// <param name="login">Логин, если не передан используется значение, переданное в конструктор</param>
    /// <param name="password">Пороль, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="source">Название интегратора (необязательный параметр). Наименование интегратора через которого осуществляется отправка запросов.Максимальная длина строки – 100 символов, если не передан, используется значение, переданное в конструктор</param>
    /// <returns><see cref="TokenResponse"/></returns>
    public async Task<TokenResponse> GetTokenAsync(string login, string password, string? source = null)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, GetUrl("getToken"));
        httpRequest.Content = Content(new
        {
            Login = login,
            Pass = password,
            Source = source
        });

        using var resp = await _httpClient.SendAsync(httpRequest);
        var data = await ReadAsync<TokenResponse>(resp);

        return data;
    }

    private async Task<OperationResponse> ExecOperationAsync<T>(string operation, string groupCode, string token, T request)
        where T : class
    {
        if (string.IsNullOrEmpty(token))
            throw new AtolClientException("Call GetToken or provide token from constructor");

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, GetUrl($"{groupCode}/{operation}"));

        httpRequest.Content = Content(request);
        httpRequest.Headers.Add("Token", token);

        using var resp = await _httpClient.SendAsync(httpRequest);
        return await ReadAsync<OperationResponse>(resp);
    }

    /// <summary>
    /// Регистрация документа
    /// </summary>
    /// <param name="operation">тип операции на регистрацию чека, которая должна быть выполнена</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public Task<OperationResponse> OperationAsync(string operation, ReceiptRequest request, string groupCode, string token)
        => ExecOperationAsync(operation, groupCode, token, request);


    /// <summary>
    /// Коррекция документа
    /// </summary>
    /// <param name="operation">тип операции на регистрацию чека, которая должна быть выполнена</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public Task<OperationResponse> CorrectionAsync(string operation, CorrectionRequest request, string groupCode, string token)
        => ExecOperationAsync(operation, groupCode, token, request);


    /// <summary>
    /// Получение состояния документа
    /// </summary>
    /// <param name="uuid">Уникальный идентификатор чека, полученный прсле его отправки</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public async Task<ReportResponse> ReportAsync(string uuid, string groupCode, string token)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, GetUrl($"{groupCode}/report/{uuid}"));

        httpRequest.Headers.Add("Token", token);

        using var resp = await _httpClient.SendAsync(httpRequest);
        return await ReadAsync<ReportResponse, FailReportResponse>(resp);
    }
}
