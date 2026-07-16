using System.Collections.Generic;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Endpoint;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// WireGuard outbound configuration.
/// </summary>
public sealed class WireGuardOutbound : OutboundWithDialFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WireGuardOutbound"/> class.
    /// </summary>
    public WireGuardOutbound()
    {
        Type = "wireguard";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonPropertyName("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonPropertyName("server_port")]
    public required int ServerPort { get; set; }

    /// <summary>
    /// Use system interface.
    /// </summary>
    [JsonPropertyName("system_interface")]
    public bool? SystemInterface { get; set; }

    /// <summary>
    /// Custom interface name for system interface.
    /// </summary>
    [JsonPropertyName("interface_name")]
    public string? InterfaceName { get; set; }

    /// <summary>
    /// Try to enable generic segmentation offload.
    /// </summary>
    [JsonPropertyName("gso")]
    public bool? Gso { get; set; }

    /// <summary>
    /// List of IP (v4 or v6) address prefixes assigned to the interface.
    /// </summary>
    [JsonPropertyName("local_address")]
    public List<string>? LocalAddress { get; set; }

    /// <summary>
    /// The private key.
    /// </summary>
    [JsonPropertyName("private_key")]
    public required string PrivateKey { get; set; }

    /// <summary>
    /// Multi-peer support.
    /// </summary>
    [JsonPropertyName("peers")]
    public List<WireGuardPeer>? Peers { get; set; }

    /// <summary>
    /// WireGuard peer public key.
    /// </summary>
    [JsonPropertyName("peer_public_key")]
    public string? PeerPublicKey { get; set; }

    /// <summary>
    /// WireGuard pre-shared key.
    /// </summary>
    [JsonPropertyName("pre_shared_key")]
    public string? PreSharedKey { get; set; }

    /// <summary>
    /// WireGuard reserved field bytes.
    /// </summary>
    [JsonPropertyName("reserved")]
    public List<int>? Reserved { get; set; }

    /// <summary>
    /// WireGuard worker count.
    /// </summary>
    [JsonPropertyName("workers")]
    public int? Workers { get; set; }

    /// <summary>
    /// WireGuard MTU.
    /// </summary>
    [JsonPropertyName("mtu")]
    public int? Mtu { get; set; }

    /// <summary>
    /// Enabled network.
    /// </summary>
    [JsonPropertyName("network")]
    public string? Network { get; set; }
}