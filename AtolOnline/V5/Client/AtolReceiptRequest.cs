using AtolOnline.V5.Entities;
using Newtonsoft.Json;

namespace AtolOnline.V5.Client;

public class AtolReceiptRequest : AtolRequest
{
    [JsonConstructor]
    public AtolReceiptRequest(string externalId, Receipt receipt, DateTime? timestamp = null, Service? service = null, bool? ismOptional = null)
        : base(externalId, timestamp, service, ismOptional)
    {
        Receipt = receipt;
    }

    public Receipt Receipt { get; }
}

public class AtolCorrectionReceiptRequest: AtolRequest
{
    [JsonConstructor]
    public AtolCorrectionReceiptRequest(string externalId, 
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