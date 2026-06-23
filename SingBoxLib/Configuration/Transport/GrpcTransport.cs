namespace SingBoxLib.Configuration.Transport;

/// <summary>
/// Represents a gRPC transport configuration.
/// </summary>
public sealed class GrpcTransport : TransportConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GrpcTransport"/> class.
    /// </summary>
    public GrpcTransport()
    {
        Type = "grpc";
    }

    /// <summary>
    /// Gets or sets the gRPC service name.
    /// </summary>
    [JsonPropertyName("service_name")]
    public string? ServiceName { get; set; }

    /// <summary>
    /// Gets or sets the idle timeout.
    /// </summary>
    [JsonPropertyName("idle_timeout")]
    public string? IdleTimeout { get; set; }

    /// <summary>
    /// Gets or sets the ping timeout.
    /// </summary>
    [JsonPropertyName("ping_timeout")]
    public string? PingTimeout { get; set; }

    /// <summary>
    /// Gets or sets whether to permit ping without stream.
    /// </summary>
    [JsonPropertyName("permit_without_stream")]
    public bool? PermitWithoutStream { get; set; }
}