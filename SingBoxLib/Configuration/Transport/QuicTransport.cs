namespace SingBoxLib.Configuration.Transport;

/// <summary>
/// Represents a QUIC transport configuration.
/// </summary>
public sealed class QuicTransport : TransportConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QuicTransport"/> class.
    /// </summary>
    public QuicTransport()
    {
        Type = "quic";
    }
}