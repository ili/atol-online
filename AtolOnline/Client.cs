using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.Unofficial;

public class Client
{
    [JsonConstructor]
    public Client(
        string? email,
        string? phone = null,
        string? name = null,
        string? iNN = null,
        DateTime? birthdate = null,
        string? citizenship = null,
        string? documentCode = null,
        string? documentData = null,
        string? address = null)
    {
        if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phone))
            throw new ArgumentNullException("email or phone should be provided");

        Email = email;
        Phone = phone;
        Name = name;
        INN = iNN;
        Birthdate = birthdate;
        Citizenship = citizenship;
        DocumentCode = documentCode;
        DocumentData = documentData;
        Address = address;
    }

    /// <summary>
    /// Электронный адрес покупателя.
    /// </summary>
    /// <remarks>
    /// Тег: 1008
    /// </remarks>
    [EmailAddress]
    [StringLength(maximumLength: 64)]
    public string? Email { get; }


    /// <summary>
    /// <para>
    ///     Телефон покупателя
    /// </para>
    /// <para>
    ///    Номер телефона необходимо передать вместе с кодом страны без пробелов и
    ///    дополнительных символов, кроме символа «+» (номер «+371 2 1234567» 
    ///    необходимо передать как «+37121234567»).
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1008
    /// </remarks>
    [StringLength(maximumLength: 19)]
    public string? Phone { get; }


    /// <summary>
    /// Наименование покупателя (клиента).
    /// </summary>
    /// <remarks>
    /// Тег: 1227
    /// </remarks>
    [StringLength(maximumLength: 256)]
    public string? Name { get; set; }


    /// <summary>
    /// ИНН покупателя (клиента).
    /// </summary>
    /// <remarks>
    /// Тег: 1228
    /// </remarks>
    [JsonProperty("inn")]
    [StringLength(maximumLength: 12)]
    public string? INN { get; set; }


    /// <summary>
    /// Дата рождения покупателя (клиента) в формате ДД.ММ.ГГГГ (ровно 10 символов).
    /// </summary>
    /// <remarks>
    /// V5 (ФФД 1.2)
    /// Тег: 1243
    /// </remarks>
    [JsonConverter(typeof(FormatDateJsonConverter.Date))]
    public DateTime? Birthdate { get; set; }

    /// <summary>
    /// Числовой код страны, гражданином которой является покупатель (клиент). 
    /// Код страны указывается в соответствии с Общероссийским классификатором стран мира ОКСМ. 
    /// </summary>
    /// <remarks>
    /// V5 (ФФД 1.2)
    /// Тег: 1244
    /// </remarks>
    [StringLength(maximumLength: 3)]
    public string? Citizenship { get; set; }

    /// <summary>
    /// Числовой код вида документа, удостоверяющего личность. Может принимать только значения из справочника.
    /// </summary>
    /// <remarks>
    /// V5 (ФФД 1.2)
    /// Тег: 1245
    /// </remarks>
    [StringLength(maximumLength: 2)]
    public string? DocumentCode { get; set; }

    /// <summary>
    /// Реквизиты документа, удостоверяющего личность.
    /// </summary>
    /// <remarks>
    /// V5 (ФФД 1.2)
    /// Тег: 1246
    /// </remarks>
    [StringLength(maximumLength: 64)]
    public string? DocumentData { get; set; }

    /// <summary>
    /// Адрес покупателя (клиента), грузополучателя.
    /// </summary>
    /// <remarks>
    /// V5 (ФФД 1.2)
    /// Тег: 1254
    /// </remarks>
    [StringLength(maximumLength: 256)]
    public string? Address { get; set; }
}
