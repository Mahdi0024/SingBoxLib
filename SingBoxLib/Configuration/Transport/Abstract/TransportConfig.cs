namespace SingBoxLib.Configuration.Transport.Abstract;

public abstract class TransportConfig
{
    [JsonProperty("type")]
    public string? Type { get; set; }
}