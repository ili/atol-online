using Newtonsoft.Json;


namespace AtolOnline.Unofficial;

/// <summary>
/// Дополнительный реквизит пользователя
/// </summary>
/// <remarks>
/// Тег: 1084
/// </remarks>
public class AdditionalUserProps
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary" /></param>
    /// <param name="value"><inheritdoc cref="Value" path="/summary" /> </param>
    [JsonConstructor]
    public AdditionalUserProps(string name, string value)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    /// Наименование дополнительного реквизита пользователя.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Значение дополнительного реквизита пользователя
    /// </summary>
    public string Value { get; }
}
