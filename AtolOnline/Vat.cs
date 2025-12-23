using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Атрибуты налога на позицию.
/// </summary>
public class Vat
{
    /// <summary>
    /// <inheritdoc cref="VatType.None" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat None(decimal? sum = null) => new Vat(VatType.None, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat0" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat0(decimal? sum = null) => new Vat(VatType.Vat0, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat10" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat10(decimal? sum = null) => new Vat(VatType.Vat10, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat110" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat110(decimal? sum = null) => new Vat(VatType.Vat110, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat20" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat20(decimal? sum = null) => new Vat(VatType.Vat20, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat120" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat120(decimal? sum = null) => new Vat(VatType.Vat120, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat5" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat5(decimal? sum = null) => new Vat(VatType.Vat5, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat105" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat105(decimal? sum = null) => new Vat(VatType.Vat105, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat7" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat7(decimal? sum = null) => new Vat(VatType.Vat7, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat107" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat107(decimal? sum = null) => new Vat(VatType.Vat107, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat22" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat22(decimal? sum = null) => new Vat(VatType.Vat22, sum);

    /// <summary>
    /// <inheritdoc cref="VatType.Vat122" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Vat Vat122(decimal? sum = null) => new Vat(VatType.Vat122, sum);

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="type"><inheritdoc cref="Type" path="/summary" /></param>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    public Vat(VatType type, decimal? sum = null)
    {
        Type = type;
        Sum = sum;
    }

    /// <summary>
    /// Устанавливает номер налога в ККТ
    /// <para>Enum -> PaymentMethods</para>
    /// </summary>
    public VatType Type { get; set; }

    /// <summary>
    /// Сумма налога позиции в рублях:<br />
    /// ㅤ*целая часть не более 8 знаков<br />
    /// ㅤ*дробная часть не более 2 знаков
    /// </summary>
    public decimal? Sum { get; set; }
}
