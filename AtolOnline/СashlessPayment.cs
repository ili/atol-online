namespace AtolOnline.Unofficial;

/// <summary>
/// <para>
/// Тэг: 1235
/// </para>
/// <para>
/// Сведения об оплате в безналичном порядке суммы расчета, указанной в кассовом чеке(БСО), способом, признак которого указан в этом реквизите
/// </para>
/// </summary>
public class СashlessPayment
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id"><inheritdoc cref="Id" path="/summary" /></param>
    /// <param name="method"><inheritdoc cref="Method" path="/summary" /></param>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <param name="additionalInfo"><inheritdoc cref="AdditionalInfo" path="/summary" /></param>
    public СashlessPayment(string id, 
        int method, 
        decimal sum, 
        string? additionalInfo = null)
    {
        Id = id;
        Method = method;
        Sum = sum;
        AdditionalInfo = additionalInfo;
    }

    /// <summary>
    /// <para>
    /// Тэг: 1082
    /// </para>
    /// <para>
    /// Сумма оплаты безналичными: 
    /// <list type="bullet">
    /// <item>
    /// <description>целая часть не более 8 знаков</description>
    /// </item>
    /// <item>
    /// <description>дробная часть не более 2 знаков</description>
    /// </item>
    /// </list>
    /// </para>
    /// </summary>
    public decimal Sum { get; set; }


    /// <summary>
    /// <para>
    /// Тэг: 1236
    /// </para>
    /// <para>
    /// Признак способа оплаты безналичными
    /// </para>
    /// <para>
    /// Значение реквизита  определяется в порядке, установленном ФНС России
    /// </para>
    /// </summary>
    public int Method { get; set; }

    /// <summary>
    /// <para>
    /// Тэг: 1237
    /// </para>
    /// <para>
    /// Идентификаторы безналичной оплаты, максимум 256 символов
    /// </para>
    /// <para>
    /// Значение реквизита  определяется в порядке, установленном ФНС России
    /// </para>
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// <para>
    /// Тэг: 1238
    /// </para>
    /// <para>
    /// Дополнительные сведения о безналичной оплате, максимум 256 символов
    /// </para>
    /// <para>
    /// Значение реквизита  определяется в порядке, установленном ФНС России
    /// </para>
    /// </summary>
    public string? AdditionalInfo { get; set; }
}