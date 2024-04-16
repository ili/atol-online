using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.Unofficial;

/// <summary>
/// Чек
/// </summary>
public class Receipt
{
    /// <summary>
    /// Чек
    /// </summary>
    /// <param name="client"><inheritdoc cref="Client" path="/summary" />
    /// </param>
    /// <param name="company"><inheritdoc cref="Company"  path="/summary" /></param>
    /// <param name="items"><inheritdoc cref="Items"  path="/summary" /></param>
    /// <param name="payments"><inheritdoc cref="Payments"  path="/summary" /></param>
    /// <param name="total"><inheritdoc cref="Total"  path="/summary" /></param>
    /// <param name="agentInfo"><inheritdoc cref="AgentInfo"  path="/summary" /></param>
    /// <param name="supplierInfo"><inheritdoc cref="SupplierInfo"  path="/summary" /></param>
    /// <param name="vats"><inheritdoc cref="Vats"  path="/summary" /></param>
    /// <param name="cashier"><inheritdoc cref="Cashier" path="/summary" /></param>
    /// <param name="cashierINN"><inheritdoc cref="CashierINN"/></param>
    /// <param name="additionalCheckProps"><inheritdoc cref="AdditionalCheckProps" path="/summary" /></param>
    /// <param name="additionalUserProps"><inheritdoc cref="AdditionalUserProps" path="/summary" /></param>
    /// <param name="operatingCheckProps"><inheritdoc cref="OperatingCheckProps" path="/summary" /></param>
    /// <param name="sectoralCheckProps"><inheritdoc cref="SectoralCheckProps" path="/summary" /></param>
    /// <param name="deviceNumber"><inheritdoc cref="DeviceNumber" path="/summary" /></param>
    [JsonConstructor]
    public Receipt(
        Client client,
        Company company,
        IReadOnlyCollection<Item> items,
        IReadOnlyCollection<Payment> payments,
        decimal? total = null,
        AgentInfo? agentInfo = null,
        SupplierInfo? supplierInfo = null,
        IReadOnlyCollection<Vat>? vats = null,
        string? cashier = null,
        string? cashierINN = null,
        string? additionalCheckProps = null,
        AdditionalUserProps? additionalUserProps = null,
        OperatingCheckProps? operatingCheckProps = null,
        IReadOnlyCollection<SectoralItemProps>? sectoralCheckProps = null,
        string? deviceNumber = null)
    {
        Client = client;
        Company = company;
        AgentInfo = agentInfo;
        SupplierInfo = supplierInfo;
        Items = items;
        Payments = payments;
        Vats = vats;
        Cashier = cashier;
        CashierINN = cashierINN;
        AdditionalCheckProps = additionalCheckProps;
        Total = total ?? items.Sum(_ => _.Sum);
        AdditionalUserProps = additionalUserProps;
        OperatingCheckProps = operatingCheckProps;
        SectoralCheckProps = sectoralCheckProps;
        DeviceNumber = deviceNumber;
    }

    /// <summary>
    /// Сведения о покупателе (клиенте)
    /// </summary>
    public Client Client { get; }

    /// <summary>
    /// Сведения о компании (продавец)
    /// </summary>
    public Company Company { get; }

    /// <summary>
    /// Атрибуты агента
    /// </summary>
    public AgentInfo? AgentInfo { get; set; }

    /// <summary>
    /// Атрибуты поставщика
    /// </summary>
    /// <remarks>
    /// Поле обязательно, если передан <see cref="AgentInfo"/>
    /// </remarks>
    public SupplierInfo? SupplierInfo { get; set; }


    /// <summary>
    /// Атрибуты позиций. Ограничение по количеству от 1 до 100
    /// </summary>
    public IReadOnlyCollection<Item> Items { get; }


    /// <summary>
    /// Оплаты. Ограничение по количеству от 1 до 10
    /// </summary>
    [Required]
    public IReadOnlyCollection<Payment> Payments { get; }


    /// <summary>
    /// Атрибуты налогов на чек. Ограничение по количеству от 1 до 6
    /// Необходимо передать либо сумму налога на позицию, либо сумму налога на чек. 
    /// Если будет переданы и сумма налога на позицию и сумма 
    /// налога на чек, сервис учтет только сумму налога на чек.
    /// </summary>
    public IReadOnlyCollection<Vat>? Vats { get; set; }

    /// <summary>
    /// ФИО кассира. Максимальная длина строки – 64 символа.
    /// </summary>
    /// <remarks>
    /// Тег: 1021
    /// </remarks>
    [StringLength(maximumLength: 64)]
    public string? Cashier { get; set; }

    /// <summary>
    /// ИНН кассира.
    /// </summary>
    /// <remarks>
    /// Тег: 1203
    /// </remarks>
    [StringLength(maximumLength: 12)]
    public string? CashierINN { get; set; }

    /// <summary>
    /// Дополнительный реквизит чека
    /// </summary>
    /// <remarks>
    /// Тег: 1192
    /// </remarks>
    [StringLength(maximumLength: 16)]
    public string? AdditionalCheckProps { get; set; }

    /// <summary>
    /// Итоговая сумма чека в рублях с заданным в CMS округлением:<br />
    /// ㅤ*целая часть не более 8 знаков;<br />
    /// ㅤ*дробная часть не более 2 знаков.<br />
    /// Значение вычисляется, как сумма всех значений реквизита «стоимость предмета расчета с учетом скидок и наценок» (тег 1043)
    /// </summary>
    /// <remarks>
    /// Тег: 1020
    /// </remarks>
    public decimal Total { get; set; }

    /// <summary>
    /// Дополнительный реквизит пользователя.
    /// </summary>
    /// <remarks>
    /// Тег: 1084
    /// </remarks>
    public AdditionalUserProps? AdditionalUserProps { get; set; }

    /// <summary>
    /// Условия применения и значение реквизита «операционный реквизит чека»  определяются ФНС России.
    /// </summary>
    /// <remarks>
    /// Тег: 1270
    /// </remarks>
    public OperatingCheckProps? OperatingCheckProps { get; set; }

    /// <summary>
    /// Включается в состав кассового чека (БСО) в случае, если включение этого 
    /// отраслевого реквизита кассового чека предусмотрено законодательством Российской Федерации.
    /// </summary>
    /// <remarks>
    /// Тег: 1261
    /// </remarks>
    public IReadOnlyCollection<SectoralItemProps>? SectoralCheckProps { get; set; }

    /// <summary>
    /// <para>
    /// Заводской номер автоматического устройства для расчетов.
    /// </para>
    /// От 1 до 20 символов
    /// <para>
    /// В случае, если параметр не будет передан, в чеке будет указан
    /// внутренний номер кассы в сервисе АТОЛ Онлайн
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1036
    /// </remarks>
    public string? DeviceNumber { get; set; }
}
