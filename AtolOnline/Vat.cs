using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.Unofficial;

/// <summary>
/// Атрибуты налога на позицию.
/// </summary>
public class Vat
{
    public static readonly Vat None = new Vat(VatType.None);
    public static readonly Vat Vat0 = new Vat(VatType.Vat0);
    public static readonly Vat Vat10 = new Vat(VatType.Vat10);
    public static readonly Vat Vat110 = new Vat(VatType.Vat110);
    public static readonly Vat Vat20 = new Vat(VatType.Vat20);
    public static readonly Vat Vat120 = new Vat(VatType.Vat120);

    public Vat(VatType type, decimal? sum = null)
    {
        Type = type;
        Sum = sum;
    }

    /// <summary>
    /// Устанавливает номер налога в ККТ
    /// <para>Enum -> PaymentMethods</para>
    /// </summary>
    [Required]
    public VatType Type { get; set; }

    /// <summary>
    /// Сумма налога позиции в рублях:<br />
    /// ㅤ*целая часть не более 8 знаков<br />
    /// ㅤ*дробная часть не более 2 знаков
    /// </summary>
    public decimal? Sum { get; set; }
}
