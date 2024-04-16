using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Оплата
/// </summary>
public class Payment
{
    /// <summary>
    /// <inheritdoc cref="PaymentType.Cash" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Cash(decimal sum) => new Payment(PaymentType.Cash, sum);
    
    /// <summary>
    /// <inheritdoc cref="PaymentType.Cashless" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Cashless(decimal sum) => new Payment(PaymentType.Cashless, sum);

    /// <summary>
    /// <inheritdoc cref="PaymentType.Prepayment" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Prepayment(decimal sum) => new Payment(PaymentType.Prepayment, sum);

    /// <summary>
    /// <inheritdoc cref="PaymentType.Postpaid" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Postpaid(decimal sum) => new Payment(PaymentType.Postpaid, sum);

    /// <summary>
    /// <inheritdoc cref="PaymentType.Other" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Other(decimal sum) => new Payment(PaymentType.Other, sum);

    /// <summary>
    /// <inheritdoc cref="PaymentType.Extended5" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Extended5(decimal sum) => new Payment(PaymentType.Extended5, sum);

    /// <summary>
    /// <inheritdoc cref="PaymentType.Extended6" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Extended6(decimal sum) => new Payment(PaymentType.Extended6, sum);

    /// <summary>
    /// <inheritdoc cref="PaymentType.Extended7" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Extended7(decimal sum) => new Payment(PaymentType.Extended7, sum);

    /// <summary>
    /// <inheritdoc cref="PaymentType.Extended8" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Extended8(decimal sum) => new Payment(PaymentType.Extended8, sum);

    /// <summary>
    /// <inheritdoc cref="PaymentType.Extended9" path="/summary" />
    /// </summary>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
    /// <returns></returns>
    public static Payment Extended9(decimal sum) => new Payment(PaymentType.Extended9, sum);

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="type"><inheritdoc cref="Type" path="/summary" /></param>
    /// <param name="sum"><inheritdoc cref="Sum" path="/summary" /></param>
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
