using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class SocksOutbound : OutboundWithDialFields
{
    public SocksOutbound()
    {
        Type = "socks";
        Tag = "socks-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("version")]
    public string? Version { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("udp_over_tcp")]
    public bool? UdpOverTcp { get; set; }
}