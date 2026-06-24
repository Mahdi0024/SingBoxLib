namespace SingBoxLib.Parsing;

/// <summary>
/// Specifies the type of the proxy profile protocol.
/// </summary>
public enum ProfileType
{
    /// <summary>
    /// VMess protocol.
    /// </summary>
    VMess,

    /// <summary>
    /// VLESS protocol.
    /// </summary>
    VLess,

    /// <summary>
    /// Shadowsocks protocol.
    /// </summary>
    Shadowsocks,

    /// <summary>
    /// Trojan protocol.
    /// </summary>
    Trojan,

    /// <summary>
    /// SOCKS protocol.
    /// </summary>
    Socks,

    /// <summary>
    /// HTTP protocol.
    /// </summary>
    Http,

    /// <summary>
    /// Hysteria 2 protocol.
    /// </summary>
    Hysteria2,

    /// <summary>
    /// TUIC protocol.
    /// </summary>
    Tuic
}
