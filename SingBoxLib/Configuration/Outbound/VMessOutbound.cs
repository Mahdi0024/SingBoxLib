using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Outbound;

/// <summary>
/// Represents configuration for a VLess outbound.
/// </summary>
public sealed class VMessOutbound : OutboundWithDialFields
{
    public VMessOutbound(string? tag = null)
    {
        Type = "vmess";
        Tag = tag ?? "vmess-out";
    }

    /// <summary>
    /// The server address.
    /// </summary>
    [JsonProperty("server")]
    public required string Server { get; set; }

    /// <summary>
    /// The server port.
    /// </summary>
    [JsonProperty("server_port")]
    public required int ServerPort { get; set; }

    /// <summary>
    /// The VMess user id.
    /// </summary>
    [JsonProperty("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// See <see cref="VMessSecurity"/>.
    /// </summary>
    [JsonProperty("security")]
    public string? Security { get; set; }

    /// <summary>
    /// 0:	Use AEAD protocol.
    /// 1:	Use legacy protocol.
    /// >1: Unused, same as 1.
    /// </summary>
    [JsonProperty("alter_id")]
    public int? AlterId { get; set; }

    /// <summary>
    /// One of tcp udp.
    /// Both is enabled by default.
    /// </summary>
    [JsonProperty("network")]
    public string? Network { get; set; }

    /// <summary>
    /// TLS configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/tls/#outbound">TLS</see>.
    /// </summary>
    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }

    /// <summary>
    /// UDP packet encoding.
    /// packetaddr or xudp.
    /// Leave empty to disable.
    /// </summary>
    [JsonProperty("packet_encoding")]
    public string? PacketEncoding { get; set; }

    /// <summary>
    /// V2Ray Transport configuration, see <see href="http://sing-box.sagernet.org/configuration/shared/v2ray-transport/">V2Ray Transport</see>.
    /// </summary>
    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }

    /// <summary>
    /// See <see href="http://sing-box.sagernet.org/configuration/shared/multiplex#outbound">Multiplex</see> for details.
    /// </summary>
    [JsonProperty("multiplex")]
    public MultiplexConfig? Multiplex { get; set; }
}
public static class VMessSecurity
{
    public static readonly string Auto = "auto";
    public static readonly string None = "none";
    public static readonly string Zero = "zero";
    public static readonly string Aes128Gcm = "aes-128-gcm";
    public static readonly string Chacha20Poly1305 = "chacha20-poly1305";

    // Legacy encryption methods
    public static readonly string Aes128Ctr = "aes-128-ctr";
}