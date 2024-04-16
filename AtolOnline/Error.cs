namespace AtolOnline.Unofficial;

public class Error
{
    public Error(string errorId, int code, string text, string type)
    {
        ErrorId = errorId;
        Code = code;
        Text = text;
        Type = type;
    }

    public string ErrorId { get; }

    public int Code { get; }

    public string Text { get; }

    public string Type { get; }
}