using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Transport;

public sealed class QuicTransport : TransportConfig
{
    public QuicTransport()
    {
        Type = "quic";
    }
}