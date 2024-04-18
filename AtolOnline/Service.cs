namespace AtolOnline.Unofficial;

/// <summary>
/// 
/// </summary>
public class Service
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="callbackUrl"><inheritdoc cref="CallbackUrl" path="/summary" /></param>
    public Service(string? callbackUrl = null)
    {
        CallbackUrl = callbackUrl;
    }

    /// <summary>
    /// URL, на который необходимо ответить после обработки документа.
    /// </summary>
    public string? CallbackUrl { get; set; }
}
