using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Данные о покупателе
/// </summary>
public class Client
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="email"><inheritdoc cref="Email" path="/summary" /></param>
    /// <param name="phone"><inheritdoc cref="Phone" path="/summary" /></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary" /></param>
    /// <param name="inn"><inheritdoc cref="INN" path="/summary" /></param>
    /// <param name="birthdate"><inheritdoc cref="Birthdate" path="/summary" /></param>
    /// <param name="citizenship"><inheritdoc cref="Citizenship" path="/summary" /></param>
    /// <param name="documentCode"><inheritdoc cref="DocumentCode" path="/summary" /></param>
    /// <param name="documentData"><inheritdoc cref="DocumentData" path="/summary" /></param>
    /// <param name="address"><inheritdoc cref="Address" path="/summary" /></param>
    /// <exception cref="ArgumentNullException"></exception>
    [JsonConstructor]
    public Client(
        string? email,
        string? phone = null,
        string? name = null,
        string? inn = null,
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
        INN = inn;
        Birthdate = birthdate;
        Citizenship = citizenship;
        DocumentCode = documentCode;
        DocumentData = documentData;
        Address = address;
    }

    /// <summary>
    /// <para>
    /// Тег: 1008
    /// </para>
    /// Электронный адрес покупателя.
    /// </summary>
    public string? Email { get; }


    /// <summary>
    /// <para>
    /// Тег: 1008
    /// </para>
    /// <para>
    ///     Телефон покупателя
    /// </para>
    /// <para>
    ///    Номер телефона необходимо передать вместе с кодом страны без пробелов и
    ///    дополнительных символов, кроме символа «+» (номер «+371 2 1234567» 
    ///    необходимо передать как «+37121234567»).
    /// </para>
    /// </summary>
    public string? Phone { get; }


    /// <summary>
    /// <para>
    /// Тег: 1227
    /// </para>
    /// Наименование покупателя (клиента).
    /// </summary>
    public string? Name { get; set; }


    /// <summary>
    /// <para>
    /// Тег: 1228
    /// </para>
    /// ИНН покупателя (клиента).
    /// </summary>
    [JsonProperty("inn")]
    public string? INN { get; set; }


    /// <summary>
    /// <para>
    /// V5 (ФФД 1.2)
    /// Тег: 1243
    /// </para>
    /// Дата рождения покупателя (клиента) в формате ДД.ММ.ГГГГ (ровно 10 символов).
    /// </summary>
    [JsonConverter(typeof(FormatDateJsonConverter.Date))]
    public DateTime? Birthdate { get; set; }

    /// <summary>
    /// <para>
    /// V5 (ФФД 1.2)
    /// Тег: 1244
    /// </para>
    /// Числовой код страны, гражданином которой является покупатель (клиент). 
    /// Код страны указывается в соответствии с Общероссийским классификатором стран мира ОКСМ. 
    /// </summary>
    public string? Citizenship { get; set; }

    /// <summary>
    /// <para>
    /// V5 (ФФД 1.2)
    /// Тег: 1245
    /// </para>
    /// Числовой код вида документа, удостоверяющего личность. Может принимать только значения из справочника.
    /// </summary>
    public string? DocumentCode { get; set; }

    /// <summary>
    /// <para>
    /// V5 (ФФД 1.2)
    /// Тег: 1246
    /// </para>
    /// Реквизиты документа, удостоверяющего личность.
    /// </summary>
    public string? DocumentData { get; set; }

    /// <summary>
    /// <para>
    /// V5 (ФФД 1.2)
    /// Тег: 1254
    /// </para>
    /// Адрес покупателя (клиента), грузополучателя.
    /// </summary>
    public string? Address { get; set; }
}
