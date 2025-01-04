using SingBoxLib.Configuration.Transport.Abstract;

namespace SingboxLib.Configuration.Transport;
internal class HttpUpgradeTransport : TransportConfig
{
    public HttpUpgradeTransport()
    {
        Type = "httpupgrade";
    }
    [JsonProperty("host")]
    public string? Host { get; set; }
    [JsonProperty("path")]
    public string? Path { get; set; }

    [JsonProperty("headers")]
    public Dictionary<string, string>? Headers { get; set; }
}
