﻿using System.ComponentModel.DataAnnotations;

namespace AtolOnline.Unofficial;

/// <summary>
/// Атрибуты платежного агента
/// </summary>
public class PayingAgent
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="operation"><inheritdoc cref="Operation" path="/summary" /></param>
    /// <param name="phones"><inheritdoc cref="Phones" path="/summary" /></param>
    public PayingAgent(string? operation, IReadOnlyCollection<string>? phones)
    {
        Operation = operation;
        Phones = phones;
    }

    /// <summary>
    /// Наименование операции банковского платежного агента, банковского платежного субагента.
    /// </summary>
    /// <remarks>
    /// Тег: 1044
    /// </remarks>
    [StringLength(24)]
    public string? Operation { get; set; }

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
    /// Тег: 1073
    /// </remarks>
    public IReadOnlyCollection<string>? Phones { get; set; }
}
