using AtolOnline.V5.Entities;

namespace AtolOnline.V5.Client;

public class AtolReceiptRequest : AtolRequest
{
    public Receipt Receipt { get; set; }
}
