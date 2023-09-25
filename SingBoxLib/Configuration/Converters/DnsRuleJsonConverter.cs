using Newtonsoft.Json.Linq;
using SingBoxLib.Configuration.Dns;
using SingBoxLib.Configuration.Dns.Abstract;

namespace SingBoxLib.Configuration.Converters;

internal class DnsRuleJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DnsRuleBase);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartArray)
        {
            var objList = new List<DnsRuleBase?>();
            var array = JArray.Load(reader);
            foreach (JObject item in array)
            {
                var itemType = item["type"]?.Value<string>()!;
                objList.Add(DeserializeBasedOnType(item, serializer, itemType));
            }
            return objList;
        }
        else
        {
            var jObject = JObject.Load(reader);
            var type = jObject["type"]?.Value<string>()!;
            return DeserializeBasedOnType(jObject, serializer, type)!;
        }

        DnsRuleBase? DeserializeBasedOnType(JObject jObject, JsonSerializer serializer, string? type)
        {
            return type switch
            {
                null => jObject.ToObject<DnsRule>(serializer),
                "logical" => jObject.ToObject<DnsLogicalRule>(serializer),
                _ => throw new JsonException($"Unknown type for dns rule: {type}")
            };
        }
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}