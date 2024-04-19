using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace AtolOnline.Unofficial;

/// <summary>
/// Хелпер с сохранением состояния
/// <para>
/// Не рекомендуется использовать в многопоточной среде
/// </para>
/// </summary>
public class StateAtolClient
{
    private AtolClient _client;
    private string? _login;
    private string? _password;
    private string? _source;
    private string? _grouopCode;

    /// <summary>
    /// Токен авторизации
    /// </summary>
    public string? Token {  get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="client"></param>
    /// <param name="login">Логин по умолчанию</param>
    /// <param name="password">Пароль по умолчанию</param>
    /// <param name="groupCode">Идентификатор группы ККТ по умолчанию</param>
    /// <param name="source">Название интегратора (необязательный параметр). Наименование интегратора через которого осуществляется отправка запросов.Максимальная длина строки – 100 символов</param>
    /// <param name="token">Токен авторизации по умолчанию</param>
    public StateAtolClient(
        AtolClient client,
        string? login = null,
        string? password = null, 
        string? groupCode = null,
        string? source = null,
        string? token = null
        )
    {
        _client = client;
        _login = login;
        _password = password;
        Token = token;
        _source = source;
        _grouopCode = groupCode;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="httpClient">Клиетн для выполнения запросов</param>
    /// <param name="login">Логин по умолчанию</param>
    /// <param name="password">Пароль по умолчанию</param>
    /// <param name="groupCode">Идентификатор группы ККТ по умолчанию</param>
    /// <param name="source">Название интегратора (необязательный параметр). Наименование интегратора через которого осуществляется отправка запросов.Максимальная длина строки – 100 символов</param>
    /// <param name="token">Токен авторизации по умолчанию</param>
    /// <param name="baseAddress">Базовый адрес сервера
    /// <para>
    /// По умолчанию <value>https://online.atol.ru/possystem/v5</value>
    /// </para>
    /// </param>
    /// <param name="v4">Признак использования V4 ФФД 1.05
    /// <para>
    /// По умолчанию определяется из <paramref name="baseAddress"/>
    /// </para>
    /// </param>
    public StateAtolClient(HttpClient httpClient, 
        string? login = null, 
        string? password = null, 
        string? groupCode = null, 
        string? source = null, 
        string? token = null,
        string? baseAddress = null,
        bool? v4 = null)
        : this(new AtolClient(httpClient, baseAddress, v4),
              login, 
              password,
              groupCode,
              source,
              token
              )
    {
    }

    private static string Value(string? a, string? b, string text)
      => a ?? b ?? throw new ArgumentNullException(text);

    private async Task CheckAuthAsync(string? token)
    {
        var tk = token ?? Token;
        if (string.IsNullOrEmpty(tk)
            && !string.IsNullOrEmpty(_login)
            && !string.IsNullOrEmpty(_password))
            await GetTokenAsync();
    }


    /// <summary>
    /// Получение токена авторизации, после вызова метода токен сохраняется и будет использован как токен для авторизации по умолчанию
    /// </summary>
    /// <param name="login">Логин, если не передан используется значение, переданное в конструктор</param>
    /// <param name="password">Пороль, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="source">Название интегратора (необязательный параметр). Наименование интегратора через которого осуществляется отправка запросов.Максимальная длина строки – 100 символов, если не передан, используется значение, переданное в конструктор</param>
    /// <returns><see cref="StateAtolClient"/></returns>
    public async Task<StateAtolClient> GetTokenAsync(string? login = null, string? password = null, string? source = null)
    {
        var res = await _client.GetTokenAsync(
            Value(login, _login, nameof(login)),
            Value(password, _password, nameof(password)),
            source ?? _source
        );

        Token = res.Token;

        return this;
    }

    /// <summary>
    /// Регистрация документа
    /// </summary>
    /// <param name="operation">тип операции на регистрацию чека, которая должна быть выполнена</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string, string, string)"/></param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public async Task<OperationResponse> OperationAsync(string operation, ReceiptRequest request, string? groupCode = null, string? token = null)
    {
        await CheckAuthAsync(token);

        return await _client.OperationAsync(operation,
            request,
            Value(groupCode, _grouopCode, nameof(groupCode)),
            Value(token, Token, nameof(token))
        );
    }


    /// <summary>
    /// Коррекция документа
    /// </summary>
    /// <param name="operation">тип операции на регистрацию чека, которая должна быть выполнена</param>
    /// <param name="request">запрос для чеков расхода, прихода, возврат расхода и возврат прихода</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public async Task<OperationResponse> CorrectionAsync(string operation, CorrectionRequest request, string? groupCode = null, string? token = null)
    {
        await CheckAuthAsync(token);

        return await _client.CorrectionAsync(operation,
            request,
            Value(groupCode, _grouopCode, nameof(groupCode)),
            Value(token, Token, nameof(token))
        );

    }

    /// <summary>
    /// Получение состояния документа
    /// </summary>
    /// <param name="uuid">Уникальный идентификатор чека, полученный прсле его отправки</param>
    /// <param name="groupCode">Идентификатор группы ККТ, если не передан, используется значение, переданное в конструктор</param>
    /// <param name="token">Токен авторизации, если не передан, используеьтся значение, переданное в констуктор, или сохраненное при вызове <see cref="GetTokenAsync(string?, string?, string?)"/></param>
    /// <returns></returns>
    /// <exception cref="AtolClientException"></exception>
    public async Task<ReportResponse> ReportAsync(string uuid, string? groupCode = null, string? token = null)
    {
        await CheckAuthAsync(token);

        return await _client.ReportAsync(uuid,
            Value(groupCode, _grouopCode, nameof(groupCode)),
            Value(token, Token, nameof(token))
        );
    }

}
