namespace SingBoxLib.Configuration.Transport;
internal class HttpUpgradeTransport : TransportConfig
{
    public HttpUpgradeTransport()
    {
        Type = "httpupgrade";
    }
    [JsonPropertyName("host")]
    public string? Host { get; set; }
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("headers")]
    public Dictionary<string, string>? Headers { get; set; }
}
