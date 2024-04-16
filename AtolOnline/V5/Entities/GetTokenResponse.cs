using Newtonsoft.Json;

namespace AtolOnline.V5.Entities;

public class GetTokenResponse: ResponseBase
{
    [JsonConstructor]
    public GetTokenResponse(Error? error, string? token, DateTime timestamp)
        : base(error, timestamp)
    {
        Token = token;
    }


    public string? Token { get; }

}
