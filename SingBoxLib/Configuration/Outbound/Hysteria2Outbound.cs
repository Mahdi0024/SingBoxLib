using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Outbound;

public sealed class Hysteria2Outbound : OutboundWithDialFields
{
    public Hysteria2Outbound()
    {
        Type = "hysteria2";
        Tag = "hysteria2-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("up_mbps")]
    public int? UpMbps { get; set; }

    [JsonProperty("down_mbps")]
    public int? DownMbps { get; set; }

    [JsonProperty("obfs")]
    public Hysteria2Obfs? Obfs { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}