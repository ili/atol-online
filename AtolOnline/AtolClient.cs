using AtolOnline.Unofficial.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace AtolOnline.Unofficial;

public class AtolClient
{
    public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
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
    public static readonly JsonSerializerSettings JsonSerializerSettingsV4 = new JsonSerializerSettings()
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

    private readonly string _login;
    private readonly string _password;
    private readonly string _groupCode;
    private readonly string? _source;
    private readonly HttpClient _httpClient;
    private readonly string? _baseAddress;
    private readonly bool _v4;

    /// <summary>
    /// Токен авторизации
    /// </summary>
    public string? Token { get; private set; }

    /// <summary>
    ///  
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <param name="token"></param>
    public AtolClient(
        HttpClient httpClient,
        string login,
        string password,
        string groupCode,
        string? source = null,
        string? token = null,
        string? baseAddress = null,
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
            _v4 = baseAddress.Contains("/v4/");
        }
        else
        {
            _v4 = _httpClient.BaseAddress?.LocalPath?.Contains("/v4/") ?? false;
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

    private async Task<T> ReadAsync<T>(HttpResponseMessage response)
        where T : ResponseBase
    {
        var text = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            if (!string.IsNullOrEmpty(text))
                throw new AtolClientException(Deserialize<ResponseBase>(text), response.StatusCode);

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

    public async Task<GetTokenResponse> GetTokenAsync()
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, GetUrl("getToken"));
        httpRequest.Content = Content(new
        {
            Login = _login,
            Pass = _password,
            Source = _source

        });

        using var resp = await _httpClient.SendAsync(httpRequest);
        var data = await ReadAsync<GetTokenResponse>(resp);

        Token = data.Token;

        return data;
    }
    private async Task<OperationResponse> ExecOperationAsync<T>(string operation, T request)
        where T : class
    {
        if (string.IsNullOrEmpty(Token))
            throw new AtolClientException("Call GetToken or provide token from constructor");

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, GetUrl($"{_groupCode}/{operation}"));

        httpRequest.Content = Content(request);
        httpRequest.Headers.Add("Token", Token);

        using var resp = await _httpClient.SendAsync(httpRequest);
        return await ReadAsync<OperationResponse>(resp);
    }

    /// <summary>
    /// Регистрация документа
    /// </summary>
    /// <param name="operation">тип операции на регистрацию чека, которая должна быть выполнена</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public Task<OperationResponse> OperationAsync(string operation, ReceiptRequest request)
        => ExecOperationAsync(operation, request);


    /// <summary>
    /// Коррекция документа
    /// </summary>
    /// <param name="operation">тип операции на регистрацию чека, которая должна быть выполнена</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public Task<OperationResponse> CorrectionAsync(string operation, CorrectionRequest request)
        => ExecOperationAsync(operation, request);


    /// <summary>
    /// Регистрация документа: Приход
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<OperationResponse> SellAsync(ReceiptRequest request)
        => OperationAsync("sell", request);

    /// <summary>
    /// Регистрация документа: Возврат прихода
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<OperationResponse> SellRefundAsync(ReceiptRequest request)
        => OperationAsync("sell_refund", request);

    /// <summary>
    /// Регистрация документа: Расход
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<OperationResponse> Buy(ReceiptRequest request)
        => OperationAsync("buy", request);

    /// <summary>
    /// Регистрация документа: Возврат расхода
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<OperationResponse> BuyRefund(ReceiptRequest request)
        => OperationAsync("buy_refund", request);

    /// <summary>
    /// Регистрация документа: Коррекция прихода
    /// </summary>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<OperationResponse> SellCorrection(CorrectionRequest request)
        => CorrectionAsync("sell_correction", request);

    /// <summary>
    /// Регистрация документа: Коррекция расхода
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<OperationResponse> BuyCorrection(CorrectionRequest request)
        => CorrectionAsync("buy_correction", request);

    /// <summary>
    /// Регистрация документа: Коррекция возврата прихода
    /// </summary>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<OperationResponse> SellRefundCorrection(CorrectionRequest request)
        => CorrectionAsync("sell_refund_correction", request);

    /// <summary>
    /// Регистрация документа: Коррекция возврата расхода
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<OperationResponse> BuyRefundCorrection(CorrectionRequest request)
        => CorrectionAsync("buy_refund_correction", request);

}
