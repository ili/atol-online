namespace AtolOnline.Unofficial;

/// <summary>
/// Состояние документа
/// </summary>
public class ReportResponse : FailReportResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="payload"><inheritdoc cref="Payload" path="/summary" /></param>
    /// <param name="groupCode"><inheritdoc cref="GroupCode" path="/summary" /></param>
    /// <param name="daemonCode"><inheritdoc cref="DaemonCode" path="/summary" /></param>
    /// <param name="deviceCode"><inheritdoc cref="DeviceCode" path="/summary" /></param>
    /// <param name="callbackUrl"><inheritdoc cref="FailReportResponse.CallbackUrl" path="/summary" /></param>
    /// <param name="externalId"><inheritdoc cref="FailReportResponse.ExternalId" path="/summary" /></param>
    /// <param name="error"><inheritdoc cref="ResponseBase.Error" path="/summary" /></param>
    /// <param name="status"><inheritdoc cref="ResponseBase.Status" path="/summary" /></param>
    /// <param name="timestamp"><inheritdoc cref="ResponseBase.Timestamp" path="/summary" /></param>
    public ReportResponse(
        ReportPayload payload,
        string groupCode,
        string daemonCode,
        string deviceCode,
        string callbackUrl,
        string externalId,
        Error? error, 
        string? status, 
        DateTime timestamp) 
        : base(externalId, callbackUrl, error, status, timestamp)
    {
        Payload = payload;
        GroupCode = groupCode;
        DaemonCode = daemonCode;
        DeviceCode = deviceCode;
    }

    /// <summary>
    /// Реквизиты фискализации документа
    /// </summary>
    public ReportPayload Payload { get; }

    /// <summary>
    /// Идентификатор группы ККТ
    /// </summary>
    public string GroupCode { get; }

    /// <summary>
    /// Наименование сервера
    /// </summary>
    public string DaemonCode { get; }

    /// <summary>
    /// Код ККТ
    /// </summary>
    public string DeviceCode { get; }

}
