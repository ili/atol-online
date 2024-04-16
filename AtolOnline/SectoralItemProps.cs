using AtolOnline.Shared;
using Newtonsoft.Json;

namespace AtolOnline;

/// <summary>
/// Отраслевой реквизит предмета расчета
/// </summary>
/// <remarks>
/// Тег: 1260 
/// </remarks>
public class SectoralItemProps
{
    [JsonConstructor]
    public SectoralItemProps(string federalId, DateTime date, string number, string value)
    {
        FederalId = federalId;
        Date = date;
        Number = number;
        Value = value;
    }

    /// <summary>
    /// Идентификатор ФОИВ.
    /// <para>
    /// https://www.consultant.ru/document/cons_doc_LAW_362322/89fecd4d4ad254b9276adb9c746900691de88ea2/
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1262
    /// </remarks>
    public string FederalId { get; }

    /// <summary>
    /// Дата нормативного акта федерального органа исполнительной власти, регламентирующего порядок заполнения реквизита «значение отраслевого реквизита»
    /// </summary>
    /// <remarks>
    /// Тег: 1263 
    /// </remarks>
    [JsonConverter(typeof(FormatDateJsonConverter))]
    public DateTime Date { get; }

    /// <summary>
    /// Номер нормативного акта федерального органа исполнительной власти, регламентирующего порядок заполнения реквизита «значение отраслевого реквизита» (тег 1265)
    /// <para>Максимум 32 символа</para>
    /// </summary>
    /// <remarks>
    /// Тег: 1264
    /// </remarks>
    public string Number { get; }

    /// <summary>
    /// Состав значений, определенных нормативного актом федерального органа исполнительной власти
    /// <para>Максимум 256 символов</para>
    /// </summary>
    /// <remarks>
    /// Тег: 1265
    /// </remarks>
    public string Value { get; }
}

