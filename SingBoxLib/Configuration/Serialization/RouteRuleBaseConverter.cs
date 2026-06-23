namespace SingBoxLib.Configuration.Serialization;

public class RouteRuleBaseConverter : JsonConverter<RouteRuleBase>
{
    public override RouteRuleBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var rawText = root.GetRawText();
        
        if (typeof(RouteRuleHeadlessBase).IsAssignableFrom(typeToConvert))
        {
            if (root.TryGetProperty("type", out var typeProp) && typeProp.GetString() == "logical")
            {
                return JsonSerializer.Deserialize(rawText, SingBoxJsonContext.Default.RouteRuleHeadlessLogical);
            }
            return JsonSerializer.Deserialize(rawText, SingBoxJsonContext.Default.RouteRuleHeadless);
        }

        if (root.TryGetProperty("type", out var ruleTypeProp) && ruleTypeProp.GetString() == "logical")
        {
            return JsonSerializer.Deserialize(rawText, SingBoxJsonContext.Default.RouteLogicalRule);
        }
        return JsonSerializer.Deserialize(rawText, SingBoxJsonContext.Default.RouteRule);
    }

    public override void Write(Utf8JsonWriter writer, RouteRuleBase value, JsonSerializerOptions options)
    {
        if (value is RouteRuleHeadlessLogical headlessLogical)
        {
            JsonSerializer.Serialize(writer, headlessLogical, SingBoxJsonContext.Default.RouteRuleHeadlessLogical);
        }
        else if (value is RouteRuleHeadless headless)
        {
            JsonSerializer.Serialize(writer, headless, SingBoxJsonContext.Default.RouteRuleHeadless);
        }
        else if (value is RouteLogicalRule logicalRule)
        {
            JsonSerializer.Serialize(writer, logicalRule, SingBoxJsonContext.Default.RouteLogicalRule);
        }
        else if (value is RouteRule rule)
        {
            JsonSerializer.Serialize(writer, rule, SingBoxJsonContext.Default.RouteRule);
        }
    }
}
