
using AtolOnline.Shared;
using AtolOnline.V5.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace AtolOnline.V5.Client;

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
        string? source,
        string? token,
        string? baseAddress
        )
    {
        _login = login;
        _password = password;
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
        var request = new HttpRequestMessage(HttpMethod.Post, GetUrl("getToken"));
        request.Content = Content(new
        {
            Login = _login,
            Pass = _password,
            Source = _source

        });

        using var resp = await _httpClient.SendAsync(request);
        var data = await ReadAsync<GetTokenResponse>(resp);

        Token = data.Token;

        return data;
    }

}
