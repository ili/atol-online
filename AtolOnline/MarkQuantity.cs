using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

public class MarkQuantity
{
    /// <summary>
    /// Числитель дробной части предмета расчета
    /// <para>
    ///     Значение реквизита «числитель» (тег 1293) должно быть строго меньше значения реквизита «знаменатель не может равняться «0»
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1293 
    /// </remarks>
    public int Numerator { get; set; }

    /// <summary>
    /// Знаменатель дробной части предмета расчета
    /// <para>
    ///     Знаменатель дробной части предмета расчета Заполняется значением, равным количеству 
    ///     товара в партии (упаковке), имеющей общий код маркировки товара. не может равняться «0»
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1294
    /// </remarks>
    public int Denominator { get; set; }
}
