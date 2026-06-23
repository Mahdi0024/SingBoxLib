namespace SingBoxLib.Configuration.Transport.Abstract;

/// <summary>
/// Represents the base class for V2Ray transport configurations.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(GrpcTransport), "grpc")]
[JsonDerivedType(typeof(HttpTransport), "http")]
[JsonDerivedType(typeof(HttpUpgradeTransport), "httpupgrade")]
[JsonDerivedType(typeof(QuicTransport), "quic")]
[JsonDerivedType(typeof(WebSocketTransport), "ws")]
public abstract class TransportConfig
{
    /// <summary>
    /// Gets or sets the transport type.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; set; }
}