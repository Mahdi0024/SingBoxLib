using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SingBoxLib.Configuration.Outbound;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport.Abstract;
using SingBoxLib.Configuration.Transport;
using SingBoxLib.Exceptions;

namespace SingBoxLib.Parsing;

/// <summary>
/// Represents parsed proxy connection parameters.
/// </summary>
[DebuggerDisplay("{DebugView()}")]
public class ProfileItem : IEquatable<ProfileItem>
{
    /// <summary>
    /// Gets or sets the profile proxy protocol type.
    /// </summary>
    public ProfileType? Type { get; set; }

    /// <summary>
    /// Gets or sets the proxy node display name/remark.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the server host name or IP address.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the server port.
    /// </summary>
    public ushort? Port { get; set; }

    /// <summary>
    /// Gets or sets the user ID or UUID.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the VMess AlterId.
    /// </summary>
    public int? AlterId { get; set; }

    /// <summary>
    /// Gets or sets the encryption method.
    /// </summary>
    public string? Encryption { get; set; }

    /// <summary>
    /// Gets or sets the transport network type (e.g. tcp, ws, grpc).
    /// </summary>
    public string? Network { get; set; }

    /// <summary>
    /// Gets or sets the header type.
    /// </summary>
    public string? HeaderType { get; set; }

    /// <summary>
    /// Gets or sets the requested Host header.
    /// </summary>
    public string? RequestHost { get; set; }

    private string? _path;

    /// <summary>
    /// Gets or sets the transport request path.
    /// </summary>
    public string? Path
    {
        get
        {
            if (String.IsNullOrWhiteSpace(_path))
            {
                return "/";
            }
            return _path;
        }
        set => _path = value;
    }

    /// <summary>
    /// Gets or sets the security type (e.g. tls, reality).
    /// </summary>
    public string? Security { get; set; }

    /// <summary>
    /// Gets or sets whether to allow insecure certificates.
    /// </summary>
    public string? AllowInsecure { get; set; }

    /// <summary>
    /// Gets or sets the flow control option (VLESS XTLS).
    /// </summary>
    public string? Flow { get; set; }

    /// <summary>
    /// Gets or sets the Server Name Indication (SNI) string.
    /// </summary>
    public string? Sni { get; set; }

    /// <summary>
    /// Gets or sets the Application-Layer Protocol Negotiation (ALPN) values.
    /// </summary>
    public string? Alpn { get; set; }

    /// <summary>
    /// Gets or sets the client fingerprint.
    /// </summary>
    public string? Fingerprint { get; set; }

    /// <summary>
    /// Gets or sets the Reality public key.
    /// </summary>
    public string? PublicKey { get; set; }

    /// <summary>
    /// Gets or sets the Reality ShortId.
    /// </summary>
    public string? ShortId { get; set; }

    /// <summary>
    /// Gets or sets the Reality SpiderX value.
    /// </summary>
    public string? SpiderX { get; set; }

    /// <summary>
    /// Gets or sets the QUIC security type.
    /// </summary>
    public string? QuicSecurity { get; set; }

    /// <summary>
    /// Gets or sets the QUIC key.
    /// </summary>
    public string? QuicKey { get; set; }

    /// <summary>
    /// Gets or sets the gRPC mode.
    /// </summary>
    public string? GrpcMode { get; set; }

    /// <summary>
    /// Gets or sets the gRPC service name.
    /// </summary>
    public string? GrpcServiceName { get; set; }

    /// <summary>
    /// Gets or sets the KCP seed.
    /// </summary>
    public string? KcpSeed { get; set; }

    /// <summary>
    /// Gets or sets the proxy connection password.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets the shadowsocks plugin.
    /// </summary>
    public string? Plugin { get; set; }

    /// <summary>
    /// Gets or sets the shadowsocks plugin arguments.
    /// </summary>
    public string? PluginArgs { get; set; }

    /// <summary>
    /// Gets or sets the SOCKS protocol version.
    /// </summary>
    public int? Version { get; set; }

    /// <summary>
    /// Gets or sets the Hysteria obfuscation type.
    /// </summary>
    public string? ObfsType { get; set; }

    /// <summary>
    /// Gets or sets the Hysteria obfuscation password.
    /// </summary>
    public string? ObfsPassword { get; set; }

