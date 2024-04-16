namespace AtolOnline.Unofficial.Shared;

/// <summary>
/// Настройки тестовой среды
/// </summary>
public class TestEnvParams
{
    /// <summary>
    /// Базовый адрес
    /// </summary>
    public string BaseAddress { get; }

    /// <summary>
    /// Адрес совершения платежа
    /// </summary>
    public string PaymentAddress { get; }

    /// <summary>
    /// Название компании
    /// </summary>
    public string CompanyName { get; }

    /// <summary>
    /// ИНН компании
    /// </summary>
    public string INN { get; }

    /// <summary>
    /// Код группы касс
    /// </summary>
    public string Group { get; }

    /// <summary>
    /// Логин 
    /// </summary>
    public string Login { get; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; }

    /// <summary>
    /// Проверка чека в Первый ОФД
    /// <![CDATA[
    ///  https://consumer.1-ofd-test.ru/v1?fn=9999078902010421&fp=2680485228&i=1545
    /// ]]>
    /// где
    /// fn = Номер ФН - "fn_number"
    /// fp=ФПД - "fiscal_document_attribute"
    /// i=Номер ФД - "fiscal_document_number"
    /// </summary>
    public string EndpointOFD => "https://consumer.1-ofd-test.ru/v1";

    /// <summary>
    /// Настройки для V4, ФФД 1.0.5
    /// </summary>
    public static readonly TestEnvParams V4 = new
    (
        "https://testonline.atol.ru/possystem/v4/",
        "https://v4.online.atol.ru",
        "АТОЛ",
        "5544332219",
        "v4-online-atol-ru_4179",
        "v4-online-atol-ru",
        "iGFFuihss"
    );

    /// <summary>
    /// Настройки для V5, ФФД 1.2.0
    /// </summary>
    public static readonly TestEnvParams V5 = new
    (
        "https://testonline.atol.ru/possystem/v5/",
        "https://v4.online.atol.ru",
        "АТОЛ",
        "5544332219",
        "v5-online-atol-ru_5179",
        "v5-online-atol-ru",
        "zUr0OxfI"
    );

    TestEnvParams(string endpoint, string paymentAddress, string companyName, string iNN, string group, string login, string password)
    {
        BaseAddress = endpoint;
        PaymentAddress = paymentAddress;
        CompanyName = companyName;
        INN = iNN;
        Group = group;
        Login = login;
        Password = password;
    }

    /// <summary>
    /// Возвращает <see cref="BaseAddress"/>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return BaseAddress;
    }
}
