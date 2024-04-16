using Newtonsoft.Json;

namespace AtolOnline;

public class Payment
{
    public static Payment Cash(decimal sum) => new Payment(PaymentType.Cash, sum);
    public static Payment Cashless(decimal sum) => new Payment(PaymentType.Cashless, sum);
    public static Payment Prepayment(decimal sum) => new Payment(PaymentType.Prepayment, sum);
    public static Payment Postpaid(decimal sum) => new Payment(PaymentType.Postpaid, sum);
    public static Payment Other(decimal sum) => new Payment(PaymentType.Other, sum);
    public static Payment Extended5(decimal sum) => new Payment(PaymentType.Extended5, sum);
    public static Payment Extended6(decimal sum) => new Payment(PaymentType.Extended6, sum);
    public static Payment Extended7(decimal sum) => new Payment(PaymentType.Extended7, sum);
    public static Payment Extended8(decimal sum) => new Payment(PaymentType.Extended8, sum);
    public static Payment Extended9(decimal sum) => new Payment(PaymentType.Extended9, sum);

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
