using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Тип коррекции
/// </summary>
/// <remarks>
/// Тег: 1173
/// </remarks>
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum CorrectionType
{
    /// <summary>
    /// самостоятельная операция
    /// </summary>
    Self,

    /// <summary>
    /// операция по предписанию налогового органа об устранении выявленного нарушения законодательства Российской Федерации о применении ККТ
    /// </summary>
    Instruction
}