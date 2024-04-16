using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Ответ с токеном авторизации
/// </summary>
public class TokenResponse : ResponseBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="status"><inheritdoc cref="ResponseBase.Status" path="/summary" /></param>
    /// <param name="error"><inheritdoc cref="ResponseBase.Error" path="/summary" /></param>
    /// <param name="token"><inheritdoc cref="Token" path="/summary" /></param>
    /// <param name="timestamp"><inheritdoc cref="ResponseBase.Timestamp" path="/summary" /></param>
    [JsonConstructor]
    public TokenResponse(string? status, Error? error, string? token, DateTime timestamp)
        : base(error, status, timestamp)
    {
        Token = token;
    }

    /// <summary>
    /// Токен авторизации
    /// </summary>
    public string? Token { get; }
}
