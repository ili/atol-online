using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Базовый ответ
/// </summary>
public class ResponseBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="error"><inheritdoc cref="Error" path="/summary" /></param>
    /// <param name="status"><inheritdoc cref="Status" path="/summary" /></param>
    /// <param name="timestamp"><inheritdoc cref="Timestamp" path="/summary" /></param>
    [JsonConstructor]
    public ResponseBase(Error? error, string? status, DateTime timestamp)
    {
        Error = error;
        Timestamp = timestamp;
        Status = status;
    }
    /// <summary>
    /// Ошибка
    /// </summary>
    public Error? Error { get; }

    /// <summary>
    /// Метка времени
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// Статус
    /// </summary>
    public string? Status { get; }
}
