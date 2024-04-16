﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtolOnline.Unofficial;

/// <summary>
/// Атрибуты оператора по приему платежей
/// </summary>
public class ReceivePaymentsOperator
{
    /// <summary>
    /// <para>
    /// Номера телефонов платежного агента, платежного субагента, банковского 
    /// платежного агента, банковского платежного субагента
    /// Номер телефона необходимо передать вместе с кодом страны без пробелов и
    /// дополнительных символов, кроме символа «+».
    /// </para>
    /// <para>
    /// Если номер телефон начинается с символа «+», то максимальная длина одного
    /// элемента массива – 19 символов.
    /// </para>
    /// <para>
    /// Если номер телефона относится к России(префикс «+7»), то значение можно
    /// передать без префикса(номер «+7 925 1234567» можно передать как
    /// «9251234567»). Максимальная длина одного элемента массива в таком случае –
    /// 17 символов
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1074
    /// </remarks>
    public List<string>? Phones { get; set; }
}
