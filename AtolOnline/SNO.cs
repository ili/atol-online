namespace AtolOnline.Unofficial;

/// <summary>
/// Типы налогообложения
/// </summary>
public enum SNO
{
    /// <summary>
    /// общая СН
    /// </summary>
    OSN, // = "osn";

    /// <summary>
    /// упрощенная СН (доходы)
    /// </summary>
    USN_INCOME,// = "usn_income";

    /// <summary>
    /// упрощенная СН (доходы минус расходы)
    /// </summary>
    USN_INCOME_OUTCOME, // = "usn_income_outcome";

    /// <summary>
    /// единый налог на вмененный доход
    /// </summary>
    ENVD, // = "envd";

    /// <summary>
    /// единый сельскохозяйственный налог
    /// </summary>
    ESN, // = "esn";

    /// <summary>
    /// патентная СН
    /// </summary>
    PATENT, // = "patent";
}
