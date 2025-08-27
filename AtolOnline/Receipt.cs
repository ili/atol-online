using Newtonsoft.Json;

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
    /// <param name="internet"><inheritdoc cref="Internet" path="/summary" /></param>
    /// <param name="timezone"><inheritdoc cref="Timezone" path="/summary" /></param>
    /// <param name="cashlessPayments"><inheritdoc cref="CashlessPayments" path="/summary" /></param>
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
        string? deviceNumber = null,
        bool? internet = null,
        int? timezone = null,
        IReadOnlyCollection<СashlessPayment>? cashlessPayments = null)
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
        Internet = internet;
        Timezone = timezone;
        CashlessPayments = cashlessPayments;
    }

    /// <summary>
    /// Сведения о покупателе (клиенте)
    /// <seealso cref="Unofficial.Client"/>
    /// </summary>
    public Client Client { get; }

    /// <summary>
    /// Сведения о компании (продавец)
    /// <seealso cref="Unofficial.Company"/>
    /// </summary>
    public Company Company { get; }

    /// <summary>
    /// Атрибуты агента
    /// <seealso cref="Unofficial.AgentInfo"/>
    /// </summary>
    public AgentInfo? AgentInfo { get; set; }

    /// <summary>
    /// Атрибуты поставщика
    /// <para>
    /// Поле обязательно, если передан <see cref="AgentInfo"/>
    /// </para>
    /// <seealso cref="Unofficial.SupplierInfo"/>
    /// </summary>
    public SupplierInfo? SupplierInfo { get; set; }


    /// <summary>
    /// Атрибуты позиций. Ограничение по количеству от 1 до 100
    /// <seealso cref="Unofficial.Item"/>
    /// </summary>
    public IReadOnlyCollection<Item> Items { get; }


    /// <summary>
    /// Оплаты. Ограничение по количеству от 1 до 10
    /// <seealso cref="Unofficial.Payment"/>
    /// </summary>
    public IReadOnlyCollection<Payment> Payments { get; }


    /// <summary>
    /// Атрибуты налогов на чек. Ограничение по количеству от 1 до 6
    /// Необходимо передать либо сумму налога на позицию, либо сумму налога на чек. 
    /// Если будет переданы и сумма налога на позицию и сумма 
    /// налога на чек, сервис учтет только сумму налога на чек.
    /// <seealso cref="Unofficial.Vat"/>
    /// </summary>
    public IReadOnlyCollection<Vat>? Vats { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1021
    /// </para>
    /// ФИО кассира. Максимальная длина строки – 64 символа.
    /// </summary>
    public string? Cashier { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1203
    /// </para>
    /// ИНН кассира.
    /// </summary>
    public string? CashierINN { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1192
    /// </para>
    /// Дополнительный реквизит чека
    /// </summary>
    public string? AdditionalCheckProps { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1020
    /// </para>
    /// Итоговая сумма чека в рублях с заданным в CMS округлением:<br />
    /// ㅤ*целая часть не более 8 знаков;<br />
    /// ㅤ*дробная часть не более 2 знаков.<br />
    /// Значение вычисляется, как сумма всех значений реквизита «стоимость предмета расчета с учетом скидок и наценок» (тег 1043)
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1084
    /// </para>
    /// Дополнительный реквизит пользователя.
    /// <seealso cref="Unofficial.AdditionalUserProps"/>
    /// </summary>
    public AdditionalUserProps? AdditionalUserProps { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1270
    /// </para>
    /// Условия применения и значение реквизита «операционный реквизит чека»  определяются ФНС России.
    /// <seealso cref="Unofficial.OperatingCheckProps"/>
    /// </summary>
    public OperatingCheckProps? OperatingCheckProps { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1261
    /// </para>
    /// Включается в состав кассового чека (БСО) в случае, если включение этого 
    /// отраслевого реквизита кассового чека предусмотрено законодательством Российской Федерации.
    /// <seealso cref="Unofficial.SectoralItemProps"/>
    /// </summary>
    public IReadOnlyCollection<SectoralItemProps>? SectoralCheckProps { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1036
    /// </para>
    /// <para>
    /// Заводской номер автоматического устройства для расчетов.
    /// </para>
    /// От 1 до 20 символов
    /// <para>
    /// В случае, если параметр не будет передан, в чеке будет указан
    /// внутренний номер кассы в сервисе АТОЛ Онлайн
    /// </para>
    /// </summary>
    public string? DeviceNumber { get; set; }

    /// <summary>
    /// <para>
    /// Тэг: 1125
    /// </para>
    /// <para>
    /// Признак применения ККТ при осуществлении расчета в безналичном  порядке в сети «Интернет» 
    /// </para>
    /// </summary>
    public bool? Internet { get; set; }

    /// <summary>
    /// <para>
    /// Тэг: 1011
    /// </para>
    /// <para>
    /// Номер часовой зоны места (адреса) осуществления расчетов в соответствии с законодательством Российской Федерации Целое число от 1 до 11
    /// </para>
    /// <para>По сути <value>часовой поясовой</value>-1, т.пе. для Москвы - 2 (3-1=2), для Екатеринбурга - 4 (5-1=4) :facepalm:</para>
    /// </summary>
    public int? Timezone { get; set; }

    /// <summary>
    /// <para>
    /// Тэг: 1235
    /// </para>
    /// <para>
    /// Сведения об оплате в безналичном порядке суммы расчета, указанной в кассовом чеке(БСО), способом, признак которого указан в этом реквизите
    /// <seealso cref="СashlessPayment"/>
    /// </para>
    /// </summary>
    public IReadOnlyCollection<СashlessPayment>? CashlessPayments { get; set; }
}
