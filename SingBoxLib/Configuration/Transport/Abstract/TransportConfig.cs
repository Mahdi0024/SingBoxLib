namespace SingBoxLib.Configuration.Transport.Abstract;

/// <summary>
/// Represents the base class for V2Ray transport configurations.
/// </summary>
[JsonDerivedType(typeof(GrpcTransport))]
[JsonDerivedType(typeof(HttpTransport))]
[JsonDerivedType(typeof(HttpUpgradeTransport))]
[JsonDerivedType(typeof(QuicTransport))]
[JsonDerivedType(typeof(WebSocketTransport))]
public abstract class TransportConfig
{
    /// <summary>
    /// Gets or sets the transport type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}