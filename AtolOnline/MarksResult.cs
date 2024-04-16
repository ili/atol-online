using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Информации о проверке кодов маркировки
/// </summary>
public class MarksResult
{
    [JsonConstructor]
    public MarksResult(int position, string markCode, int result)
    {
        Position = position;
        MarkCode = markCode;
        Result = result;
    }

    /// <summary>
    /// Номер позиции предмета расчета в исходном чеке, для которого был указан 
    /// код маркировки, <b>начиная с 0</b>
    /// </summary>
    public int Position { get; }

    /// <summary>
    /// КМ, переданный в исходном чеке
    /// </summary>
    public string MarkCode {  get; }

    /// <summary>
    /// Значение результата проверки сведений о товаре для данной позиции
    /// </summary>
    /// <remarks>
    /// Тег: 2106
    /// </remarks>
    public int Result {  get; }
}