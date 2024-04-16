using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

public class ResponseBase
{
    [JsonConstructor]
    public ResponseBase(Error? error, string? status, DateTime timestamp)
    {
        Error = error;
        Timestamp = timestamp;
        Status = status;
    }

    public Error? Error { get; }
    public DateTime Timestamp { get; }
    public string? Status { get; }
}
