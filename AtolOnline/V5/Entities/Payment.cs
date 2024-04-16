using AtolOnline.V5.Enums;
using Newtonsoft.Json;

namespace AtolOnline.V5.Entities;

public class Payment
{
    [JsonConstructor]
    public Payment(PaymentType type, decimal sum)
    {
        Type = type;
        Sum = sum;
    }

    /// <summary>
    /// Вид оплаты
    /// </summary>
    public PaymentType Type { get; }

    /// <summary>
    /// Сумма к оплате в рублях:<br />
    /// ㅤ*целая часть не более 8 знаков<br />
    /// ㅤ*дробная часть не более 2 знаков
    /// </summary>
    public decimal Sum { get; }
}
