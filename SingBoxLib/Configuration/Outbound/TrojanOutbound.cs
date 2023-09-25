using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class TrojanOutbound : OutboundWithDialFields
{
    public TrojanOutbound()
    {
        Type = "trojan";
        Tag = "trojan-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? Port { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("tls")]
    public TlsConfig? Tls { get; set; }

    [JsonProperty("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }

    [JsonConverter(typeof(TransportConfigJsonConverter))]
    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }
}