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
    public Handshake? Handshake { get; set; }

    [JsonProperty("handshake_for_server_name")]
    public Dictionary<string, Handshake>? HandshakeForServerName { get; set; }

    [JsonProperty("strict_mode")]
    public bool? StrictMode { get; set; }
}

public sealed class Handshake : OutboundWithDialFields
{
    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    //hide unused parent properties to prevent any future confusion.
    private new string? Tag { get; set; }

    private new string? Name { get; set; }
}