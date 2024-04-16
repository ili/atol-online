using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Коррекция
/// </summary>
public class CorrectionInfo
{
    /// <summary>
    /// самостоятельная операция
    /// </summary>
    /// <param name="baseDate">
    /// <inheritdoc cref="BaseDate"/>
    /// </param>
    public static CorrectionInfo Self(DateTime baseDate) => new CorrectionInfo(CorrectionType.Self, baseDate, null);

    /// <summary>
    /// операция по предписанию налогового органа об устранении выявленного нарушения законодательства Российской Федерации о применении ККТ
    /// </summary>
    /// <param name="baseDate">
    /// <inheritdoc cref="BaseDate"/>
    /// </param>
    /// <param name="baseNumber">
    /// <inheritdoc cref="BaseNumber"/>
    /// </param>
    public static CorrectionInfo Instruction(DateTime baseDate, string baseNumber) => new CorrectionInfo(CorrectionType.Self, baseDate, baseNumber);

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="type"><inheritdoc cref="Type" path="/summary" /></param>
    /// <param name="baseDate"><inheritdoc cref="BaseDate" path="/summary" /></param>
    /// <param name="baseNumber"><inheritdoc cref="BaseNumber" path="/summary" /></param>
    public CorrectionInfo(CorrectionType type, DateTime baseDate, string? baseNumber)
    {
        Type = type;
        BaseDate = baseDate;
        BaseNumber = baseNumber;
    }

    /// <summary>
    /// Тип коррекции
    /// </summary>
    /// <remarks>
    /// Тег: 1173
    /// </remarks>
    public CorrectionType Type { get; }

    /// <summary>
    /// Дата совершения корректируемого
    /// </summary>
    /// <remarks>
    /// Тег: 1178
    /// </remarks>
    [JsonConverter(typeof(FormatDateJsonConverter.Date))]
    public DateTime BaseDate { get; }


    /// <summary>
    /// Номер документа основания для коррекции
    /// <para>
    /// Заполняется в случае, если коррекция расчета осуществляется по предписанию 
    /// налогового органа об устранении выявленного нарушения законодательства
    /// Российской Федерации о применении ККТ
    /// </para>
    /// <para>
    /// Максимум 32 символа
    /// </para>
    /// </summary>
    /// <remarks>
    /// Тег: 1179
    /// </remarks>
    public string? BaseNumber { get; }
}
