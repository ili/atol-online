using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// <para>
/// Тег: 1173
/// </para>
/// Тип коррекции
/// </summary>
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum CorrectionType
{
    /// <summary>
    /// <para>
    /// Тег: 1173
    /// </para>
    /// самостоятельная операция
    /// </summary>
    Self,

    /// <summary>
    /// <para>
    /// Тег: 1173
    /// </para>
    /// операция по предписанию налогового органа об устранении выявленного нарушения законодательства Российской Федерации о применении ККТ
    /// </summary>
    Instruction
}