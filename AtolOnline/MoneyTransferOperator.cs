﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.Unofficial;

/// <summary>
/// Атрибуты оператора перевода
/// </summary>
public class MoneyTransferOperator
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary" /></param>
    /// <param name="inn"><inheritdoc cref="INN" path="/summary" /></param>
    /// <param name="phones"><inheritdoc cref="Phones" path="/summary" /></param>
    /// <param name="address"><inheritdoc cref="Address" path="/summary" /></param>
    [JsonConstructor]
    public MoneyTransferOperator(string? name, string? inn, IReadOnlyCollection<string>? phones, string? address)
    {
        Phones = phones;
        Name = name;
        Address = address;
        INN = inn;
    }

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
    /// Тег: 1075
    /// </remarks>
    public IReadOnlyCollection<string>? Phones { get; set; }

    /// <summary>
    /// Наименование оператора перевода
    /// </summary>
    /// <remarks>
    /// Тег: 1026
    /// </remarks>
    [StringLength(64)]
    public string? Name { get; set; }

    /// <summary>
    /// Место нахождения оператора по переводу денежных средств
    /// </summary>
    /// <remarks>
    /// Тег: 1005
    /// </remarks>
    [StringLength(256)]
    public string? Address { get; set; }

    /// <summary>
    /// ИНН оператора перевода
    /// </summary>
    /// <remarks>
    /// Тег: 1016
    /// </remarks>
    [StringLength(12)]
    public string? INN { get; set; }
}