using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class VMessOutbound : OutboundWithDialFields
{
    public VMessOutbound()
    {
        Type = "vmess";
        Tag = "vmess-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("uuid")]
    public string? Uuid { get; set; }

    [JsonProperty("alter_id")]
    public int? AlterId { get; set; }

    [JsonProperty("security")]
    public string? Security { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }

    [JsonProperty("packet_encoding")]
    public string? PacketEncoding { get; set; }

    [JsonConverter(typeof(TransportConfigJsonConverter))]
    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }

    [JsonProperty("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}