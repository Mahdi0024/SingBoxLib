using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Dns;
using SingBoxLib.Configuration.Dns.Abstract;

namespace SingBoxLib.Configuration.Serialization;

internal class DnsRuleBaseConverter : JsonConverter<DnsRuleBase>
{
    public override DnsRuleBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.TryGetProperty("type", out var typeProp) && typeProp.GetString() == "logical")
        {
            return JsonSerializer.Deserialize(root.GetRawText(), SingBoxJsonContext.Default.DnsLogicalRule);
        }
        return JsonSerializer.Deserialize(root.GetRawText(), SingBoxJsonContext.Default.DnsRule);
    }

    public override void Write(Utf8JsonWriter writer, DnsRuleBase value, JsonSerializerOptions options)
    {
        if (value is DnsLogicalRule logicalRule)
        {
            JsonSerializer.Serialize(writer, logicalRule, SingBoxJsonContext.Default.DnsLogicalRule);
        }
        else if (value is DnsRule rule)
        {
            JsonSerializer.Serialize(writer, rule, SingBoxJsonContext.Default.DnsRule);
        }
    }
}
