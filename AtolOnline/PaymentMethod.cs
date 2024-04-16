﻿using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// <inheritdoc cref="Item.PaymentMethod" path="/summary" />
/// </summary>
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum PaymentMethod
{
    /// <summary>
    /// Предоплата 100%. Полная предварительная оплата до момента передачи предмета расчета
    /// </summary>
    FullPrepayment, // = "full_prepayment";

    /// <summary>
    /// Предоплата. Частичная предварительная оплата до момента передачи предмета расчета.
    /// </summary>
    Prepayment, // = "prepayment";

    /// <summary>
    /// Аванс
    /// </summary>
    Advance, // = "advance";

    /// <summary>
    /// Полный расчет. Полная оплата, в том числе с учетом аванса (предварительной оплаты) в момент передачи предмета расчета
    /// </summary>
    FullPayment, //= "full_payment";

    /// <summary>
    /// Частичный расчет и кредит. Частичная оплата предмета расчета в момент его передачи с последующей оплатой в кредит
    /// </summary>
    PartialPayment, // = "partial_payment";

    /// <summary>
    /// Передача в кредит. Передача предмета расчета без его оплаты в момент его передачи с последующей оплатой в кредит
    /// </summary>
    Credit, // = "сredit";

    /// <summary>
    /// Частичный расчет и кредит. Частичная оплата предмета расчета в момент его передачи с последующей оплатой в кредит
    /// </summary>
    CreditPayment, // = "credit_payment";
}
