namespace AtolOnline.Unofficial;

/// <summary>
/// Ошибка
/// </summary>
public class Error
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="errorId"><inheritdoc cref="ErrorId" path="/summary" /></param>
    /// <param name="code"><inheritdoc cref="Code" path="/summary" /></param>
    /// <param name="text"><inheritdoc cref="Text" path="/summary" /></param>
    /// <param name="type"><inheritdoc cref="Type" path="/summary" /></param>
    public Error(string errorId, int code, string text, string type)
    {
        ErrorId = errorId;
        Code = code;
        Text = text;
        Type = type;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public string ErrorId { get; }

    /// <summary>
    /// Код
    /// </summary>
    public int Code { get; }

    /// <summary>
    /// Текст
    /// </summary>
    public string Text { get; }

    /// <summary>
    /// Тип
    /// </summary>
    public string Type { get; }
}