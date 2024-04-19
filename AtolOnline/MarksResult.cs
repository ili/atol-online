using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Информации о проверке кодов маркировки
/// </summary>
public class MarksResult
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="position"><inheritdoc cref="Position" path="/summary" /></param>
    /// <param name="markCode"><inheritdoc cref="MarkCode" path="/summary" /></param>
    /// <param name="result"><inheritdoc cref="Result" path="/summary" /></param>
    [JsonConstructor]
    public MarksResult(uint position, string markCode, uint result)
    {
        Position = position;
        MarkCode = markCode;
        Result = result;
    }

    /// <summary>
    /// Номер позиции предмета расчета в исходном чеке, для которого был указан 
    /// код маркировки, <b>начиная с 0</b>
    /// </summary>
    public uint Position { get; }

    /// <summary>
    /// КМ, переданный в исходном чеке
    /// </summary>
    public string MarkCode {  get; }

    /// <summary>
    /// <para>
    /// Тег: 2106
    /// </para>
    /// Значение результата проверки сведений о товаре для данной позиции
    /// </summary>
    public uint Result {  get; }
}