using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// <para>
/// Тег: 1260 
/// </para>
/// Отраслевой реквизит предмета расчета
/// </summary>
public class SectoralItemProps
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="federalId"><inheritdoc cref="FederalId" path="/summary" /></param>
    /// <param name="date"><inheritdoc cref="Date" path="/summary" /></param>
    /// <param name="number"><inheritdoc cref="Number" path="/summary" /></param>
    /// <param name="value"><inheritdoc cref="Value" path="/summary" /></param>
    [JsonConstructor]
    public SectoralItemProps(string federalId, DateTime date, string number, string value)
    {
        FederalId = federalId;
        Date = date;
        Number = number;
        Value = value;
    }

    /// <summary>
    /// <para>
    /// Тег: 1262
    /// </para>
    /// Идентификатор ФОИВ.
    /// <para>
    /// https://www.consultant.ru/document/cons_doc_LAW_362322/89fecd4d4ad254b9276adb9c746900691de88ea2/
    /// </para>
    /// </summary>
    public string FederalId { get; }

    /// <summary>
    /// <para>
    /// Тег: 1263 
    /// </para>
    /// Дата нормативного акта федерального органа исполнительной власти, регламентирующего порядок заполнения реквизита «значение отраслевого реквизита»
    /// </summary>
    [JsonConverter(typeof(FormatDateJsonConverter))]
    public DateTime Date { get; }

    /// <summary>
    /// <para>
    /// Тег: 1264
    /// </para>
    /// Номер нормативного акта федерального органа исполнительной власти, регламентирующего порядок заполнения реквизита «значение отраслевого реквизита» (тег 1265)
    /// <para>Максимум 32 символа</para>
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// <para>
    /// Тег: 1265
    /// </para>
    /// Состав значений, определенных нормативного актом федерального органа исполнительной власти
    /// <para>Максимум 256 символов</para>
    /// </summary>
    public string Value { get; }
}

