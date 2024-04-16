using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.V5.Entities;

public class AdditionalUserProps
{
    [JsonConstructor]
    public AdditionalUserProps(string name, string value)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    /// Наименование дополнительного реквизита пользователя.
    /// </summary>
    [Required]
    [StringLength(maximumLength:64)]
    public string Name { get; }

    /// <summary>
    /// Значение дополнительного реквизита пользователя
    /// </summary>
    [Required]
    [StringLength(maximumLength: 256)]
    public string Value { get; }
}
