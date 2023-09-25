using Newtonsoft.Json.Linq;
using SingBoxLib.Configuration.Inbound;
using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Converters;

internal class InboundConfigJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(InboundConfig);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartArray)
        {
            var objList = new List<InboundConfig>();
            var array = JArray.Load(reader);
            foreach (JObject item in array)
            {
                var itemType = item["type"]?.Value<string>()!;
                objList.Add(DeserializeBasedOnType(item, serializer, itemType)!);
            }
            return objList;
        }
        else
        {
            var jObject = JObject.Load(reader);
            var type = jObject["type"]?.Value<string>()!;
            return DeserializeBasedOnType(jObject, serializer, type)!;
        }

        InboundConfig? DeserializeBasedOnType(JObject jObject, JsonSerializer serializer, string type)
        {
            return type switch
            {
                "http" => jObject.ToObject<HttpInbound>(serializer),
                "socks" => jObject.ToObject<SocksInbound>(serializer),
                "mixed" => jObject.ToObject<MixedInbound>(serializer),
                "direct" => jObject.ToObject<DirectInbound>(serializer),
                "hysteria2" => jObject.ToObject<Hysteria2Inbound>(serializer),
                "hysteria" => jObject.ToObject<HysteriaInbound>(serializer),
                "naive" => jObject.ToObject<NaiveInbound>(serializer),
                "redirect" => jObject.ToObject<RedirectInbound>(serializer),
                "shadowsocks" => jObject.ToObject<ShadowsocksInbound>(serializer),
                "shadowtls" => jObject.ToObject<ShadowTlsInbound>(serializer),
                "tproxy" => jObject.ToObject<TransparentProxyInbound>(serializer),
                "tuic" => jObject.ToObject<TuicInbound>(serializer),
                "trojan" => jObject.ToObject<TrojanInbound>(serializer),
                "tun" => jObject.ToObject<TunInbound>(serializer),
                "vless" => jObject.ToObject<VLessInbound>(serializer),
                "vmess" => jObject.ToObject<VMessInbound>(serializer),
                _ => throw new JsonException($"Unknown type for inbound config: {type}")
            };
        }
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}