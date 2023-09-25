using Newtonsoft.Json.Linq;
using SingBoxLib.Configuration.Route;
using SingBoxLib.Configuration.Route.Abstract;

namespace SingBoxLib.Configuration.Converters;

internal class RouteRuleJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(RouteRuleBase);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartArray)
        {
            var objList = new List<RouteRuleBase?>();
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

        RouteRuleBase? DeserializeBasedOnType(JObject jObject, JsonSerializer serializer, string? type)
        {
            return type switch
            {
                null => jObject.ToObject<RouteRule>(serializer),
                "logical" => jObject.ToObject<RouteLogicalRule>(serializer),
                _ => throw new JsonException($"Unknown type for route rule: {type}")
            };
        }
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}