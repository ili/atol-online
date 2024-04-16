using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Чек корректировки
/// </summary>
public class CorrectionReceipt : Receipt
{
    /// <summary>
    /// Чек коррекции
    /// </summary>
    /// <inheritdoc cref="Receipt(Client, Company, IReadOnlyCollection{Item}, IReadOnlyCollection{Payment}, decimal?, AgentInfo?, SupplierInfo?, IReadOnlyCollection{Vat}?, string?, string?, string?, AdditionalUserProps?, OperatingCheckProps?, IReadOnlyCollection{SectoralItemProps}?, string?)"/>
    /// <param name="client"><inheritdoc cref="Receipt.Client" path="/summary" /> </param>
    /// <param name="company"><inheritdoc cref="Receipt.Company" path="/summary" /></param>
    /// <param name="correctionInfo"><inheritdoc cref="CorrectionInfo" path="/summary" /></param>
    /// <param name="items"><inheritdoc cref="Receipt.Items" path="/summary" /></param>
    /// <param name="payments"><inheritdoc cref="Receipt.Payments" path="/summary" /></param>
    /// <param name="total"><inheritdoc cref="Receipt.Total" path="/summary" /></param>
    /// <param name="agentInfo"><inheritdoc cref="Receipt.AgentInfo" path="/summary" /></param>
    /// <param name="supplierInfo"><inheritdoc cref="Receipt.SupplierInfo" path="/summary" /></param>
    /// <param name="vats"><inheritdoc cref="Receipt.Vats" path="/summary" /></param>
    /// <param name="cashier"><inheritdoc cref="Receipt.Cashier" path="/summary" /></param>
    /// <param name="cashierINN"><inheritdoc cref="Receipt.CashierINN" path="/summary" /></param>
    /// <param name="additionalCheckProps"><inheritdoc cref="Receipt.AdditionalCheckProps" path="/summary" /></param>
    /// <param name="additionalUserProps"><inheritdoc cref="Receipt.AdditionalUserProps" path="/summary" /></param>
    /// <param name="operatingCheckProps"><inheritdoc cref="Receipt.OperatingCheckProps" path="/summary" /></param>
    /// <param name="sectoralCheckProps"><inheritdoc cref="Receipt.SectoralCheckProps" path="/summary" /></param>
    /// <param name="deviceNumber"><inheritdoc cref="Receipt.DeviceNumber" path="/summary" /></param>
    [JsonConstructor]
    public CorrectionReceipt(
        Client client,
        Company company,
        CorrectionInfo correctionInfo,
        IReadOnlyCollection<Item> items,
        IReadOnlyCollection<Payment> payments,
        decimal? total = null,
        AgentInfo? agentInfo = null,
        SupplierInfo? supplierInfo = null,
        IReadOnlyCollection<Vat>? vats = null,
        string? cashier = null,
        string? cashierINN = null,
        string? additionalCheckProps = null,
        AdditionalUserProps? additionalUserProps = null,
        OperatingCheckProps? operatingCheckProps = null,
        IReadOnlyCollection<SectoralItemProps>? sectoralCheckProps = null,
        string? deviceNumber = null)
        : base(client, company, items, payments, total, agentInfo, supplierInfo, vats, cashier, cashierINN, additionalCheckProps, additionalUserProps, operatingCheckProps, sectoralCheckProps, deviceNumber)
    {
        CorrectionInfo = correctionInfo;
    }

    /// <summary>
    /// Коррекция
    /// </summary>
    public CorrectionInfo CorrectionInfo { get; }
}
