namespace AtolOnline.Unofficial;

/// <summary>
/// Состояние документа
/// </summary>
public class ReportResponse : FailReportResponse
{
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
