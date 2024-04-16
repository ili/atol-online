using AtolOnline.V5.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.V5.Entities;

/// <summary>
/// Атрибуты налога на позицию.
/// </summary>
public class Vat
{
    public Vat(VatTypes type, decimal? sum = null)
    {
        Type = type;
        Sum = sum;
    }

    /// <summary>
    /// Устанавливает номер налога в ККТ
    /// <para>Enum -> PaymentMethods</para>
    /// </summary>
    [Required]
    public VatTypes Type { get; set; }

    /// <summary>
    /// Сумма налога позиции в рублях:<br />
    /// ㅤ*целая часть не более 8 знаков<br />
    /// ㅤ*дробная часть не более 2 знаков
    /// </summary>
    public decimal? Sum { get; set; }
}
