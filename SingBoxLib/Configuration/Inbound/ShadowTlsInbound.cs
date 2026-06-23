namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a ShadowTLS inbound server.
/// </summary>
public sealed class ShadowTlsInbound : InboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ShadowTlsInbound"/> class.
    /// </summary>
    /// <param name="tag">The optional inbound tag.</param>
    public ShadowTlsInbound(string? tag = null)
    {
        Type = "shadowtls";
        Tag = tag ?? "shadowtls-in";
    }

    /// <summary>
    /// The version of the ShadowTLS protocol to use (currently supports v1, v2, and v3).
    /// Version 1 is used by default.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// A password used for authentication in the ShadowTLS protocol (v2).
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// Users associated with this ShadowTLS configuration (available only in ShadowTLS v3).
    /// </summary>
    [JsonPropertyName("users")]
    public List<ProxyUserInbound>? Users { get; set; }

    /// <summary>
    /// Handshake configuration for the ShadowTLS server (v2 and v3).
    /// </summary>
    [JsonPropertyName("handshake")]
    public HandshakeConfig? Handshake { get; set; }

    /// <summary>
    /// Additional handshake configurations for specific server names (available in ShadowTLS v2/3).
    /// </summary>
    [JsonPropertyName("handshake_for_server_name")]
    public Dictionary<string, HandshakeConfig>? HandshakeForServerName { get; set; }

    /// <summary>
    /// Enables strict mode for the ShadowTLS protocol (only in v3).
    /// </summary>
    [JsonPropertyName("strict_mode")]
    public bool? StrictMode { get; set; }
}

