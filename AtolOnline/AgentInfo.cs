using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Атрибуты агента
/// </summary>
public class AgentInfo
{
    [JsonConstructor]
    public AgentInfo(AgentType type,
        PayingAgent? payingAgent = null,
        ReceivePaymentsOperator? receivePaymentsOperator = null,
        MoneyTransferOperator? moneyTransferOperator = null)
    {
        Type = type;
        PayingAgent = payingAgent;
        ReceivePaymentsOperator = receivePaymentsOperator;
        MoneyTransferOperator = moneyTransferOperator;
    }

    /// <summary>
    /// Признак агента (ограничен агентами, введенными в ККТ при фискализации)
    /// </summary>
    /// <remarks>
    /// Тег: 1057
    /// </remarks>
    public AgentType Type { get; }

    /// <summary>
    /// Атрибуты платежного агента
    /// </summary>
    public PayingAgent? PayingAgent { get; set; }

    /// <summary>
    /// Атрибуты оператора по приему платежей
    /// </summary>
    public ReceivePaymentsOperator? ReceivePaymentsOperator { get; set; }

    /// <summary>
    /// Атрибуты оператора перевода
    /// </summary>
    public MoneyTransferOperator? MoneyTransferOperator { get; set; }
}
