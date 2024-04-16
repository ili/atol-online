using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Состояние документа (ошибка)
/// </summary>
public class FailReportResponse : ResponseBase
{
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
