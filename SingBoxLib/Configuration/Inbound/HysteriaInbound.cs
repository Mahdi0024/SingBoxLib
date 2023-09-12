using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

public sealed class HysteriaInbound : InboundConfig
{
    public HysteriaInbound()
    {
        Type = "hysteria";
        Tag = "hysteria-in";
    }

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

    [JsonProperty("users")]
    public List<HysteriaUser>? Users { get; set; }

    [JsonProperty("recv_window_conn")]
    public int? RecvWindowConn { get; set; }

    [JsonProperty("recv_window_client")]
    public int? RecvWindowClient { get; set; }

    [JsonProperty("max_conn_client")]
    public int? MaxConnClient { get; set; }

    [JsonProperty("disable_mtu_discovery")]
    public bool? DisableMtuDiscovery { get; set; }

    [JsonProperty("tls")]
    public TlsConfig? Tls { get; set; }
}

public class HysteriaUser
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("auth")]
    public string? Auth { get; set; }

    [JsonProperty("auth_str")]
    public string? AuthStr { get; set; }
}