﻿using Newtonsoft.Json;

namespace AtolOnline.V5.Entities;

/// <summary>
/// См 35 <see href="https://online.atol.ru/files/API_atol_online_v5.pdf"/>
/// </summary>
public class MarkCode
{
    /// <summary>
    /// Помощник для создания объекта маркировки
    /// <code>
    /// MarkCode.New.Ean8("12345678")
    /// </code>
    /// </summary>
    public static class New
    {
        /// <summary>
        /// Код товара, формат которого не идентифицирован, как один из реквизитов.
        /// <para>Максимум 32 символа.</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Тег: 1300 
        /// </remarks>
        public static MarkCode Unknown(string value) => new MarkCode(unknown: value);

        /// <summary>
        /// <para>Код товара в формате EAN-8</para>
        /// <para>Ровно 8 цифр</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Тег: 1301 
        /// </remarks>
        public static MarkCode Ean8(string value) => new MarkCode(ean8: value);

        /// <summary>
        /// <para>Код товара в формате EAN-13</para>
        /// <para>Ровно 13 цифр</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Тег: 1302 
        /// </remarks>
        public static MarkCode Ean13(string value) => new MarkCode(ean13: value);

        /// <summary>
        /// <para>Код товара в формате ITF-14</para>
        /// <para>Ровно 14 цифр</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Тег: 1303 
        /// </remarks>
        public static MarkCode Itf14(string value) => new MarkCode(itf14: value);

        /// <summary>
        /// <para>Код товара в формате GS1, нанесенный на товар, <b>НЕ подлежащий маркировке средствами идентификации</b></para>
        /// <para>Максимум 38 символов</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Тег: 1304 
        /// </remarks>
        public static MarkCode Gs10(string value) => new MarkCode(gs10: value);

        /// <summary>
        /// <para>Код товара в формате GS1, нанесенный на товар, <b>подлежащий маркировке средствами идентификации</b></para>
        /// <para>Максимум 200 символов</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// <para><b>
        /// Примечание: Код товара необходимо передавать целиком. В связи с тем, 
        /// что в коде товара могут быть непечатные символы, необходимо перед
        /// отправкой кодировать строку с кодом товара в Base64
        /// </b></para>
        /// </summary>
        /// <remarks>
        /// Тег: 1305 
        /// </remarks>
        public static MarkCode Gs1m(string value) => new MarkCode(gs1m: value);

        /// <summary>
        /// <para>Код товара в формате короткого кода маркировки, нанесенный на товар, подлежащий маркировке средствами идентификации</para>
        /// <para>Максимум 38 символов</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Тег: 1306 
        /// </remarks>
        public static MarkCode Short(string value) => new MarkCode(@short: value);

        /// <summary>
        /// <para>Контрольно-идентификационный знак мехового изделия</para>
        /// <para>Ровно 20 символов, должно соответствовать маске СС-ЦЦЦЦЦЦ-СССССССССС</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Тег: 1307 
        /// </remarks>
        public static MarkCode Fur(string value) => new MarkCode(fur: value);

        /// <summary>
        /// <para>Код товара в формате ЕГАИС-2.0</para>
        /// <para>Ровно 23 символа</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Тег: 1308 
        /// </remarks>
        public static MarkCode Egais20(string value) => new MarkCode(egais20: value);


        /// <summary>
        /// <para>Код товара в формате ЕГАИС-3.0</para>
        /// <para>Ровно 14 символов</para>
        /// <para>
        /// Значения реквизита должно формироваться в соответствии с правилами,
        /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Тег: 1309 
        /// </remarks>
        public static MarkCode Egais30(string value) => new MarkCode(egais30: value);
    }

    [JsonConstructor]
    public MarkCode(
        string? unknown = null,
        string? ean8 = null,
        string? ean13 = null,
        string? itf14 = null,
        string? gs10 = null,
        string? gs1m = null,
        string? @short = null,
        string? fur = null,
        string? egais20 = null,
        string? egais30 = null)
    {
        Unknown = unknown;
        Ean8 = ean8;
        Ean13 = ean13;
        Itf14 = itf14;
        Gs10 = gs10;
        Gs1m = gs1m;
        Short = @short;
        Fur = fur;
        Egais20 = egais20;
        Egais30 = egais30;
    }

    /// <summary>
    /// Код товара, формат которого не идентифицирован, как один из реквизитов.
    /// <para>Максимум 32 символа.</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1300 
    /// </remarks>
    public string? Unknown { get; }

    /// <summary>
    /// <para>Код товара в формате EAN-8</para>
    /// <para>Ровно 8 цифр</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1301 
    /// </remarks>
    public string? Ean8 { get; }

    /// <summary>
    /// <para>Код товара в формате EAN-13</para>
    /// <para>Ровно 13 цифр</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1302 
    /// </remarks>
    public string? Ean13 { get; }

    /// <summary>
    /// <para>Код товара в формате ITF-14</para>
    /// <para>Ровно 14 цифр</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1303 
    /// </remarks>
    public string? Itf14 { get; }

    /// <summary>
    /// <para>Код товара в формате GS1, нанесенный на товар, <b>НЕ подлежащий маркировке средствами идентификации</b></para>
    /// <para>Максимум 38 символов</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1304 
    /// </remarks>
    public string? Gs10 { get; }

    /// <summary>
    /// <para>Код товара в формате GS1, нанесенный на товар, <b>подлежащий маркировке средствами идентификации</b></para>
    /// <para>Максимум 200 символов</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// <para><b>
    /// Примечание: Код товара необходимо передавать целиком. В связи с тем, 
    /// что в коде товара могут быть непечатные символы, необходимо перед
    /// отправкой кодировать строку с кодом товара в Base64
    /// </b></para>
    /// </summary>
    /// <remarks>
    /// Тег: 1305 
    /// </remarks>
    public string? Gs1m { get; }

    /// <summary>
    /// <para>Код товара в формате короткого кода маркировки, нанесенный на товар, подлежащий маркировке средствами идентификации</para>
    /// <para>Максимум 38 символов</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1306 
    /// </remarks>
    public string? Short { get; }

    /// <summary>
    /// <para>Контрольно-идентификационный знак мехового изделия</para>
    /// <para>Ровно 20 символов, должно соответствовать маске СС-ЦЦЦЦЦЦ-СССССССССС</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1307 
    /// </remarks>
    public string? Fur { get; }

    /// <summary>
    /// <para>Код товара в формате ЕГАИС-2.0</para>
    /// <para>Ровно 23 символа</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1308 
    /// </remarks>
    public string? Egais20 { get; }


    /// <summary>
    /// <para>Код товара в формате ЕГАИС-3.0</para>
    /// <para>Ровно 14 символов</para>
    /// <para>
    /// Значения реквизита должно формироваться в соответствии с правилами,
    /// указанными в Приложении № 2 к приказу ФНС России от 14.09.2020г. № ЕД-7-20/662@ (Таблица 118)
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1309 
    /// </remarks>
    public string? Egais30 { get; }
}
