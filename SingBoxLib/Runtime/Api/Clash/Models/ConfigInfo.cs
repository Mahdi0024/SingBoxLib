namespace SingBoxLib.Runtime.Api.Clash.Models;

public class ConfigInfo
{
    [JsonPropertyName("port")]
    public int Port { get; set; }

    [JsonPropertyName("socks-port")]
    public int SocksPort { get; set; }

    [JsonPropertyName("redir-port")]
    public int RedirPort { get; set; }

    [JsonPropertyName("tproxy-port")]
    public int TproxyPort { get; set; }

    [JsonPropertyName("mixed-port")]
    public int MixedPort { get; set; }

    [JsonPropertyName("allow-lan")]
    public bool AllowLan { get; set; }

    [JsonPropertyName("bind-address")]
    public string? BindAddress { get; set; }

    [JsonPropertyName("mode")]
    public string? Mode { get; set; }

    [JsonPropertyName("log-level")]
    public string? LogLevel { get; set; }

    [JsonPropertyName("ipv6")]
    public bool Ipv6 { get; set; }

    [JsonPropertyName("tun")]
    public string? Tun { get; set; }
}