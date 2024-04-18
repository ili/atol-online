using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Данные о продавце
/// </summary>
public class Company
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="inn"><inheritdoc cref="INN" path="/summary" /></param>
    /// <param name="paymentAddress"><inheritdoc cref="PaymentAddress" path="/summary" /></param>
    /// <param name="email"><inheritdoc cref="Email" path="/summary" /></param>
    /// <param name="sno"><inheritdoc cref="SNO" path="/summary" /></param>
    /// <param name="location"><inheritdoc cref="Location" path="/summary" /></param>
    [JsonConstructor]
    public Company(string inn, string paymentAddress, string email, SNO? sno = null, string? location = null)
    {
        Email = email;
        SNO = sno;
        INN = inn;
        PaymentAddress = paymentAddress;
        Location = location;
    }

    /// <summary>
    /// <para>
    /// Тег: 1117
    /// </para>
    /// Электронный адрес покупателя
    /// </summary>
    public string Email { get; set; }


    /// <summary>
    /// <para>
    /// Тег: 1055
    /// </para>
    /// Система налогообложения
    /// </summary>
    [JsonProperty("sno")]
    public SNO? SNO { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1018
    /// </para>
    /// ИНН организации. Используется для предотвращения ошибочных 
    /// регистраций чеков на ККТ зарегистрированных с другим ИНН(сравнивается со значением в ФН).
    /// </summary>
    [JsonProperty("inn")]
    public string INN { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1187
    /// </para>
    /// Место расчетов
    /// </summary>
    public string PaymentAddress { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1009
    /// </para>
    /// Адрес расчетов.
    /// Длина строки от 1 до 256 символов
    /// В случае отсутствия параметра, в чеке будет указан адрес ЦОД, где физически
    /// расположена касса.
    /// </summary>
    public string? Location { get; set; }
}
