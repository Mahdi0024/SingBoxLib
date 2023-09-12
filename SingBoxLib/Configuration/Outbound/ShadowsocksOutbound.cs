using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Outbound;

public sealed class ShadowsocksOutbound : OutboundWithDialFields
{
    public ShadowsocksOutbound()
    {
        Type = "shadowsocks";
        Tag = "ss-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("method")]
    public string? Encryption { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("plugin")]
    public string? Plugin { get; set; }

    [JsonProperty("plugin_opts")]
    public string? PluginOptions { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("udp_over_tcp")]
    public bool? UdpOverTcp { get; set; }

    [JsonProperty("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}