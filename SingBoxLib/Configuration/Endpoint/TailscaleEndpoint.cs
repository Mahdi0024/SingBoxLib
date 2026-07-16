using System.Collections.Generic;
using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Endpoint.Abstract;

namespace SingBoxLib.Configuration.Endpoint;

/// <summary>
/// Tailscale endpoint configuration.
/// </summary>
public sealed class TailscaleEndpoint : EndpointConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TailscaleEndpoint"/> class.
    /// </summary>
    public TailscaleEndpoint()
    {
        Type = "tailscale";
    }

    /// <summary>
    /// The directory where the Tailscale state is stored.
    /// </summary>
    [JsonPropertyName("state_directory")]
    public string? StateDirectory { get; set; }

    /// <summary>
    /// The auth key to create the node.
    /// </summary>
    [JsonPropertyName("auth_key")]
    public string? AuthKey { get; set; }

    /// <summary>
    /// The coordination server URL.
    /// </summary>
    [JsonPropertyName("control_url")]
    public string? ControlUrl { get; set; }

    /// <summary>
    /// Indicates whether the instance should register as an Ephemeral node.
    /// </summary>
    [JsonPropertyName("ephemeral")]
    public bool? Ephemeral { get; set; }

    /// <summary>
    /// The hostname of the node.
    /// </summary>
    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    /// <summary>
    /// Indicates whether the node should accept routes advertised by other nodes.
    /// </summary>
    [JsonPropertyName("accept_routes")]
    public bool? AcceptRoutes { get; set; }

    /// <summary>
    /// The exit node name or IP address to use.
    /// </summary>
    [JsonPropertyName("exit_node")]
    public string? ExitNode { get; set; }

    /// <summary>
    /// Indicates whether locally accessible subnets should be routed directly or via the exit node.
    /// </summary>
    [JsonPropertyName("exit_node_allow_lan_access")]
    public bool? ExitNodeAllowLanAccess { get; set; }

    /// <summary>
    /// CIDR prefixes to advertise into the Tailscale network as reachable through the current node.
    /// </summary>
    [JsonPropertyName("advertise_routes")]
    public List<string>? AdvertiseRoutes { get; set; }

    /// <summary>
    /// Indicates whether the node should advertise itself as an exit node.
    /// </summary>
    [JsonPropertyName("advertise_exit_node")]
    public bool? AdvertiseExitNode { get; set; }

    /// <summary>
    /// Tags to advertise for this node, for ACL enforcement purposes.
    /// </summary>
    [JsonPropertyName("advertise_tags")]
    public List<string>? AdvertiseTags { get; set; }

    /// <summary>
    /// The port to listen on for incoming relay connections.
    /// </summary>
    [JsonPropertyName("relay_server_port")]
    public int? RelayServerPort { get; set; }

    /// <summary>
    /// Static endpoints to advertise for the relay server.
    /// </summary>
    [JsonPropertyName("relay_server_static_endpoints")]
    public List<string>? RelayServerStaticEndpoints { get; set; }

    /// <summary>
    /// Create a system TUN interface for Tailscale.
    /// </summary>
    [JsonPropertyName("system_interface")]
    public bool? SystemInterface { get; set; }

    /// <summary>
    /// Custom TUN interface name.
    /// </summary>
    [JsonPropertyName("system_interface_name")]
    public string? SystemInterfaceName { get; set; }

    /// <summary>
    /// Override the TUN MTU.
    /// </summary>
    [JsonPropertyName("system_interface_mtu")]
    public int? SystemInterfaceMtu { get; set; }

    /// <summary>
    /// UDP NAT expiration time.
    /// </summary>
    [JsonPropertyName("udp_timeout")]
    public string? UdpTimeout { get; set; }

    /// <summary>
    /// Run a Tailscale SSH server on tailnet port 22. Can be bool or TailscaleSshServerConfig object.
    /// </summary>
    [JsonPropertyName("ssh_server")]
    public object? SshServer { get; set; }
}

/// <summary>
/// Configuration for the Tailscale SSH server.
/// </summary>
public sealed class TailscaleSshServerConfig
{
    /// <summary>
    /// Enable the SSH server.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Refuse PTY allocation requests.
    /// </summary>
    [JsonPropertyName("disable_pty")]
    public bool? DisablePty { get; set; }

    /// <summary>
    /// Refuse the SFTP subsystem.
    /// </summary>
    [JsonPropertyName("disable_sftp")]
    public bool? DisableSftp { get; set; }

    /// <summary>
    /// Refuse local and remote TCP/Unix forwarding.
    /// </summary>
    [JsonPropertyName("disable_forwarding")]
    public bool? DisableForwarding { get; set; }
}