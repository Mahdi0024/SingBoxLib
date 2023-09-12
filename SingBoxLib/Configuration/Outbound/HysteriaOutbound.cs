using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Outbound;

public sealed class HysteriaOutbound : OutboundWithDialFields
{
    public HysteriaOutbound()
    {
        Type = "hysteria";
        Tag = "hysteria-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("up")]
    public string? Up { get; set; }

    [JsonProperty("up_mbps")]
    public int? UpMbps { get; set; }

    [JsonProperty("down")]
    public string? Down { get; set; }

    [JsonProperty("down_mbps")]
    public int? DownMbps { get; set; }

    [JsonProperty("obfs")]
    public string? Obfs { get; set; }

    [JsonProperty("auth")]
    public string? Auth { get; set; }

    [JsonProperty("auth_str")]
    public string? AuthString { get; set; }

    [JsonProperty("recv_window_conn")]
    public int? RecvWindowConn { get; set; }

    [JsonProperty("recv_window")]
    public int? RecvWindow { get; set; }

    [JsonProperty("disable_mtu_discovery")]
    public bool? DisableMtuDiscovery { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("tls")]
    public TlsConfig? Tls { get; set; }
}