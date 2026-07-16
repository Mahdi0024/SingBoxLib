namespace SingBoxLib.Configuration.Service;

/// <summary>
/// Represents the DERP service configuration.
/// </summary>
public sealed class DerpServiceConfig : ServiceWithListenFields
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DerpServiceConfig"/> class.
    /// </summary>
    public DerpServiceConfig()
    {
        Type = "derp";
    }

    /// <summary>
    /// TLS configuration.
    /// </summary>
    [JsonPropertyName("tls")]
    public InboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// Derper configuration file path.
    /// </summary>
    [JsonPropertyName("config_path")]
    public string? ConfigPath { get; set; }

    /// <summary>
    /// Tailscale endpoints tags to verify clients.
    /// </summary>
    [JsonPropertyName("verify_client_endpoint")]
    public List<string>? VerifyClientEndpoint { get; set; }

    /// <summary>
    /// URL to verify clients.
    /// </summary>
    [JsonPropertyName("verify_client_url")]
    public object? VerifyClientUrl { get; set; }

    /// <summary>
    /// What to serve at the root path.
    /// </summary>
    [JsonPropertyName("home")]
    public string? Home { get; set; }

    /// <summary>
    /// Mesh with other DERP servers.
    /// </summary>
    [JsonPropertyName("mesh_with")]
    public List<DerpMeshServer>? MeshWith { get; set; }

    /// <summary>
    /// Pre-shared key for DERP mesh.
    /// </summary>
    [JsonPropertyName("mesh_psk")]
    public string? MeshPsk { get; set; }

    /// <summary>
    /// Pre-shared key file for DERP mesh.
    /// </summary>
    [JsonPropertyName("mesh_psk_file")]
    public string? MeshPskFile { get; set; }

    /// <summary>
    /// STUN server options. Can be a number or stun object.
    /// </summary>
    [JsonPropertyName("stun")]
    public object? Stun { get; set; }
}
