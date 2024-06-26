﻿using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// <para>
/// Тэг: 1057
/// </para>
/// Признак агента
/// </summary>
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AgentType
{
    /// <summary>
    /// банковский платежный агент. Оказание услуг покупателю (клиенту) пользователем, являющимся банковским платежным агентом
    /// </summary>
    BankPayingAgent,

    /// <summary>
    /// банковский платежный субагент. Оказание услуг покупателю (клиенту) пользователем, являющимся банковским платежным субагентом
    /// </summary>
    BankPayingSubagent,

    /// <summary>
    /// платежный агент. Оказание услуг покупателю (клиенту) пользователем, являющимся платежным агентом
    /// </summary>
    PayingAgent,

    /// <summary>
    ///  платежный субагент. Оказание услуг покупателю (клиенту) пользователем, являющимся платежным субагентом
    /// </summary>
    PayingSubagent,

    /// <summary>
    /// комиссионер. 
    /// Осуществление расчета с покупателем 
    /// (клиентом) пользователем, являющимся
    /// комиссионером
    /// </summary>
    Attorney,

    /// <summary>
    /// комиссионер. 
    /// Осуществление расчета с покупателем 
    /// (клиентом) пользователем, являющимся
    /// комиссионером
    /// </summary>
    CommissionAgent,

    /// <summary>
    /// другой тип агента. Осуществление 
    /// расчета с покупателем (клиентом) 
    /// пользователем, являющимся агентом и не
    /// являющимся банковским платежным агентом
    /// (субагентом), платежным агентом 
    /// (субагентом), поверенным, комиссионером
    /// </summary>
    Another,
}
