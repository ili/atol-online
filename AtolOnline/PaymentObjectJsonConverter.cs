using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

internal class PaymentObjectJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(uint) || objectType == typeof(string);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        var value = reader.Value.ToString();
        if (uint.TryParse(value, out var intValue))
        {
            return intValue;
        }

        return -1;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        var iValue = (uint)value;

        var writeAsString = serializer.Context.Context != null;

        if (writeAsString)
        {
            if (PaymentObjects.TryGetValue(iValue, out var paymentObject))
            {
                writer.WriteValue(paymentObject);
            }
            else
                writer.WriteValue(iValue.ToString());
        }
        else
        {
            writer.WriteValue(iValue);
        }
    }

    static readonly IReadOnlyDictionary<uint, string> PaymentObjects = new Dictionary<uint, string>
    {
        {1, "commodity"},
        {2, "excise"},
        {3, "job"},
        {4, "service"},
        {5, "gambling_bet"},
        {6, "gambling_prize"},
        {7, "lottery"},
        {8, "lottery_prize"},
        {9, "intellectual_activity"},
        {10, "payment"},
        {11, "agent_commission"},
        {12, "award"},
        {13, "another"},
        {14, "property_right"},
        {15, "non-operating_gain"},
        {16, "insurance_premium"},
        {17, "sales_tax"},
        {18, "resort_fee"},
        {19, "deposit"},
        {20, "expense"},
        {21, "pension_insurance_ip"},
        {22, "pension_insurance"},
        {23, "medical_insurance_ip"},
        {24, "medical_insurance"},
        {25, "social_insurance"},
        {26, "casino_payment" }
    };
}
