using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Transport;

public sealed class HttpTransport : TransportConfig
{
    public HttpTransport()
    {
        Type = "http";
    }

    [JsonProperty("host")]
    public string? Host { get; set; }

    [JsonProperty("path")]
    public string? Path { get; set; }

    [JsonProperty("method")]
    public string? Method { get; set; }

    [JsonProperty("headers")]
    public List<string> Headers { get; set; } = new();

    [JsonProperty("idle_timeout")]
    public string? IdleTimeout { get; set; }

    [JsonProperty("ping_timeout")]
    public string? PingTimeout { get; set; }
}