    /// <summary>
    /// Gets or sets the TUIC/Hysteria congestion control algorithm.
    /// </summary>
    public string? CongestionControl { get; set; }

    /// <summary>
    /// Gets or sets the TUIC UDP relay mode.
    /// </summary>
    public string? UdpRelayMode { get; set; }

    /// <summary>
    /// Gets or sets whether to disable SNI.
    /// </summary>
    public string? DisableSni { get; set; }

    /// <summary>
    /// Converts the profile item into a sing-box compatible outbound configuration instance.
    /// </summary>
    /// <returns>A mapped <see cref="OutboundConfig"/> subclass.</returns>
    public OutboundConfig ToOutboundConfig()
    {
        if (Address is null || Port is null)
        {
            throw new InvalidProfileException("Address or port is null");
        }

        return Type switch
        {
            ProfileType.VLess => new VLessOutbound
            {
                Server = Address,
                ServerPort = Port,
                Uuid = Id,
                Flow = Flow,
                Transport = ParseTransport(),
                Tls = ParseTls(),
            },
            ProfileType.Trojan => new TrojanOutbound
            {
                Server = Address,
                Port = (int)Port,
                Password = Id!,
                Transport = ParseTransport()!,
                Tls = ParseTls()!,
            },
            ProfileType.VMess => new VMessOutbound
            {
                Server = Address,
                ServerPort = (int)Port,
                Uuid = Id!,
                Security = Encryption,
                AlterId = AlterId,
                Transport = ParseTransport(),
                Tls = ParseTls(),
            },
            ProfileType.Shadowsocks => new ShadowsocksOutbound
            {
                Server = Address,
                ServerPort = (int)Port,
                Encryption = ValidateShadowsocksEncryption(),
                Password = Password,
                Plugin = Plugin,
                PluginOptions = PluginArgs,
            },
            ProfileType.Http => new HttpOutbound
            {
                Server = Address,
                ServerPort = (int)Port,
                Username = Id,
                Password = Password,
                Tls = ParseTls()
            },
            ProfileType.Socks => new SocksOutbound
            {
                Server = Address,
                ServerPort = Port,
                Username = Id,
                Password = Password,
                Version = Version.ToString()
            },
            ProfileType.Hysteria2 => new Hysteria2Outbound
            {
                Server = Address,
                ServerPort = (int)Port,
                Password = Password,
                Obfs = new Hysteria2Obfs
                {
                    Password = ObfsPassword,
                    Type = ObfsType
                },
                Tls = ParseTls() ?? throw new InvalidProfileException("Hysteria2 profile must have TLS"),
            },
            ProfileType.Tuic => new TuicOutbound
            {
                Server = Address,
                ServerPort = (int)Port,
                Password = Password,
                Uuid = Id!,
                CongestionControl = CongestionControl,
                UdpRelayMode = UdpRelayMode,
                Tls = ParseTls(),
            },
            _ => throw new NotImplementedException($"""Profile type "{Type}" is not implemented!""")
        };
    }

    private string ValidateShadowsocksEncryption()
    {
        if (Encryption is not null && ShadowsocksEncryptions.All.Contains(Encryption))
        {
            return Encryption;
        }
        else
        {
            throw new InvalidProfileException($"Invalid Shadowsocks Encryption method: {Encryption}");
        }
    }

    private TransportConfig? ParseTransport()
    {
        return Network switch
        {
            Networks.Grpc => new GrpcTransport { ServiceName = GrpcServiceName },
            Networks.Websocket => new WebSocketTransport { Path = Path },
            Networks.Tcp or Networks.Http or Networks.H2 or null or "" => GetHttpTransport(),
            Networks.HttpUpgrade => new HttpUpgradeTransport { Path = Path, Host = RequestHost },
            _ => throw new NotImplementedException($"""Network type "{Network}" is not implemented!""")
        };

        TransportConfig? GetHttpTransport()
        {
            if (HeaderType is "http")
            {
                return new HttpTransport
                {
                    Method = "get",
                    Host = RequestHost
                };
            }
            return null;
        }
    }

