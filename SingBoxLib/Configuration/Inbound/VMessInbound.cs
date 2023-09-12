using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class VMessInbound : InboundConfig
{
    public VMessInbound()
    {
        Type = "vmess";
        Tag = "vmess-out";
    }

    [JsonProperty("users")]
    public List<VMessUser>? Users { get; set; }

    [JsonProperty("tls")]
    public TlsConfig? Tls { get; set; }

    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }
}

public class VMessUser
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("uuid")]
    public string? Uuid { get; set; }

    [JsonProperty("alterId")]
    public int? AlterId { get; set; }
}