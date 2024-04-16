using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Запрос отправки документа
/// </summary>
public class ReceiptRequest : AtolRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="externalId"><inheritdoc cref="AtolRequest.ExternalId" path="/summary" /></param>
    /// <param name="receipt"><inheritdoc cref="Receipt" path="/summary" /></param>
    /// <param name="timestamp"><inheritdoc cref="AtolRequest.Timestamp" path="/summary" /></param>
    /// <param name="service"><inheritdoc cref="AtolRequest.Service" path="/summary" /></param>
    /// <param name="ismOptional"><inheritdoc cref="AtolRequest.IsmOptional" path="/summary" /></param>
    [JsonConstructor]
    public ReceiptRequest(string externalId, Receipt receipt, DateTime? timestamp = null, Service? service = null, bool? ismOptional = null)
        : base(externalId, timestamp, service, ismOptional)
    {
        Receipt = receipt;
    }

    /// <summary>
    /// Чек
    /// </summary>
    public Receipt Receipt { get; }
}
