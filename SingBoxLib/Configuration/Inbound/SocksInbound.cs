using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a Socks4, Socks4a and Socks5 inbound server.
/// </summary>
public sealed class SocksInbound : InboundConfig
{
    public SocksInbound(string? tag = null)
    {
        Type = "socks";
        Tag = tag ?? "socks-in";
    }

    /// <summary>
    /// List of users allowed to connect to this inbound configuration.
    /// No authentication required if empty.
    /// </summary>
    [JsonProperty("users")]
    public List<ProxyUser>? Users { get; set; }
}