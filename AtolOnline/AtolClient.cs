using AtolOnline.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace AtolOnline;

public class AtolClient
{
    public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
    {
        Converters =
        [
            new StringEnumConverter() { NamingStrategy = new SnakeCaseNamingStrategy()},
            new FormatDateJsonConverter.DateTime(),
            new FormatDateJsonConverter.Date(),
        ],
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy(),
        },
        DateFormatString = "dd.MM.yyyy HH:mm",
        NullValueHandling = NullValueHandling.Ignore,
    };

    private readonly string _login;
    private readonly string _password;
    private readonly string _groupCode;
    private readonly string? _source;
    private readonly HttpClient _httpClient;
    private readonly string? _baseAddress;

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
        string? source,
        string? token,
        string? baseAddress
        )
    {
        _login = login;
        _password = password;
        _groupCode = groupCode;
        _source = source;
        _httpClient = httpClient;
        Token = token;
        if (baseAddress != null)
            _baseAddress = baseAddress.TrimEnd('/');
    }

    private static string Serialize(object obj)
        => JsonConvert.SerializeObject(obj, JsonSerializerSettings);

    private static T Deserialize<T>(string json)
        => JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings)!;

    private static StringContent Content(object obj)
        => new StringContent(Serialize(obj),
            System.Text.Encoding.UTF8,
            "application/json");

    private static async Task<T> ReadAsync<T>(HttpResponseMessage response)
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
    private async Task<ResponseBase> ExecOperationAsync<T>(string operation, T request)
        where T : class
    {
        if (string.IsNullOrEmpty(Token))
            throw new AtolClientException("Call GetToken or provide token from constructor");

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, GetUrl($"{_groupCode}/{operation}"));

        httpRequest.Content = Content(request);
        httpRequest.Headers.Add("Token", Token);

        using var resp = await _httpClient.SendAsync(httpRequest);
        return await ReadAsync<ResponseBase>(resp);
    }

    /// <summary>
    /// Регистрация документа
    /// </summary>
    /// <param name="operation">тип операции на регистрацию чека, которая должна быть выполнена</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public Task<ResponseBase> OperationAsync(string operation, ReceiptRequest request)
        => ExecOperationAsync(operation, request);


    /// <summary>
    /// Коррекция документа
    /// </summary>
    /// <param name="operation">тип операции на регистрацию чека, которая должна быть выполнена</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public Task<ResponseBase> CorrectionAsync(string operation, CorrectionRequest request)
        => ExecOperationAsync(operation, request);


    /// <summary>
    /// Регистрация документа: Приход
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<ResponseBase> SellAsync(ReceiptRequest request)
        => OperationAsync("sell", request);

    /// <summary>
    /// Регистрация документа: Возврат прихода
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<ResponseBase> SellRefundAsync(ReceiptRequest request)
        => OperationAsync("sell_refund", request);

    /// <summary>
    /// Регистрация документа: Расход
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<ResponseBase> Buy(ReceiptRequest request)
        => OperationAsync("buy", request);

    /// <summary>
    /// Регистрация документа: Возврат расхода
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<ResponseBase> BuyRefund(ReceiptRequest request)
        => OperationAsync("buy_refund", request);

    /// <summary>
    /// Регистрация документа: Коррекция прихода
    /// </summary>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<ResponseBase> SellCorrection(CorrectionRequest request)
        => CorrectionAsync("sell_correction", request);

    /// <summary>
    /// Регистрация документа: Коррекция расхода
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<ResponseBase> BuyCorrection(CorrectionRequest request)
        => CorrectionAsync("buy_correction", request);

    /// <summary>
    /// Регистрация документа: Коррекция возврата прихода
    /// </summary>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<ResponseBase> SellRefundCorrection(CorrectionRequest request)
        => CorrectionAsync("sell_refund_correction", request);

    /// <summary>
    /// Регистрация документа: Коррекция возврата расхода
    /// </summary>
    /// <remarks>
    /// <seealso cref="OperationAsync(string, ReceiptRequest)"/>
    /// </remarks>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <returns></returns>
    public Task<ResponseBase> BuyRefundCorrection(CorrectionRequest request)
        => CorrectionAsync("buy_refund_correction", request);

}
