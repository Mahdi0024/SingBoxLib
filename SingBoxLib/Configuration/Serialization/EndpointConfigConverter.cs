using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Endpoint;
using SingBoxLib.Configuration.Endpoint.Abstract;

namespace SingBoxLib.Configuration.Serialization;

internal class EndpointConfigConverter : JsonConverter<EndpointConfig>
{
    public override EndpointConfig? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        return JsonSerializer.Deserialize(doc.RootElement.GetRawText(), SingBoxJsonContext.Default.WireGuardEndpoint);
    }

    public override void Write(Utf8JsonWriter writer, EndpointConfig value, JsonSerializerOptions options)
    {
        if (value is WireGuardEndpoint wg)
        {
            JsonSerializer.Serialize(writer, wg, SingBoxJsonContext.Default.WireGuardEndpoint);
        }
    }
}
