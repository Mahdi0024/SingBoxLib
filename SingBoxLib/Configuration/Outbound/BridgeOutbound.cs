using System.Text.Json.Serialization;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Bridge outbound configuration.
/// </summary>
public sealed class BridgeOutbound : OutboundConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BridgeOutbound"/> class.
    /// </summary>
    public BridgeOutbound()
    {
        Type = "bridge";
    }

    /// <summary>
    /// Interface name for forwarded traffic to egress.
    /// </summary>
    [JsonPropertyName("interface")]
    public string? Interface { get; set; }

    /// <summary>
    /// Custom bridge TUN interface name prefix.
    /// </summary>
    [JsonPropertyName("bridge_name")]
    public string? BridgeName { get; set; }

    /// <summary>
    /// Linux iproute2 table index for pinned egress routes.
    /// </summary>
    [JsonPropertyName("iproute2_table_index")]
    public int? IpRoute2TableIndex { get; set; }

    /// <summary>
    /// Linux iproute2 rule start index.
    /// </summary>
    [JsonPropertyName("iproute2_rule_index")]
    public int? IpRoute2RuleIndex { get; set; }
}