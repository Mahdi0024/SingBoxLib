using Newtonsoft.Json.Linq;
using SingBoxLib.Configuration.Outbound;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Converters;

internal class OutboundConfigJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(OutboundConfig);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartArray)
        {
            var objList = new List<OutboundConfig>();
            var array = JArray.Load(reader);
            foreach (JObject item in array)
            {
                var itemType = item["type"]?.Value<string>();
                objList.Add(DeserializeBasedOnType(item, serializer, itemType)!);
            }
            return objList;
        }
        else
        {
            var jObject = JObject.Load(reader);
            var type = jObject["type"]?.Value<string>();
            return DeserializeBasedOnType(jObject, serializer, type)!;
        }

        OutboundConfig? DeserializeBasedOnType(JObject jObject, JsonSerializer serializer, string? type)
        {
            return type switch
            {
                "direct" => jObject.ToObject<DirectOutbound>(serializer),
                "http" => jObject.ToObject<HttpOutbound>(serializer),
                "hysteria2" => jObject.ToObject<Hysteria2Outbound>(serializer),
                "hysteria" => jObject.ToObject<HysteriaOutbound>(serializer),
                "selector" => jObject.ToObject<SelectorOutbound>(serializer),
                "shadowsocks" => jObject.ToObject<ShadowsocksOutbound>(serializer),
                "shadowtls" => jObject.ToObject<ShadowTlsOutbound>(serializer),
                "socks" => jObject.ToObject<SocksOutbound>(serializer),
                "ssh" => jObject.ToObject<SshOutbound>(serializer),
                "tor" => jObject.ToObject<TorOutbound>(serializer),
                "trojan" => jObject.ToObject<TrojanOutbound>(serializer),
                "tuic" => jObject.ToObject<TuicOutbound>(serializer),
                "urltest" => jObject.ToObject<UrlTestOutbound>(serializer),
                "vless" => jObject.ToObject<VLessOutbound>(serializer),
                "vmess" => jObject.ToObject<VMessOutbound>(serializer),
                "wireguard" => jObject.ToObject<WireGuardOutbound>(serializer),
                _ => throw new JsonException($"Unknown type for outbound config: {type}")
            };
        }
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}