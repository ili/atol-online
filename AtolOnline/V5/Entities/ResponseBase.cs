using Newtonsoft.Json;

namespace AtolOnline.V5.Entities;

public class ResponseBase
{
    [JsonConstructor]
    public ResponseBase(Error? error, DateTime timestamp)
    {
        Error = error;
        Timestamp = timestamp;
    }

    public Error? Error { get; }
    public DateTime Timestamp { get; }

}
