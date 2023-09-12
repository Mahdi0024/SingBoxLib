using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class WireGuardOutbound : OutboundWithDialFields
{
    public WireGuardOutbound()
    {
        Type = "wireguard";
        Tag = "wireguard-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("system_interface")]
    public bool? SystemInterface { get; set; }

    [JsonProperty("interface_name")]
    public string? InterfaceName { get; set; }

    [JsonProperty("local_address")]
    public List<string>? LocalAddress { get; set; }

    [JsonProperty("private_key")]
    public string? PrivateKey { get; set; }

    [JsonProperty("peers")]
    public List<WireGuardPeer>? Peers { get; set; }

    [JsonProperty("peer_public_key")]
    public string? PeerPublicKey { get; set; }

    [JsonProperty("pre_shared_key")]
    public string? PreSharedKey { get; set; }

    [JsonProperty("reserved")]
    public List<int>? Reserved { get; set; }

    [JsonProperty("workers")]
    public int? Workers { get; set; }

    [JsonProperty("mtu")]
    public int? Mtu { get; set; }

    [JsonProperty("network")]
    public string? Network { get; set; }
}

public sealed class WireGuardPeer
{
    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("public_key")]
    public string? PublicKey { get; set; }

    [JsonProperty("pre_shared_key")]
    public string? PreSharedKey { get; set; }

    [JsonProperty("allowed_ips")]
    public List<string>? AllowedIps { get; set; }

    [JsonProperty("reserved")]
    public List<int>? Reserved { get; set; }
}