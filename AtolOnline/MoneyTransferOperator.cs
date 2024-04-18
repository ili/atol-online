using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Атрибуты оператора перевода
/// </summary>
public class MoneyTransferOperator
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary" /></param>
    /// <param name="inn"><inheritdoc cref="INN" path="/summary" /></param>
    /// <param name="phones"><inheritdoc cref="Phones" path="/summary" /></param>
    /// <param name="address"><inheritdoc cref="Address" path="/summary" /></param>
    [JsonConstructor]
    public MoneyTransferOperator(string? name, string? inn, IReadOnlyCollection<string>? phones, string? address)
    {
        Phones = phones;
        Name = name;
        Address = address;
        INN = inn;
    }

    /// <summary>
    /// <para>
    /// Тег: 1075
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
    /// </summary>
    public IReadOnlyCollection<string>? Phones { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1026
    /// </para>
    /// Наименование оператора перевода
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1005
    /// </para>
    /// Место нахождения оператора по переводу денежных средств
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1016
    /// </para>
    /// ИНН оператора перевода
    /// </summary>
    public string? INN { get; set; }
}