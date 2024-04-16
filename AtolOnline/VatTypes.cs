namespace AtolOnline;


/// <summary>
/// Устанавливает номер налога в ККТ.
/// </summary>
public enum VatTypes
{
    /// <summary>
    /// без НДС
    /// </summary>
    None,  // = "none";

    /// <summary>
    /// НДС по ставке 0%
    /// </summary>
    Vat0, // = "vat0";

    /// <summary>
    /// НДС чека по ставке 10%
    /// </summary>
    Vat10, //= "vat10";

    /// <summary>
    /// НДС чека по расчетной ставке 10/110
    /// </summary>
    Vat110, // = "vat110";

    /// <summary>
    /// НДС чека по ставке 20%
    /// </summary>
    Vat20, // = "vat20";

    /// <summary>
    /// НДС чека по расчетной ставке 20/120
    /// </summary>
    Vat120, // = "vat120";
}
