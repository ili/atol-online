using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Реквизиты фискализации документа
/// </summary>
public class ReportPayload
{
    [JsonConstructor]
    public ReportPayload(
        int fiscalReceiptNumber,
        int shiftNumber,
        DateTime receiptDatetime,
        decimal total,
        string fnNumber,
        int ecrRegistrationNumber,
        int fiscalDocumentNumber,
        int fiscalDocumentAttribute,
        string fnsSite,
        string ofdInn,
        string? ofdReceiptUrl,
        IReadOnlyCollection<MarksResult>? marksResult)
    {
        FiscalReceiptNumber = fiscalReceiptNumber;
        ShiftNumber = shiftNumber;
        ReceiptDatetime = receiptDatetime;
        Total = total;
        FnNumber = fnNumber;
        EcrRegistrationNumber = ecrRegistrationNumber;
        FiscalDocumentNumber = fiscalDocumentNumber;
        FiscalDocumentAttribute = fiscalDocumentAttribute;
        FnsSite = fnsSite;
        OfdInn = ofdInn;
        OfdReceiptUrl = ofdReceiptUrl;
        MarksResult = marksResult;
    }

    /// <summary>
    /// Номер чека в смене
    /// </summary>
    /// <remarks>
    /// Тег: 1042
    /// </remarks>
    public int FiscalReceiptNumber {  get; }

    /// <summary>
    /// Номер смены
    /// </summary>
    /// <remarks>
    /// Тег: 1038
    /// </remarks>
    public int ShiftNumber {  get; }

    /// <summary>
    /// Дата и время документа из ФН
    /// </summary>
    /// <remarks>
    /// Тег: 1012
    /// </remarks>
    public DateTime ReceiptDatetime { get; }

    /// <summary>
    /// Итоговая сумма документа в рублях с заданным в CMS округлением
    /// </summary>
    /// <remarks>
    /// Тег: 1020
    /// </remarks>
    public decimal Total {  get; }

    /// <summary>
    /// Регистрационный номер ККТ
    /// </summary>
    /// <remarks>
    /// Тег: 1041
    /// </remarks>
    public string FnNumber { get; }

    /// <summary>
    /// Регистрационный номер ККТ
    /// </summary>
    /// <remarks>
    /// Тег: 1037
    /// </remarks>
    public int EcrRegistrationNumber { get; }

    /// <summary>
    /// Фискальный номер документа
    /// </summary>
    /// <remarks>
    /// Тег: 1040
    /// </remarks>
    public int FiscalDocumentNumber { get; }

    /// <summary>
    /// Фискальный признак документа
    /// </summary>
    /// <remarks>
    /// Тег: 1077
    /// </remarks>
    public int FiscalDocumentAttribute { get; }

    /// <summary>
    /// Адрес сайта ФНС
    /// </summary>
    /// <remarks>
    /// Тег: 1060
    /// </remarks>
    public string FnsSite { get; }

    /// <summary>
    /// Идентификационный номер налогоплательщика оператора фискальных данных
    /// </summary>
    /// <remarks>
    /// Тег: 1017
    /// </remarks>
    public string OfdInn { get; }

    /// <summary>
    /// URL для просмотра чека на сайте ОФД. Отображается только для чеков, 
    /// зарегистрированных с помощью:
    /// <list type="bullet">
    /// <item>
    /// Платформа ОФД(ООО "Эвотор ОФД", ИНН 9715260691);
    /// </item>
    /// <item>
    /// Первый ОФД(АО "ЭСК", ИНН 7709364346);
    /// </item>
    /// <item>
    /// Такском ОФД
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// Тег: 
    /// </remarks>
    public string? OfdReceiptUrl { get; }


    /// <summary>
    /// Информации о проверке кодов маркировки
    /// <para>
    /// Если в исходном чеке нет кодов маркировки, подлежащих проверке, объект
    /// marks_result в ответе выводиться не будет
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 2106
    /// </remarks>
    public IReadOnlyCollection<MarksResult>? MarksResult { get; }
}
