using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class VLessInbound : InboundConfig
{
    public VLessInbound()
    {
        Type = "vless";
        Tag = "vless-in";
    }

    [JsonProperty("users")]
    public List<VLessUser>? Users { get; set; }

    [JsonProperty("tls")]
    public TlsConfig? Tls { get; set; }

    [JsonConverter(typeof(TransportConfigJsonConverter))]
    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }
}

public class VLessUser
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("uuid")]
    public string? Uuid { get; set; }

    [JsonProperty("flow")]
    public string? Flow { get; set; }
}