using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Базовы запрос
/// </summary>
public abstract class AtolRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="externalId"><inheritdoc cref="ExternalId" path="/summary" /></param>
    /// <param name="timestamp"><inheritdoc cref="Timestamp" path="/summary" /></param>
    /// <param name="service"><inheritdoc cref="Service" path="/summary" /></param>
    /// <param name="ismOptional"><inheritdoc cref="IsmOptional" path="/summary" /></param>
    [JsonConstructor]
    public AtolRequest(string externalId, DateTime? timestamp, Service? service, bool? ismOptional)
    {
        Timestamp = timestamp ?? DateTime.Now;
        ExternalId = externalId;
        Service = service;
        IsmOptional = ismOptional;
    }

    /// <summary>
    /// Дата и время документа внешней системы в формате: «dd.mm.yyyy HH:MM:SS»
    /// </summary>
    public DateTime Timestamp { get; }


    /// <summary>
    /// Идентификатор документа внешней системы.
    /// </summary>
    public string ExternalId { get; }


    /// <summary>
    /// Идентификатор документа внешней системы.
    /// </summary>
    public Service? Service { get; set; }

    /// <summary>
    /// Параметр указывает сервису, должен ли чек регистрироваться в случае, если 
    /// не удалось проверить код маркировки вследствие недоступности системы
    /// маркировки(ИСМ)
    /// <para><value>true</value> - если при проверке КМ ИСМ не ответил за отведенное время 
    /// проверки(timeout), то чек все равно будет зарегистрирован и в теге 
    /// 2106 (Результат проверки сведений о товаре) указывается значение 0
    /// </para>
    /// <para><value>false</value> -  если при проверке КМ ИСМ не 
    /// ответил за отведенное время проверки(timeout), то чек не
    /// регистрируется с ошибкой 421 (Истёк таймаут проверки КМ)
    /// </para>
    /// </summary>
    public bool? IsmOptional { get; set; }
}
