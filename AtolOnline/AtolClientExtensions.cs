namespace AtolOnline.Unofficial;

/// <summary>
/// Хелперы для <see cref="AtolClient"/> и <see cref="StateAtolClient"/>
/// </summary>
public static class AtolClientExtensions
{
    /// <summary>
    /// СОздает <see cref="StateAtolClient"/> с заданными параметрами
    /// </summary>
    /// <param name="client"></param>
    /// <param name="login">Логин по умолчанию</param>
    /// <param name="password">Пароль по умолчанию</param>
    /// <param name="groupCode">Идентификатор группы ККТ по умолчанию</param>
    /// <param name="source">Название интегратора (необязательный параметр). Наименование интегратора через которого осуществляется отправка запросов.Максимальная длина строки – 100 символов</param>
    /// <param name="token">Токен авторизации по умолчанию</param>
    /// <returns></returns>
    public static StateAtolClient WithState(this AtolClient client, 
        string? login = null, 
        string? password = null, 
        string? groupCode = null,
        string? source = null,
        string? token = null
        )
        => new StateAtolClient(client, login, password, source, groupCode, token);

    /// <summary>
    /// Регистрация документа: Приход
    /// <seealso cref="AtolClient.OperationAsync(string, ReceiptRequest, string, string)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    public static Task<OperationResponse> SellAsync(this AtolClient client, ReceiptRequest request, string groupCode, string token)
        => client.OperationAsync("sell", request, groupCode, token);
    
    
    /// <summary>
    /// Регистрация документа: Приход
    /// <seealso cref="StateAtolClient.OperationAsync(string, ReceiptRequest, string?, string?)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="StateAtolClient.GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public static Task<OperationResponse> SellAsync(this StateAtolClient client, ReceiptRequest request, string? groupCode = null, string? token = null)
        => client.OperationAsync("sell", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Возврат прихода
    /// <seealso cref="AtolClient.OperationAsync(string, ReceiptRequest, string, string)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    public static Task<OperationResponse> SellRefundAsync(this AtolClient client, ReceiptRequest request, string groupCode, string token)
        => client.OperationAsync("sell_refund", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Возврат прихода
    /// <seealso cref="StateAtolClient.OperationAsync(string, ReceiptRequest, string?, string?)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="StateAtolClient.GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public static Task<OperationResponse> SellRefundAsync(this StateAtolClient client, ReceiptRequest request, string? groupCode = null, string? token = null)
        => client.OperationAsync("sell_refund", request, groupCode, token);


    /// <summary>
    /// Регистрация документа: Расход
    /// <seealso cref="AtolClient.OperationAsync(string, ReceiptRequest, string, string)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    public static Task<OperationResponse> Buy(this AtolClient client, ReceiptRequest request, string groupCode, string token)
        => client.OperationAsync("buy", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Расход
    /// <seealso cref="StateAtolClient.OperationAsync(string, ReceiptRequest, string?, string?)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="StateAtolClient.GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public static Task<OperationResponse> Buy(this StateAtolClient client, ReceiptRequest request, string? groupCode = null, string? token = null)
        => client.OperationAsync("buy", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Возврат расхода
    /// <seealso cref="AtolClient.OperationAsync(string, ReceiptRequest, string, string)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    public static Task<OperationResponse> BuyRefund(this AtolClient client, ReceiptRequest request, string groupCode, string token)
        => client.OperationAsync("buy_refund", request, groupCode, token);


    /// <summary>
    /// Регистрация документа: Возврат расхода
    /// <seealso cref="StateAtolClient.OperationAsync(string, ReceiptRequest, string?, string?)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="StateAtolClient.GetTokenAsync(string?, string?, string?)"/></param>
    public static Task<OperationResponse> BuyRefund(this StateAtolClient client, ReceiptRequest request, string? groupCode = null, string? token = null)
        => client.OperationAsync("buy_refund", request, groupCode, token);


    /// <summary>
    /// Регистрация документа: Коррекция прихода
    /// <seealso cref="AtolClient.CorrectionAsync(string, CorrectionRequest, string?, string?)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    public static Task<OperationResponse> SellCorrection(this AtolClient client, CorrectionRequest request, string groupCode, string token)
        => client.CorrectionAsync("sell_correction", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция прихода
    /// <seealso cref="StateAtolClient.CorrectionAsync(string, CorrectionRequest, string?, string?)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="StateAtolClient.GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public static Task<OperationResponse> SellCorrection(this StateAtolClient client, CorrectionRequest request, string? groupCode = null, string? token = null)
        => client.CorrectionAsync("sell_correction", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция расхода
    /// <seealso cref="AtolClient.CorrectionAsync(string, CorrectionRequest, string, string)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    public static Task<OperationResponse> BuyCorrection(this AtolClient client, CorrectionRequest request, string groupCode, string token)
        => client.CorrectionAsync("buy_correction", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция расхода
    /// <seealso cref="StateAtolClient.CorrectionAsync(string, CorrectionRequest, string?, string?)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="StateAtolClient.GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public static Task<OperationResponse> BuyCorrection(this StateAtolClient client, CorrectionRequest request, string? groupCode = null, string? token = null)
        => client.CorrectionAsync("buy_correction", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция возврата прихода
    /// <seealso cref="AtolClient.CorrectionAsync(string, CorrectionRequest, string, string)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    public static Task<OperationResponse> SellRefundCorrection(this AtolClient client, CorrectionRequest request, string groupCode, string token)
        => client.CorrectionAsync("sell_refund_correction", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция возврата прихода
    /// <seealso cref="StateAtolClient.CorrectionAsync(string, CorrectionRequest, string?, string?)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="StateAtolClient.GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public static Task<OperationResponse> SellRefundCorrection(this StateAtolClient client, CorrectionRequest request, string? groupCode = null, string? token = null)
        => client.CorrectionAsync("sell_refund_correction", request, groupCode, token);


    /// <summary>
    /// Регистрация документа: Коррекция возврата расхода
    /// <seealso cref="AtolClient.CorrectionAsync(string, CorrectionRequest, string, string)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ</param>
    /// <param name="token">Токен авторизации</param>
    /// <returns></returns>
    public static Task<OperationResponse> BuyRefundCorrection(this AtolClient client, CorrectionRequest request, string groupCode, string token)
        => client.CorrectionAsync("buy_refund_correction", request, groupCode, token);

    /// <summary>
    /// Регистрация документа: Коррекция возврата расхода
    /// <seealso cref="StateAtolClient.CorrectionAsync(string, CorrectionRequest, string?, string?)"/>
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="request">запрос для чеков коррекции расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="StateAtolClient.GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    public static Task<OperationResponse> BuyRefundCorrection(this StateAtolClient client, CorrectionRequest request, string? groupCode = null, string? token = null)
        => client.CorrectionAsync("buy_refund_correction", request, groupCode, token);
}