using Newtonsoft.Json;

namespace AtolOnline;

public class ReceiptRequest : AtolRequest
{
    [JsonConstructor]
    public ReceiptRequest(string externalId, Receipt receipt, DateTime? timestamp = null, Service? service = null, bool? ismOptional = null)
        : base(externalId, timestamp, service, ismOptional)
    {
        Receipt = receipt;
    }

    public Receipt Receipt { get; }
}
