using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Transport;

public sealed class WebSocketTransport : TransportConfig
{
    public WebSocketTransport()
    {
        Type = "ws";
    }

    [JsonProperty("path")]
    public string? Path { get; set; }

    [JsonProperty("headers")]
    public Dictionary<string, string>? Headers { get; set; }

    [JsonProperty("max_early_data")]
    public int? MaxEarlyData { get; set; }

    [JsonProperty("early_data_header_name")]
    public string? EarlyDataHeaderName { get; set; }
}