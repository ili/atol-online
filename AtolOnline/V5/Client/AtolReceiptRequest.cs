using AtolOnline.V5.Entities;
using Newtonsoft.Json;

namespace AtolOnline.V5.Client;

public class AtolReceiptRequest : AtolRequest
{
    [JsonConstructor]
    public AtolReceiptRequest(Receipt receipt, DateTime timestamp, string externalId, Service? service = null) 
        : base(timestamp, externalId, service)
    {
        Receipt = receipt;
    }

    public Receipt Receipt { get; }
}
