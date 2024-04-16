using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.Unofficial;

/// <summary>
/// Условия применения и значение реквизита «операционный реквизит чека» (тег 1270) определяются ФНС России
/// <para>
/// Тег: 1270
/// </para>
/// </summary>
public class OperatingCheckProps
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary" /></param>
    /// <param name="value"><inheritdoc cref="Value" path="/summary" /></param>
    /// <param name="timestamp"><inheritdoc cref="Timestamp" path="/summary" /></param>
    [JsonConstructor]
    public OperatingCheckProps(string name, string value, DateTime timestamp)
    {
        Name = name;
        Value = value;
        Timestamp = timestamp;
    }

    /// <summary>
    /// Идентификатор операции<br />
    /// Принимает значения «0» до определения значения реквизита ФНС России.
    /// </summary>
    [Required]
    public string Name { get; }

    /// <summary>
    /// Данные операции<br />
    /// Максимальная длина строки – 64 символа
    /// </summary>
    [Required]
    [StringLength(maximumLength: 64)]
    public string Value { get; }

    /// <summary>
    /// Дата и время операции в формате: «dd.mm.yyyy HH:MM:SS» 
    /// </summary>
    [Required]
    public DateTime Timestamp { get; }
}
