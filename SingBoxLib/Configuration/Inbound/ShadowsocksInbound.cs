using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Shared;

namespace SingBoxLib.Configuration.Inbound;

/// <summary>
/// Represents configuration for a Shadowsocks inbound server.
/// </summary>
public sealed class ShadowsocksInbound : InboundConfig
{
    public ShadowsocksInbound(string? tag = null)
    {
        Type = "shadowsocks";
        Tag = tag ?? "shadowsocks-in";
    }

    /// <summary>
    /// Encryption method used for connection. 
    /// For supported methods <see cref="ShadowsocksEncryptions"/>
    /// </summary>
    [JsonProperty("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Authentication password for the Shadowsocks connection.
    /// For newer 2022 methods, use a base64-encoded key of specified length. see <see href="https://sing-box.sagernet.org/configuration/inbound/shadowsocks/#method">Documentation</see>. 
    /// For other methods, any string can be used as a password.
    /// </summary>
    [JsonProperty("password")]
    public string? Password { get; set; }

    /// <summary>
    /// List of users allowed to connect to this inbound configuration.
    /// </summary>
    [JsonProperty("users")]
    public List<ProxyUserInbound>? Users { get; set; }


    [JsonProperty("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}
