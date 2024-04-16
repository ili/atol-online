using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Ответ о принятити документа
/// </summary>
public class OperationResponse : ResponseBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="uuid"><inheritdoc cref="Uuid" path="/summary" /></param>
    /// <param name="error"><inheritdoc cref="ResponseBase.Error" path="/summary" /></param>
    /// <param name="status"><inheritdoc cref="ResponseBase.Status" path="/summary" /></param>
    /// <param name="timestamp"><inheritdoc cref="ResponseBase.Timestamp" path="/summary" /></param>
    [JsonConstructor]
    public OperationResponse(string uuid, Error? error, string? status, DateTime timestamp)
        : base(error, status, timestamp)
    {
        Uuid = uuid;
    }

    /// <summary>
    /// Уникальный идентификатор. Максимальная длина строки – 128 
    /// символов.Если документ не удалось зарегистрировать, документу не
    /// будет присвоен UUID
    /// </summary>
    public string Uuid { get; }
}