    private OutboundTlsConfig? ParseTls()
    {
        return Security is "tls" or "reality" || Sni is not null || Alpn is not null ? new OutboundTlsConfig
        {
            Enabled = true,
            Insecure = AllowInsecure is "1" or "true",
            Alpn = Alpn is not null ? new List<string>() { Alpn } : null,
            ServerName = Sni,
            DisableSni = DisableSni is "1" or "true" ? true : null,
            Reality = PublicKey is not null ? new OutboundRealityConfig
            {
                Enabled = true,
                PublicKey = PublicKey,
                ShortId = ShortId,
            } : null,
            UTls = Fingerprint is not null ? new()
            {
                Enabled = true,
                Fingerprint = Fingerprint,
            } : null
        } : null;
    }

    /// <summary>
    /// Computes the hash code of the profile item.
    /// </summary>
    /// <returns>A hash code.</returns>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Type);
        hash.Add(Address);
        hash.Add(Port);
        hash.Add(Id);
        hash.Add(AlterId);
        hash.Add(Encryption);
        hash.Add(Network);
        hash.Add(HeaderType);
        hash.Add(RequestHost);
        hash.Add(Path);
        hash.Add(Security);
        hash.Add(AllowInsecure);
        hash.Add(Flow);
        hash.Add(Sni);
        hash.Add(Alpn);
        hash.Add(Fingerprint);
        hash.Add(PublicKey);
        hash.Add(ShortId);
        hash.Add(SpiderX);
        hash.Add(QuicSecurity);
        hash.Add(QuicKey);
        hash.Add(GrpcMode);
        hash.Add(GrpcServiceName);
        hash.Add(KcpSeed);
        hash.Add(Password);
        hash.Add(ObfsType);
        hash.Add(ObfsPassword);
        hash.Add(CongestionControl);
        hash.Add(UdpRelayMode);
        hash.Add(DisableSni);

        return hash.ToHashCode();
    }

    /// <summary>
    /// Compares two profile items for equality.
    /// </summary>
    /// <param name="left">The first item.</param>
    /// <param name="right">The second item.</param>
    /// <returns>True if equal; false otherwise.</returns>
    public static bool operator ==(ProfileItem? left, ProfileItem? right)
    {
        if (left is null || right is null)
            return ReferenceEquals(left, right);

        return left.Type == right.Type &&
           left.Port == right.Port &&
           left.AlterId == right.AlterId &&
           String.Equals(left.Address, right.Address, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Id, right.Id, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Encryption, right.Encryption, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Network, right.Network, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.HeaderType, right.HeaderType, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.RequestHost, right.RequestHost, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Path, right.Path, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Security, right.Security, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.AllowInsecure, right.AllowInsecure, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Flow, right.Flow, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Sni, right.Sni, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Alpn, right.Alpn, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Fingerprint, right.Fingerprint, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.PublicKey, right.PublicKey, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.ShortId, right.ShortId, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.SpiderX, right.SpiderX, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.QuicSecurity, right.QuicSecurity, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.QuicKey, right.QuicKey, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.GrpcMode, right.GrpcMode, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.GrpcServiceName, right.GrpcServiceName, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.KcpSeed, right.KcpSeed, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.Password, right.Password, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.ObfsType, right.ObfsType, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.ObfsPassword, right.ObfsPassword, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.CongestionControl, right.CongestionControl, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.DisableSni, right.DisableSni, StringComparison.OrdinalIgnoreCase) &&
           String.Equals(left.UdpRelayMode, right.UdpRelayMode, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Compares two profile items for inequality.
    /// </summary>
    /// <param name="left">The first item.</param>
    /// <param name="right">The second item.</param>
    /// <returns>True if not equal; false otherwise.</returns>
    public static bool operator !=(ProfileItem? left, ProfileItem? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current profile item.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>True if equal; false otherwise.</returns>
    public override bool Equals(object? obj)
    {
        return this == obj as ProfileItem;
    }

    /// <summary>
    /// Determines whether the specified profile item is equal to the current profile item.
    /// </summary>
    /// <param name="other">The other item to compare.</param>
    /// <returns>True if equal; false otherwise.</returns>
    public bool Equals(ProfileItem? other)
    {
        return this == other;
    }

    private string DebugView()
    {
        return this.ToProfileUrl();
    }
}
