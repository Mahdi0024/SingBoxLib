namespace SingBoxLib.Configuration.Endpoint;
/// <summary>
/// Represents a WireGuard endpoint configuration.
/// </summary>
public sealed class WireGuardEndpoint : EndpointConfig
{
    /// <summary>
    /// Gets or sets whether to use system WireGuard.
    /// </summary>
    [JsonProperty("system")]
    public bool? System { get; set; }

    /// <summary>
    /// Gets or sets the name of the interface.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the Maximum Transmission Unit (MTU).
    /// </summary>
    [JsonProperty("mtu")]
    public int? Mtu { get; set; }

    /// <summary>
    /// Gets or sets the local interface addresses.
    /// </summary>
    [JsonProperty("address")]
    public List<string>? Address { get; set; }

    /// <summary>
    /// Gets or sets the private key.
    /// </summary>
    [JsonProperty("private_key")]
    public string? PrivateKey { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the listen port.
    /// </summary>
    [JsonProperty("listen_port")]
    public int? ListenPort { get; set; }

    /// <summary>
    /// Gets or sets the list of WireGuard peers.
    /// </summary>
    [JsonProperty("peers")]
    public List<WireGuardPeer>? Peers { get; set; }

    /// <summary>
    /// Gets or sets the UDP timeout.
    /// </summary>
    [JsonProperty("udp_timeout")]
    public string? UdpTimeout { get; set; }

    /// <summary>
    /// Gets or sets the number of workers.
    /// </summary>
    [JsonProperty("workers")]
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
    [JsonProperty("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the server port.
    /// </summary>
    [JsonProperty("port")]
    public int? Port { get; set; }

    /// <summary>
    /// Gets or sets the public key.
    /// </summary>
    [JsonProperty("public_key")]
    public string? PublicKey { get; set; }

    /// <summary>
    /// Gets or sets the pre-shared key.
    /// </summary>
    [JsonProperty("pre_shared_key")]
    public string? PreSharedKey { get; set; }

    /// <summary>
    /// Gets or sets the list of allowed IP addresses.
    /// </summary>
    [JsonProperty("allowed_ips")]
    public List<string>? AllowedIps { get; set; }

    /// <summary>
    /// Gets or sets the persistent keepalive interval in seconds.
    /// </summary>
    [JsonProperty("persistent_keepalive_interval")]
    public int? PersistentKeepaliveInterval { get; set; }

    /// <summary>
    /// Gets or sets the reserved bytes.
    /// </summary>
    [JsonProperty("reserved")]
    public List<int>? Reserved { get; set; }
}