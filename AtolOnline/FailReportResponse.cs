using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Состояние документа (ошибка)
/// </summary>
public class FailReportResponse : ResponseBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="externalId"><inheritdoc cref="ExternalId" path="/summary" /></param>
    /// <param name="callbackUrl"><inheritdoc cref="CallbackUrl" path="/summary" /></param>
    /// <param name="error"><inheritdoc cref="ResponseBase.Error" path="/summary" /></param>
    /// <param name="status"><inheritdoc cref="ResponseBase.Status" path="/summary" /></param>
    /// <param name="timestamp"><inheritdoc cref="ResponseBase.Timestamp" path="/summary" /></param>
    [JsonConstructor]
    public FailReportResponse(string externalId, string callbackUrl, Error? error, string? status, DateTime timestamp) 
        : base(error, status, timestamp)
    {
        CallbackUrl = callbackUrl;
        ExternalId = externalId;
    }

    /// <summary>
    /// Имеет значение «callback_url не соответствует маске». Отображается в случае, 
    /// если значение параметра callback_url в запросе на регистрацию документа
    /// было указано некорректно
    /// </summary>
    public string CallbackUrl { get; }

    /// <summary>
    /// Идентификатор документа внешней системы, уникальный среди всех 
    /// документов, отправленных в данную группу ККТ
    /// </summary>
    public string ExternalId { get; }

}
