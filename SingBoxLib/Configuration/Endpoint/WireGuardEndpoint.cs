namespace SingBoxLib.Configuration.Endpoint;
/// <summary>
/// Represents a WireGuard endpoint configuration.
/// </summary>
public sealed class WireGuardEndpoint : EndpointConfig
{
    /// <summary>
    /// Gets or sets whether to use system WireGuard.
    /// </summary>
    [JsonPropertyName("system")]
    public bool? System { get; set; }

    /// <summary>
    /// Gets or sets the name of the interface.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the Maximum Transmission Unit (MTU).
    /// </summary>
    [JsonPropertyName("mtu")]
    public int? Mtu { get; set; }

    /// <summary>
    /// Gets or sets the local interface addresses.
    /// </summary>
    [JsonPropertyName("address")]
    public List<string>? Address { get; set; }

    /// <summary>
    /// Gets or sets the private key.
    /// </summary>
    [JsonPropertyName("private_key")]
    public string? PrivateKey { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the listen port.
    /// </summary>
    [JsonPropertyName("listen_port")]
    public int? ListenPort { get; set; }

    /// <summary>
    /// Gets or sets the list of WireGuard peers.
    /// </summary>
    [JsonPropertyName("peers")]
    public List<WireGuardPeer>? Peers { get; set; }

    /// <summary>
    /// Gets or sets the UDP timeout.
    /// </summary>
    [JsonPropertyName("udp_timeout")]
    public string? UdpTimeout { get; set; }

    /// <summary>
    /// Gets or sets the number of workers.
    /// </summary>
    [JsonPropertyName("workers")]
    public int? Workers { get; set; }
}

/// <summary>
/// Represents a WireGuard peer configuration.
/// </summary>
public sealed class WireGuardPeer
{
    /// <summary>
    /// Gets or sets the server address.
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the server port.
    /// </summary>
    [JsonPropertyName("port")]
    public int? Port { get; set; }

    /// <summary>
    /// Gets or sets the public key.
    /// </summary>
    [JsonPropertyName("public_key")]
    public string? PublicKey { get; set; }

    /// <summary>
    /// Gets or sets the pre-shared key.
    /// </summary>
    [JsonPropertyName("pre_shared_key")]
    public string? PreSharedKey { get; set; }

    /// <summary>
    /// Gets or sets the list of allowed IP addresses.
    /// </summary>
    [JsonPropertyName("allowed_ips")]
    public List<string>? AllowedIps { get; set; }

    /// <summary>
    /// Gets or sets the persistent keepalive interval in seconds.
    /// </summary>
    [JsonPropertyName("persistent_keepalive_interval")]
    public int? PersistentKeepaliveInterval { get; set; }

    /// <summary>
    /// Gets or sets the reserved bytes.
    /// </summary>
    [JsonPropertyName("reserved")]
    public List<int>? Reserved { get; set; }
}