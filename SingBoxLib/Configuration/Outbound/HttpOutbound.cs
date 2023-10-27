using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class HttpOutbound : OutboundWithDialFields
{
    public HttpOutbound()
    {
        Type = "http";
        Tag = "http-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("path")]
    public string? Path { get; set; }

    [JsonProperty("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}