using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Предмет расчета
/// </summary>
public class Item
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary" /></param>
    /// <param name="price"><inheritdoc cref="Price" path="/summary" /></param>
    /// <param name="quantity"><inheritdoc cref="Quantity" path="/summary" /></param>
    /// <param name="measure"><inheritdoc cref="Measure" path="/summary" /></param>
    /// <param name="paymentMethod"><inheritdoc cref="PaymentMethod" path="/summary" /></param>
    /// <param name="paymentObject"><inheritdoc cref="PaymentObject" path="/summary" /></param>
    /// <param name="vat"><inheritdoc cref="Vat" path="/summary" /></param>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <param name="userData"><inheritdoc cref="UserData" path="/summary" /></param>
    /// <param name="excise"><inheritdoc cref="Excise" path="/summary" /></param>
    /// <param name="countryCode"><inheritdoc cref="CountryCode" path="/summary" /></param>
    /// <param name="declarationNumber"><inheritdoc cref="DeclarationNumber" path="/summary" /></param>
    /// <param name="markQuantity"><inheritdoc cref="MarkQuantity" path="/summary" /></param>
    /// <param name="markProcessingMode"><inheritdoc cref="MarkProcessingMode" path="/summary" /></param>
    /// <param name="sectoralItemProps"><inheritdoc cref="SectoralItemProps" path="/summary" /></param>
    /// <param name="markCode"><inheritdoc cref="MarkCode" path="/summary" /></param>
    /// <param name="agentInfo"><inheritdoc cref="AgentInfo" path="/summary" /></param>
    /// <param name="supplierInfo"><inheritdoc cref="SupplierInfo" path="/summary" /></param>
    /// <param name="measurementUnit"><inheritdoc cref="MeasurementUnit" path="/summary" /></param>
    /// <param name="nomenclatureCode"><inheritdoc cref="NomenclatureCode" path="/summary" /></param>
    public Item(
        string name,
        decimal price,
        decimal quantity,
        Measurement measure,
        PaymentMethod paymentMethod,
        uint paymentObject,
        Vat vat,
        decimal? sum = null,
        string? userData = null,
        decimal? excise = null,
        string? countryCode = null,
        string? declarationNumber = null,
        MarkQuantity? markQuantity = null,
        string? markProcessingMode = null,
        IReadOnlyCollection<SectoralItemProps>? sectoralItemProps = null,
        MarkCode? markCode = null,
        AgentInfo? agentInfo = null,
        SupplierInfo? supplierInfo = null,
        string? measurementUnit = null,
        string? nomenclatureCode = null
        )
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        MeasurementUnit = measurementUnit;
        NomenclatureCode = nomenclatureCode;
        Measure = measure;
        Sum = sum ?? price * quantity;
        PaymentMethod = paymentMethod;
        PaymentObject = paymentObject;
        Vat = vat;
        UserData = userData;
        Excise = excise;
        CountryCode = countryCode;
        DeclarationNumber = declarationNumber;
        MarkQuantity = markQuantity;
        MarkProcessingMode = markProcessingMode;
        SectoralItemProps = sectoralItemProps;
        MarkCode = markCode;
        AgentInfo = agentInfo;
        SupplierInfo = supplierInfo;
    }

    /// <summary>
    /// <para>
    /// Тег: 1030 
    /// </para>
    /// Наименование товара, работы, услуги, платежа, выплаты, иного предмета расчета.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// <para>
    /// Тег: 1079 
    /// </para>
    /// Цена за единицу товара, работы, услуги, платежа, выплаты, иного предмета расчета с учетом скидок и наценок
    /// <para>Цена в рублях:</para>
    /// <para>* целая часть не более 8 знаков</para>
    /// <para>* дробная часть не более 2 знаков</para>
    /// <para>Максимальное значение цены – 42 949 672.95.</para>
    /// <para>При этом произведение цены и количество/веса (price*quantity) позиции должно быть не больше максимального значения цены позиции.</para>
    /// </summary>
    public decimal Price { get; }


    /// <summary>
    /// <para>
    /// Тег: 1023 
    /// </para>
    /// Количество/вес:
    /// <para>целая часть не более 5 знаков</para>
    /// <para>дробная часть не более 3 знаков</para>
    /// <para>Максимальное значение – 99 999.999</para>
    /// <para>В случае, если предметом расчета является товар, подлежащий обязательной маркировке средством идентификации (передан mark_code), параметр должен принимать значение, равное «1».</para>
    /// </summary>
    public decimal Quantity { get; }


    /// <summary>
    /// <para>
    /// V4
    /// Тег: 1197 
    /// </para>
    /// Единица измерения товара, работы, услуги, платежа, 
    /// выплаты, иного предмета расчета.Максимальная
    /// длина строки – 16 символов
    /// </summary>
    public string? MeasurementUnit { get; set; }

    /// <summary>
    /// <para>
    /// V4
    /// Тег: 1162 
    /// </para>
    /// Код товара в шестнадцатеричном представлении с пробелами.
    /// Максимальная длина – 32 байта.
    /// <code>
    /// Пример: 00 00 00 01 00 21 FA 41 00 23 05 41 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 12 00 AB 00
    /// </code>
    /// <para>
    /// Возможно напрямую передавать код товара, 
    /// считанный с маркированного товара, в формате GS1
    /// Data Matrix.
    /// В таком случае сервис сам преобразует значение в
    /// необходимый шестнадцатеричный вид.
    /// Максимальная длина – 150 символов
    /// </para>
    /// <code>
    /// Пример кода товара в формате GS1: 010463003407001221CMK45BrhN0WLf
    /// </code>
    /// </summary>
    public string? NomenclatureCode { get; set; }

    /// <summary>
    /// <para>
    /// V5
    /// Тег: 2108 
    /// </para>
    /// Единицы измерения количества предмета расчета
    /// </summary>
    public Measurement Measure { get; set; } = Measurement.Quantity;

    /// <summary>
    /// <para>
    /// Тег: 1043 
    /// </para>
    /// Сумма в рублях:<br />
    /// ㅤ*целая часть не более 8 знаков<br />
    /// ㅤ*дробная часть не более 2 знаков
    /// <para>Максимальное значение – 42 949 672.95.</para>
    /// <para>Значение реквизита «стоимость предмета расчета с учетом скидок и наценок» 
    /// (тег 1043) должно быть равно произведению 
    /// значения реквизита «цена за единицу предмета расчета с учетом скидок и наценок» 
    /// (тег 1079), умноженному на значение реквизита «количество предмета расчета» (тег 1023).
    /// </para>
    /// </summary>
    public decimal Sum { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1214 
    /// </para>
    /// <para>Признак способа расчёта.</para>
    /// </summary>
    public PaymentMethod PaymentMethod { get; }

    /// <summary>
    /// <para>
    /// Тег: 1212 
    /// </para>
    /// Признак предмета расчёта
    /// <para>
    /// https://www.consultant.ru/document/cons_doc_LAW_362322/cc1e361ee41688e67fe65c4740a242a10c265c86/
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <term>1</term>
    /// <description>
    /// о реализуемом товаре, за исключением подакцизного товара и товара, 
    /// подлежащего маркировке средствами идентификации (наименование и иные сведения, описывающие товар)
    /// </description>
    /// </item>
    /// 
    /// <item>
    /// <term>2</term>
    /// <description>
    /// о реализуемом подакцизном товаре, за исключением товара, 
    /// подлежащего маркировке средствами идентификации (наименование и иные сведения, описывающие товар)
    /// </description>
    /// </item>
    /// 
    /// <item><term>3</term>
    /// <description>
    /// о выполняемой работе (наименование и иные сведения, описывающие работу)
    /// </description>
    /// </item>
    /// 
    /// <item><term>4</term>
    /// <description>
    /// об оказываемой услуге (наименование и иные сведения, описывающие услугу)
    /// </description>
    /// </item>
    /// 
    /// <item><term>5</term>
    /// <description>
    /// о приеме ставок при осуществлении деятельности по проведению азартных игр
    /// </description>
    /// </item>
    /// 
    /// <item><term>6</term>
    /// <description>
    /// о выплате денежных средств в виде выигрыша при осуществлении деятельности по проведению азартных игр
    /// </description>
    /// </item>
    /// 
    /// <item><term>7</term>
    /// <description>
    /// о приеме денежных средств при реализации лотерейных билетов, 
    /// электронных лотерейных билетов, приеме лотерейных ставок 
    /// при осуществлении деятельности по проведению лотерей
    /// </description>
    /// </item>
    /// 
    /// <item><term>8</term>
    /// <description>
    /// о выплате денежных средств в виде выигрыша при осуществлении деятельности по проведению лотерей
    /// </description>
    /// </item>
    /// 
    /// <item><term>9</term>
    /// <description>
    /// о предоставлении прав на использование результатов 
    /// интеллектуальной деятельности или средств индивидуализации
    /// </description>
    /// </item>
    /// 
    /// <item><term>10</term>
    /// <description>
    /// об авансе, задатке, предоплате, кредит
    /// </description>
    /// </item>
    /// 
    /// <item><term>11</term>
    /// <description>
    /// о вознаграждении пользователя, являющегося платежным агентом(субагентом),
    /// банковским платежным агентом(субагентом), комиссионером, поверенным или иным агентом
    /// </description>
    /// </item>
    /// 
    /// <item><term>12</term>
    /// <description>
    /// о взносе в счет оплаты, пени, штрафе, вознаграждении, бонусе и ином аналогичном предмете расчета
    /// </description>
    /// </item>
    /// 
    /// <item><term>13</term>
    /// <description>
    /// о предмете расчета, не относящемуся к предметам расчета,
    /// которым может быть присвоено значение от «1» до «11» и от «14» до «26»
    /// </description>
    /// </item>
    /// 
    /// <item><term>14</term>
    /// <description>
    /// о передаче имущественных прав
    /// </description>
    /// </item>
    /// 
    /// <item><term>15</term>
    /// <description>
    /// о внереализационном доходе
    /// </description>
    /// </item>
    /// 
    /// <item><term>16</term>
    /// <description>
    /// о суммах расходов, платежей и взносов, указанных в подпунктах 2 и 3 пункта
    /// Налогового кодекса Российской Федерации, уменьшающих сумму налога
    /// </description>
    /// </item>
    /// 
    /// <item><term>17</term>
    /// <description>
    /// о суммах уплаченного торгового сбора
    /// </description>
    /// </item>
    /// 
    /// <item><term>18</term>
    /// <description>
    /// о курортном сборе
    /// </description>
    /// </item>
    /// 
    /// <item><term>19</term>
    /// <description>
    /// о залоге
    /// </description>
    /// </item>
    /// 
    /// <item><term>20</term>
    /// <description>
    /// о суммах произведенных расходов в соответствии со 
    /// статьей 346.16 Налогового кодекса Российской Федерации, уменьшающих доход
    /// </description>
    /// </item>
    /// 
    /// <item><term>21</term>
    /// <description>
    /// о страховых взносах на обязательное пенсионное страхование, 
    /// уплачиваемых ИП, не производящими выплаты и иные вознаграждения физическим лицам
    /// </description>
    /// </item>
    /// 
    /// <item><term>22</term>
    /// <description>
    /// о страховых взносах на обязательное пенсионное страхование, 
    /// уплачиваемых организациями и ИП, производящими выплаты и иные вознаграждения физическим лицам
    /// </description>
    /// </item>
    /// 
    /// <item><term>23</term>
    /// <description>
    /// о страховых взносах на обязательное медицинское страхование, 
    /// уплачиваемых ИП, не производящими выплаты и иные вознаграждения физическим лицам
    /// </description>
    /// </item>
    /// 
    /// <item><term>24</term>
    /// <description>
    /// о страховых взносах на обязательное медицинское страхование, 
    /// уплачиваемые организациями и ИП, производящими выплаты и иные вознаграждения физическим лицам
    /// </description>
    /// </item>
    /// 
    /// <item><term>25</term>
    /// <description>
    /// о страховых взносах на обязательное социальное страхование 
    /// на случай временной нетрудоспособности и в связи с материнством, 
    /// на обязательное социальное страхование от несчастных случаев 
    /// на производстве и профессиональных заболеваний
    /// </description>
    /// </item>
    /// 
    /// <item><term>26</term>
    /// <description>
    /// о приеме и выплате денежных средств при осуществлении казино 
    /// и залами игровых автоматов расчетов с использованием обменных знаков игорного заведения
    /// </description>
    /// </item>
    /// 
    /// <item><term>27</term>
    /// <description>
    /// о выдаче денежных средств банковским платежным агентом
    /// </description>
    /// </item>
    /// 
    /// <item><term>30</term>
    /// <description>
    /// о реализуемом подакцизном товаре, подлежащем маркировке средством идентификации, не имеющем кода маркировки
    /// </description>
    /// </item>
    /// 
    /// <item><term>31</term>
    /// <description>
    /// о реализуемом подакцизном товаре, подлежащем маркировке средством идентификации, имеющем код маркировки
    /// </description>
    /// </item>
    /// 
    /// <item><term>32</term>
    /// <description>
    /// о реализуемом товаре, подлежащем маркировке средством идентификации, 
    /// не имеющем кода маркировки, за исключением подакцизного товара
    /// </description>
    /// </item>
    /// 
    /// <item><term>33</term>
    /// <description>
    /// о реализуемом товаре, подлежащем маркировке средством идентификации, 
    /// имеющем код маркировки, за исключением подакцизного товара
    /// </description>
    /// </item>
    /// 
    /// </list>
    /// </summary>
    [JsonConverter(typeof(PaymentObjectJsonConverter))]
    public uint PaymentObject { get; }

    /// <summary>
    /// Атрибуты налога на позицию.
    /// </summary>
    public Vat Vat { get; }

    /// <summary>
    /// <para>
    /// Тег: 1191
    /// </para>
    /// Дополнительный реквизит предмета расчета.
    /// </summary>
    public string? UserData { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1229 
    /// </para>
    /// Сумма акциза в рублях<br />
    /// целая часть не более 8 знаков<br />
    /// дробная часть не более 2 знаков<br />
    /// значение не может быть отрицательным
    /// </summary>
    public decimal? Excise { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1230 
    /// </para>
    /// Цифровой код страны происхождения товара ровно 3 цифры
    /// Код страны указывается в соответствии с Общероссийским классификатором стран мира ОКСМ. 
    /// </summary>
    public string? CountryCode { get; set; }


    /// <summary>
    /// <para>
    /// Тег: 1231 
    /// </para>
    /// Номер таможенной декларации
    /// </summary>
    public string? DeclarationNumber { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1293, 1294 
    /// </para>
    /// Реквизит «дробное количество маркированного товара»
    /// </summary>
    public MarkQuantity? MarkQuantity { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1202 
    /// </para>
    /// Включается в чек в случае, если предметом расчета является товар, 
    /// подлежащий обязательной маркировке средством идентификации. Должен принимать значение равное «0»
    /// </summary>
    public string? MarkProcessingMode { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1260 
    /// </para>
    /// Отраслевой реквизит предмета расчета
    /// <para>
    /// Необходимо указывать, если в составе реквизита «предмет расчета» 
    /// (тег 1059) содержатся сведения о товаре, подлежащем обязательной
    /// маркировке средством идентификации и включение указанного
    /// реквизита предусмотрено НПА отраслевого регулирования для
    /// соответствующей товарной группы.
    /// </para>
    /// </summary>
    public IReadOnlyCollection<SectoralItemProps>? SectoralItemProps { get; set; }

    /// <summary>
    /// <para>
    /// Тег: 1163 
    /// </para>
    /// Код товара
    /// Включается в чек в случае, если предметом расчета является товар, подлежащий обязательной маркировке средством идентификации.
    /// <para>
    /// Хелпер: <see cref="MarkCode.New"/>
    /// </para>
    /// </summary>
    public MarkCode? MarkCode { get; set; }

    /// <summary>
    /// Атрибуты агента.
    /// </summary>
    public AgentInfo? AgentInfo { get; set; }


    /// <summary>
    /// Атрибуты поставщика.
    /// Поле обязательно, если передан «agent_info».
    /// </summary>
    public SupplierInfo? SupplierInfo { get; set; }
}
