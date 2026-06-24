using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Route;
using SingBoxLib.Configuration.Route.Abstract;

namespace SingBoxLib.Configuration.Serialization;

internal class RouteRuleHeadlessBaseConverter : JsonConverter<RouteRuleHeadlessBase>
{
    public override RouteRuleHeadlessBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var rawText = root.GetRawText();
        if (root.TryGetProperty("type", out var typeProp) && typeProp.GetString() == "logical")
        {
            return JsonSerializer.Deserialize(rawText, SingBoxJsonContext.Default.RouteRuleHeadlessLogical);
        }
        return JsonSerializer.Deserialize(rawText, SingBoxJsonContext.Default.RouteRuleHeadless);
    }

    public override void Write(Utf8JsonWriter writer, RouteRuleHeadlessBase value, JsonSerializerOptions options)
    {
        if (value is RouteRuleHeadlessLogical logicalRule)
        {
            JsonSerializer.Serialize(writer, logicalRule, SingBoxJsonContext.Default.RouteRuleHeadlessLogical);
        }
        else if (value is RouteRuleHeadless rule)
        {
            JsonSerializer.Serialize(writer, rule, SingBoxJsonContext.Default.RouteRuleHeadless);
        }
    }
}
