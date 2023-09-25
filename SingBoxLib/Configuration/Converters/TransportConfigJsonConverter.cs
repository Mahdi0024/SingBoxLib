using Newtonsoft.Json.Linq;
using SingBoxLib.Configuration.Transport;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Converters;

internal class TransportConfigJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(TransportConfig);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartArray)
        {
            var objList = new List<TransportConfig?>();
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

        TransportConfig? DeserializeBasedOnType(JObject jObject, JsonSerializer serializer, string? type)
        {
            return type switch
            {
                "grpc" => jObject.ToObject<GrpcTransport>(serializer),
                "http" => jObject.ToObject<HttpTransport>(serializer),
                "quic" => jObject.ToObject<QuicTransport>(serializer),
                "ws" => jObject.ToObject<WebSocketTransport>(serializer),
                _ => throw new JsonException($"Unknown type for transport config: {type}")
            };
        }
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}