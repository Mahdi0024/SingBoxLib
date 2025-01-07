using SingboxLib.Configuration.Endpoint.Abstract;

namespace SingboxLib.Configuration.Endpoint;
public sealed class WireGuardEndpoint : EndpointConfig
{
    [JsonProperty("system")]
    public bool? System { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("mtu")]
    public int? Mtu { get; set; }

    [JsonProperty("address")]
    public List<string>? Address { get; set; }

    [JsonProperty("private_key")]
    public string? PrivateKey { get; set; } = string.Empty;

    [JsonProperty("listen_port")]
    public int? ListenPort { get; set; }

    [JsonProperty("peers")]
    public List<WireGuardPeer>? Peers { get; set; }

    [JsonProperty("udp_timeout")]
    public string? UdpTimeout { get; set; }

    [JsonProperty("workers")]
    public int? Workers { get; set; }
}
public sealed class WireGuardPeer
{
    [JsonProperty("address")]
    public string? Address { get; set; }

    [JsonProperty("port")]
    public int? Port { get; set; }

    [JsonProperty("public_key")]
    public string? PublicKey { get; set; }

    [JsonProperty("pre_shared_key")]
    public string? PreSharedKey { get; set; }

    [JsonProperty("allowed_ips")]
    public List<string>? AllowedIps { get; set; }

    [JsonProperty("persistent_keepalive_interval")]
    public int? PersistentKeepaliveInterval { get; set; }

    [JsonProperty("reserved")]
    public List<int>? Reserved { get; set; }
}