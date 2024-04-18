namespace AtolOnline.Unofficial;

/// <summary>
/// Данные поставщика
/// </summary>
public class SupplierInfo
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="inn"><inheritdoc cref="Inn" path="/summary" /></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary" /></param>
    /// <param name="phones"><inheritdoc cref="Phones" path="/summary" /></param>
    public SupplierInfo(string inn, string? name = null, List<string>? phones = null)
    {
        Inn = inn;
        Name = name;
        Phones = phones;
    }

    /// <summary>
    /// <para>
    /// Тег: 1226
    /// </para>
    /// ИНН поставщика. 10 или 12 цифр
    /// </summary>
    public string Inn { get; }

    /// <summary>
    /// <para>
    /// Тег: 1225
    /// </para>
    /// Наименование поставщика.
    /// <para>
    /// Максимум 256 символов
    /// </para>
    /// <para>
    /// Обязателен если признак агента по предмету расчета принимает следующие значения
    /// <list type="bullet">
    /// <item>
    /// <see cref="AgentType.BankPayingAgent"/>
    /// </item>
    /// <item>
    /// <see cref="AgentType.BankPayingSubagent"/>
    /// </item>
    /// <item>
    /// <see cref="AgentType.PayingAgent"/>
    /// </item>
    /// <item>
    /// <see cref="AgentType.PayingSubagent"/>
    /// </item>
    /// </list>
    /// </para>
    /// </summary>

    public string? Name { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1171
    /// </para>
    /// <para>
    /// Номера телефонов платежного агента, платежного субагента, банковского 
    /// платежного агента, банковского платежного субагента
    /// Номер телефона необходимо передать вместе с кодом страны без пробелов и
    /// дополнительных символов, кроме символа «+».
    /// </para>
    /// <para>
    /// Если номер телефон начинается с символа «+», то максимальная длина одного
    /// элемента массива – 19 символов.
    /// </para>
    /// <para>
    /// Если номер телефона относится к России(префикс «+7»), то значение можно
    /// передать без префикса(номер «+7 925 1234567» можно передать как
    /// «9251234567»). Максимальная длина одного элемента массива в таком случае –
    /// 17 символов
    /// </para>
    /// <para>
    /// Обязателен если признак агента по предмету расчета принимает следующие значения
    /// <list type="bullet">
    /// <item>
    /// <see cref="AgentType.BankPayingAgent"/>
    /// </item>
    /// <item>
    /// <see cref="AgentType.BankPayingSubagent"/>
    /// </item>
    /// <item>
    /// <see cref="AgentType.PayingAgent"/>
    /// </item>
    /// <item>
    /// <see cref="AgentType.PayingSubagent"/>
    /// </item>
    /// </list>
    /// </para>
    /// </summary>
    public List<string>? Phones { get; set; }
}