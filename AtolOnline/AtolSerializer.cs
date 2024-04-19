using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

/// <summary>
/// Хелпер для серилизации
/// </summary>
public class AtolSerializer
{
    /// <summary>
    /// Серилизация V5, ФФД 1.2
    /// </summary>
    public static readonly AtolSerializer V5 = new(new JsonSerializerSettings()
    {
        Converters =
        [
            new FormatDateJsonConverter.DateTime(),
        ],
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy(),
        },
        DateFormatString = "dd.MM.yyyy HH:mm",
        NullValueHandling = NullValueHandling.Ignore,
    });

    /// <summary>
    /// Серилизация V4, ФФД 1.05
    /// </summary>
    public static readonly AtolSerializer V4 = new(new JsonSerializerSettings()
    {
        Converters =
        [
            new FormatDateJsonConverter.DateTime(),
        ],
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy(),
        },
        DateFormatString = "dd.MM.yyyy HH:mm",
        NullValueHandling = NullValueHandling.Ignore,
        Context = new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.All, "v4")
    });

    private JsonSerializerSettings _settings;

    private AtolSerializer(JsonSerializerSettings settings)
    {
        _settings = settings;
    }

    /// <summary>
    /// Серилизовать
    /// </summary>
    /// <param name="obj">Объект</param>
    /// <returns></returns>
    public string Serialize(object obj)
        => JsonConvert.SerializeObject(obj, _settings);

    /// <summary>
    /// Десерилизовать
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json">JSON</param>
    /// <returns></returns>
    public T Deserialize<T>(string json)
        => JsonConvert.DeserializeObject<T>(json, _settings)!;

}
