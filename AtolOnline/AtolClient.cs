using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AtolOnline.Unofficial;

/// <summary>
/// Клиент для отправки чеков
/// </summary>
public class AtolClient
{
    static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
    {
        Converters =
        [
            new FormatDateJsonConverter.DateTime(),
        ],
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy(),
        },
        DateFormatString = "dd.MM.yyyy HH:mm",
        NullValueHandling = NullValueHandling.Ignore,
    };
    static readonly JsonSerializerSettings JsonSerializerSettingsV4 = new JsonSerializerSettings()
    {
        Converters =
        [
            new FormatDateJsonConverter.DateTime(),
        ],
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy(),
        },
        DateFormatString = "dd.MM.yyyy HH:mm",
        NullValueHandling = NullValueHandling.Ignore,
        Context = new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.All, "v4")
    };

    private readonly string? _login;
    private readonly string? _password;
    private readonly string? _groupCode;
    private readonly string? _source;
    private readonly HttpClient _httpClient;
    private readonly string? _baseAddress;
    private readonly bool _v4;

    /// <summary>
    /// Токен авторизации
    /// </summary>
    public string? Token { get; private set; }

    /// <summary>
    ///  Конструктор, параметры, переданные "по умолчанию" могут быть опущены, или переопределены в соотвествующих методах
    /// </summary>
    /// <param name="httpClient">Клиетн для выполнения запросов</param>
    /// <param name="login">Логин по умолчанию</param>
    /// <param name="password">Пароль по умолчанию</param>
    /// <param name="groupCode">Идентификатор группы ККТ по умолчанию</param>
    /// <param name="source">Название интегратора (необязательный параметр). Наименование интегратора через которого осуществляется отправка запросов.Максимальная длина строки – 100 символов</param>
    /// <param name="token">Токен авторизации по умолчанию</param>
    /// <param name="baseAddress">Базовый адрес сервера
    /// </param>
    /// <param name="v4">Признак использования V4 ФФД 1.05</param>
    public AtolClient(
        HttpClient httpClient,
        string? login = null,
        string? password = null,
        string? groupCode = null,
        string? source = null,
        string? token = null,
        string? baseAddress = "https://online.atol.ru/possystem/v5",
        bool? v4 = null
        )
    {
        _login = login;
        _password = password;
        _groupCode = groupCode;
        _source = source;
        _httpClient = httpClient;
        Token = token;
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
    }

    private string Serialize(object obj)
        => JsonConvert.SerializeObject(obj, _v4 ? JsonSerializerSettingsV4 : JsonSerializerSettings);

    private T Deserialize<T>(string json)
        => JsonConvert.DeserializeObject<T>(json, _v4 ? JsonSerializerSettingsV4 : JsonSerializerSettings)!;

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

    private static string Value(string? a, string? b, string text)
        => a ?? b ?? throw new ArgumentNullException(text);

    /// <summary>
    /// Получение токена авторизации, после вызова метода токен сохраняется и будет использован как токен для авторизации по умолчанию
    /// </summary>
    /// <param name="login">Логин, если не передан используется значение, переданное в конструктор</param>
    /// <param name="password">Пороль, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="source">Название интегратора (необязательный параметр). Наименование интегратора через которого осуществляется отправка запросов.Максимальная длина строки – 100 символов, если не передан, используется значение, переданное в конструктор</param>
    /// <returns><see cref="TokenResponse"/></returns>
    public async Task<TokenResponse> GetTokenAsync(string? login = null, string? password = null, string? source = null)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, GetUrl("getToken"));
        httpRequest.Content = Content(new
        {
            Login = Value(login, _login, nameof(login)),
            Pass = Value(password, _password, nameof(password)),
            Source = source ?? _source
        });

        using var resp = await _httpClient.SendAsync(httpRequest);
        var data = await ReadAsync<TokenResponse>(resp);

        Token = data.Token;

        return data;
    }

    private async Task<OperationResponse> ExecOperationAsync<T>(string operation, string groupCode, string? token, T request)
        where T : class
    {
        token = token ?? Token;
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
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public Task<OperationResponse> OperationAsync(string operation, ReceiptRequest request, string? groupCode = null, string? token = null)
        => ExecOperationAsync(operation, Value(groupCode, _groupCode, nameof(groupCode)), token, request);


    /// <summary>
    /// Коррекция документа
    /// </summary>
    /// <param name="operation">тип операции на регистрацию чека, которая должна быть выполнена</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public Task<OperationResponse> CorrectionAsync(string operation, CorrectionRequest request, string? groupCode = null, string? token = null)
        => ExecOperationAsync(operation, Value(groupCode, _groupCode, nameof(groupCode)), token, request);


    /// <summary>
    /// Регистрация документа: Приход
    /// <seealso cref="OperationAsync(string, ReceiptRequest, string?, string?)"/>
    /// </summary>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public Task<OperationResponse> SellAsync(ReceiptRequest request, string? groupCode = null, string? token = null)
        => OperationAsync("sell", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Возврат прихода
    /// <seealso cref="OperationAsync(string, ReceiptRequest, string?, string?)"/>
    /// </summary>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public Task<OperationResponse> SellRefundAsync(ReceiptRequest request, string? groupCode = null, string? token = null)
        => OperationAsync("sell_refund", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Расход
    /// <seealso cref="OperationAsync(string, ReceiptRequest, string?, string?)"/>
    /// </summary>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public Task<OperationResponse> Buy(ReceiptRequest request, string? groupCode = null, string? token = null)
        => OperationAsync("buy", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Возврат расхода
    /// <seealso cref="OperationAsync(string, ReceiptRequest, string?, string?)"/>
    /// </summary>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    public Task<OperationResponse> BuyRefund(ReceiptRequest request, string? groupCode = null, string? token = null)
        => OperationAsync("buy_refund", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция прихода
    /// <seealso cref="CorrectionAsync(string, CorrectionRequest, string?, string?)"/>
    /// </summary>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public Task<OperationResponse> SellCorrection(CorrectionRequest request, string? groupCode = null, string? token = null)
        => CorrectionAsync("sell_correction", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция расхода
    /// <seealso cref="CorrectionAsync(string, CorrectionRequest, string?, string?)"/>
    /// </summary>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public Task<OperationResponse> BuyCorrection(CorrectionRequest request, string? groupCode = null, string? token = null)
        => CorrectionAsync("buy_correction", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция возврата прихода
    /// <seealso cref="CorrectionAsync(string, CorrectionRequest, string?, string?)"/>
    /// </summary>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public Task<OperationResponse> SellRefundCorrection(CorrectionRequest request, string? groupCode = null, string? token = null)
        => CorrectionAsync("sell_refund_correction", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция возврата расхода
    /// <seealso cref="CorrectionAsync(string, CorrectionRequest, string?, string?)"/>
    /// </summary>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public Task<OperationResponse> BuyRefundCorrection(CorrectionRequest request, string? groupCode = null, string? token = null)
        => CorrectionAsync("buy_refund_correction", request, groupCode, token);

    /// <summary>
    /// Получение состояния документа
    /// </summary>
    /// <param name="uuid">Уникальный идентификатор чека, полученный прсле его отправки</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public async Task<ReportResponse> ReportAsync(string uuid, string? groupCode = null, string? token = null)
    {
        token = token ?? Token;
        if (string.IsNullOrEmpty(token))
            throw new AtolClientException("Call GetToken or provide token from constructor");

        var httpRequest = new HttpRequestMessage(HttpMethod.Get, GetUrl($"{Value(groupCode, _groupCode, nameof(groupCode))}/report/{uuid}"));

        httpRequest.Headers.Add("Token", token);

        using var resp = await _httpClient.SendAsync(httpRequest);
        return await ReadAsync<ReportResponse, FailReportResponse>(resp);
    }
}
