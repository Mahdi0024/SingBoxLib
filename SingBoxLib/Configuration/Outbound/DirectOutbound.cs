using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class DirectOutbound : OutboundWithDialFields
{
    public DirectOutbound()
    {
        Type = "direct";
        Tag = "direct-out";
    }

    [JsonProperty("override_address")]
    public string? OverrideAddress { get; set; }

    [JsonProperty("override_port")]
    public int? OverridePort { get; set; }

    [JsonProperty("proxy_protocol")]
    public int? ProxyProtocol { get; set; }
}