using SingBoxLib.Configuration.Inbound.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class DirectInbound : InboundConfig
{
    public DirectInbound()
    {
        Type = "direct";
        Tag = "direct-in";
    }

    [JsonProperty("network")]
    public string? Network { get; set; }

    [JsonProperty("overrive_address")]
    public string? OverrideAddress { get; set; }

    [JsonProperty("pverride_port")]
    public int? OverridePort { get; set; }
}