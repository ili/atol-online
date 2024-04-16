using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

public class CorrectionRequest : AtolRequest
{
    [JsonConstructor]
    public CorrectionRequest(string externalId,
        CorrectionReceipt correction,
        DateTime? timestamp = null,
        Service? service = null,
        bool? ismOptional = null)
        : base(externalId, timestamp, service, ismOptional)
    {
        Correction = correction;
    }

    public CorrectionReceipt Correction { get; }

}