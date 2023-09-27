using Newtonsoft.Json.Linq;
using System.Globalization;

namespace SingBoxLib.Configuration.Converters;

internal class SingleValueJsonConverter<T> : JsonConverter<List<T>>
{
    public override List<T>? ReadJson(JsonReader reader, Type objectType, List<T>? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartArray)
        {
            var jArray = JArray.Load(reader);
            var items = new List<T>(jArray.Count);
            foreach (var item in jArray)
            {
                items.Add(serializer.Deserialize<T>(item.CreateReader())!);
            }
            return items;
        }

        if (reader.TokenType == JsonToken.StartObject)
        {
            var obj = JObject.Load(reader);
            return new List<T>
            {
                serializer.Deserialize<T>(obj.CreateReader())!
            };
        }
        if (reader.TokenType == JsonToken.String)
        {
            return new List<T>
            {
                (T)reader.Value!
            };
        }
        if (reader.TokenType == JsonToken.Integer)
        {
            return new List<T>
            {
                (T) Convert.ChangeType(reader.Value,typeof(T),CultureInfo.InvariantCulture)!
            };
        }
        throw new JsonException($"Something went wrong while deserializing type: {typeof(T)}");
    }

    public override void WriteJson(JsonWriter writer, List<T>? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}