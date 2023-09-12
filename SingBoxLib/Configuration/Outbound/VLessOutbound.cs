using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class VLessOutbound : OutboundWithDialFields
{
    public VLessOutbound()
    {
        Type = "vless";
        Tag = "vless-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("uuid")]
    public string? Uuid { get; set; }

    [JsonProperty("flow")]
    public string? Flow { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("tls")]
    public TlsConfig? Tls { get; set; }

    [JsonProperty("packet_encoding")]
    public string? PacketEncoding { get; set; }

    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }
}