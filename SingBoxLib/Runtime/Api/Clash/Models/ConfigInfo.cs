namespace SingBoxLib.Runtime.Api.Clash.Models;

public class ConfigInfo
{
    [JsonProperty("port")]
    public int Port { get; set; }

    [JsonProperty("socks-port")]
    public int SocksPort { get; set; }

    [JsonProperty("redir-port")]
    public int RedirPort { get; set; }

    [JsonProperty("tproxy-port")]
    public int TproxyPort { get; set; }

    [JsonProperty("mixed-port")]
    public int MixedPort { get; set; }

    [JsonProperty("allow-lan")]
    public bool AllowLan { get; set; }

    [JsonProperty("bind-address")]
    public string? BindAddress { get; set; }

    [JsonProperty("mode")]
    public string? Mode { get; set; }

    [JsonProperty("log-level")]
    public string? LogLevel { get; set; }

    [JsonProperty("ipv6")]
    public bool Ipv6 { get; set; }

    [JsonProperty("tun")]
    public string? Tun { get; set; }
}