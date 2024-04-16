using Newtonsoft.Json;

namespace AtolOnline;

/// <summary>
/// Чек корректировки
/// </summary>
public class CorrectionReceipt : Receipt
{
    /// <summary>
    /// Чек коррекции
    /// </summary>
    /// <inheritdoc cref="Receipt(Client, Company, IReadOnlyCollection{Item}, IReadOnlyCollection{Payment}, decimal?, AgentInfo?, SupplierInfo?, IReadOnlyCollection{Vat}?, string?, string?, string?, AdditionalUserProps?, OperatingCheckProps?, IReadOnlyCollection{SectoralItemProps}?, string?)"/>
    /// <param name="correctionInfo"><inheritdoc cref="CorrectionInfo"/></param>
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
