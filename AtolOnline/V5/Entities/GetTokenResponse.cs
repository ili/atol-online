using Newtonsoft.Json;

namespace AtolOnline.V5.Entities;

public class GetTokenResponse: ResponseBase
{
    [JsonConstructor]
    public GetTokenResponse(string? status, Error? error, string? token, DateTime timestamp)
        : base(error, status, timestamp)
    {
        Token = token;
    }

    public string? Token { get; }
}
