using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Запрос на чек коррекции
/// </summary>
public class CorrectionRequest : AtolRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="externalId"><inheritdoc cref="AtolRequest.ExternalId" path="/summary" /></param>
    /// <param name="correction"><inheritdoc cref="Correction" path="/summary" /></param>
    /// <param name="timestamp"><inheritdoc cref="AtolRequest.Timestamp" path="/summary" /></param>
    /// <param name="service"><inheritdoc cref="AtolRequest.Service" path="/summary" /></param>
    /// <param name="ismOptional"><inheritdoc cref="AtolRequest.IsmOptional" path="/summary" /></param>
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

    /// <summary>
    /// Корекция
    /// </summary>
    public CorrectionReceipt Correction { get; }

}