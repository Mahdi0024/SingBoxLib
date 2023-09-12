namespace SingBoxLib.Configuration.Experimantal;

public sealed class ExperimentalConfig
{
    [JsonProperty("clash_api")]
    public ClashApi? ClashApi { get; set; }

    [JsonProperty("v2ray_api")]
    public V2rayApi? V2rayApi { get; set; }
}