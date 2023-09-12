using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Transport;

public sealed class GrpcTransport : TransportConfig
{
    public GrpcTransport()
    {
        Type = "grpc";
    }

    [JsonProperty("service_name")]
    public string? ServiceName { get; set; }

    [JsonProperty("idle_timeout")]
    public string? IdleTimeout { get; set; }

    [JsonProperty("ping_timeout")]
    public string? PingTimeout { get; set; }

    [JsonProperty("permit_without_stream")]
    public bool? PermitWithoutStream { get; set; }
}