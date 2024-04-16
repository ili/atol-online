using AtolOnline.V5.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.V5.Entities;

public class Company
{
    [JsonConstructor]
    public Company(string email, SNO? sno, string inn, string paymentAddress, string? location)
    {
        Email = email;
        SNO = sno;
        INN = inn;
        PaymentAddress = paymentAddress;
        Location = location;
    }

    /// <summary>
    /// Электронный адрес покупателя
    /// </summary>
    /// <remarks>
    /// Тег: 1117
    /// </remarks>
    [EmailAddress]
    [Required]
    [StringLength(maximumLength: 64)]
    public string Email { get; set; }


    /// <summary>
    /// Система налогообложения
    /// </summary>
    /// <remarks>
    /// Тег: 1055
    /// </remarks>
    [Required]
    [JsonProperty("sno")]
    [JsonConverter(typeof(StringEnumConverter))]
    public SNO? SNO { get; set; }

    /// <summary>
    /// ИНН организации. Используется для предотвращения ошибочных 
    /// регистраций чеков на ККТ зарегистрированных с другим ИНН(сравнивается со значением в ФН).
    /// </summary>
    /// <remarks>
    /// Тег: 1018
    /// </remarks>
    [JsonProperty("inn")]
    [Required]
    [StringLength(maximumLength: 12)]
    public string INN { get; set; }

    /// <summary>
    /// Место расчетов
    /// </summary>
    /// <remarks>
    /// Тег: 1187
    /// </remarks>
    [Required]
    [StringLength(maximumLength: 256)]
    public string PaymentAddress { get; set; }

    /// <summary>
    /// Адрес расчетов.
    /// Длина строки от 1 до 256 символов
    /// В случае отсутствия параметра, в чеке будет указан адрес ЦОД, где физически
    /// расположена касса.
    /// </summary>
    /// <remarks>
    /// Тег: 1009
    /// </remarks>
    [StringLength(maximumLength: 256)]
    public string? Location { get; set; }
}
