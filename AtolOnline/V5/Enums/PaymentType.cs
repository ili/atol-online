﻿namespace AtolOnline.V5.Enums;

public enum PaymentType
{
    /// <summary>
    /// наличные
    /// </summary>
    /// <remarks>
    /// Тег: 1031
    /// </remarks>
    Cash = 0,

    /// <summary>
    /// безналичный
    /// </summary>
    /// <remarks>
    /// Тег: 1081
    /// </remarks>
    Cashless = 1,

    /// <summary>
    /// предварительная оплата (зачет аванса и (или) предыдущих платежей)
    /// </summary>
    /// <remarks>
    /// Тег: 1215
    /// </remarks>
    Prepayment = 2,

    /// <summary>
    /// постоплата (кредит)
    /// </summary>
    /// <remarks>
    /// Тег: 1216
    /// </remarks>
    Postpaid = 3,

    /// <summary>
    /// иная форма оплаты (встречное предоставление)
    /// </summary>
    /// <remarks>
    /// Тег: 1217
    /// </remarks>
    Other = 4,

    /// <summary>
    /// 5 – 9 – расширенные виды оплаты. Для каждого фискального типа оплаты можно указать расширенный вид оплаты
    /// </summary>
    Extended5 = 5,

    /// <summary>
    /// 5 – 9 – расширенные виды оплаты. Для каждого фискального типа оплаты можно указать расширенный вид оплаты
    /// </summary>
    Extended6 = 6,

    /// <summary>
    /// 5 – 9 – расширенные виды оплаты. Для каждого фискального типа оплаты можно указать расширенный вид оплаты
    /// </summary>
    Extended7 = 7,

    /// <summary>
    /// 5 – 9 – расширенные виды оплаты. Для каждого фискального типа оплаты можно указать расширенный вид оплаты
    /// </summary>
    Extended8 = 8,

    /// <summary>
    /// 5 – 9 – расширенные виды оплаты. Для каждого фискального типа оплаты можно указать расширенный вид оплаты
    /// </summary>
    Extended9 = 9,
}
