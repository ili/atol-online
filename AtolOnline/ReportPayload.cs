using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Реквизиты фискализации документа
/// </summary>
public class ReportPayload
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="fiscalReceiptNumber"><inheritdoc cref="FiscalReceiptNumber" path="/summary" /></param>
    /// <param name="shiftNumber"><inheritdoc cref="ShiftNumber" path="/summary" /></param>
    /// <param name="receiptDatetime"><inheritdoc cref="ReceiptDatetime" path="/summary" /></param>
    /// <param name="total"><inheritdoc cref="Total" path="/summary" /></param>
    /// <param name="fnNumber"><inheritdoc cref="FnNumber" path="/summary" /></param>
    /// <param name="ecrRegistrationNumber"><inheritdoc cref="EcrRegistrationNumber" path="/summary" /></param>
    /// <param name="fiscalDocumentNumber"><inheritdoc cref="FiscalDocumentNumber" path="/summary" /></param>
    /// <param name="fiscalDocumentAttribute"><inheritdoc cref="FiscalDocumentAttribute" path="/summary" /></param>
    /// <param name="fnsSite"><inheritdoc cref="FnsSite" path="/summary" /></param>
    /// <param name="ofdInn"><inheritdoc cref="OfdInn" path="/summary" /></param>
    /// <param name="ofdReceiptUrl"><inheritdoc cref="OfdReceiptUrl" path="/summary" /></param>
    /// <param name="marksResult"><inheritdoc cref="MarksResult" path="/summary" /></param>
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
    /// <para>
    /// Тег: 1042
    /// </para>
    /// Номер чека в смене
    /// </summary>
    public int FiscalReceiptNumber {  get; }

    /// <summary>
    /// <para>
    /// Тег: 1038
    /// </para>
    /// Номер смены
    /// </summary>
    public int ShiftNumber {  get; }

    /// <summary>
    /// <para>
    /// Тег: 1012
    /// </para>
    /// Дата и время документа из ФН
    /// </summary>
    public DateTime ReceiptDatetime { get; }

    /// <summary>
    /// <para>
    /// Тег: 1020
    /// </para>
    /// Итоговая сумма документа в рублях с заданным в CMS округлением
    /// </summary>
    public decimal Total {  get; }

    /// <summary>
    /// <para>
    /// Тег: 1041
    /// </para>
    /// Регистрационный номер ККТ
    /// </summary>
    public string FnNumber { get; }

    /// <summary>
    /// <para>
    /// Тег: 1037
    /// </para>
    /// Регистрационный номер ККТ
    /// </summary>
    public int EcrRegistrationNumber { get; }

    /// <summary>
    /// <para>
    /// Тег: 1040
    /// </para>
    /// Фискальный номер документа
    /// </summary>
    public int FiscalDocumentNumber { get; }

    /// <summary>
    /// <para>
    /// Тег: 1077
    /// </para>
    /// Фискальный признак документа
    /// </summary>
    public int FiscalDocumentAttribute { get; }

    /// <summary>
    /// <para>
    /// Тег: 1060
    /// </para>
    /// Адрес сайта ФНС
    /// </summary>
    public string FnsSite { get; }

    /// <summary>
    /// <para>
    /// Тег: 1017
    /// </para>
    /// Идентификационный номер налогоплательщика оператора фискальных данных
    /// </summary>
    public string OfdInn { get; }

    /// <summary>
    /// <para>
    /// Тег: 
    /// </para>
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
    public string? OfdReceiptUrl { get; }


    /// <summary>
    /// <para>
    /// Тег: 2106
    /// </para>
    /// Информации о проверке кодов маркировки
    /// <para>
    /// Если в исходном чеке нет кодов маркировки, подлежащих проверке, объект
    /// marks_result в ответе выводиться не будет
    /// </para>
    /// </summary>
    public IReadOnlyCollection<MarksResult>? MarksResult { get; }
}
