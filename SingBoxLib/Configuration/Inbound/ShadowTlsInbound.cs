using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class ShadowTlsInbound : InboundConfig
{
    public ShadowTlsInbound()
    {
        Type = "shadowtls";
        Tag = "shadowtls-in";
    }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("users")]
    public List<ProxyUserInbound>? Users { get; set; }

    [JsonProperty("handshake")]
    public HandshakeConfig? Handshake { get; set; }

    [JsonProperty("handshake_for_server_name")]
    public Dictionary<string, HandshakeConfig>? HandshakeForServerName { get; set; }

    [JsonProperty("strict_mode")]
    public bool? StrictMode { get; set; }
}
