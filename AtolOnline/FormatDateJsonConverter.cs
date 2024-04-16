using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace AtolOnline.Unofficial;

abstract class FormatDateJsonConverter : DateTimeConverterBase
{
    public class Date : FormatDateJsonConverter
    {
        public Date() : base("dd.MM.yyyy")
        {
        }
    }

    public class DateTime : FormatDateJsonConverter
    {
        public DateTime() : base("dd.MM.yyyy HH:mm:ss")
        {
        }
    }


    private string _format;
    protected FormatDateJsonConverter(string format)
    {
        _format = format;
    }


    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null)
            return null;

        return System.DateTime.ParseExact(reader.Value.ToString(), _format, CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value == null)
            writer.WriteNull();
        else
        {
            var dt = (System.DateTime)value!;
            writer.WriteValue(dt.ToString(_format));
        }
    }
}
