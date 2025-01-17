﻿using SingboxLib.Configuration.Outbound.Shared;
using SingboxLib.Configuration.Transport;
using SingBoxLib.Configuration.Outbound;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport;
using SingBoxLib.Configuration.Transport.Abstract;
using SingBoxLib.Exceptions;
using System.Diagnostics;
using System.Reflection;

namespace SingBoxLib.Parsing;

[DebuggerDisplay("{DebugView()}")]
public class ProfileItem : IEquatable<ProfileItem>
{
    public ProfileType? Type { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public ushort? Port { get; set; }
    public string? Id { get; set; }
    public int? AlterId { get; set; }
    public string? Encryption { get; set; }
    public string? Network { get; set; }
    public string? HeaderType { get; set; }
    public string? RequestHost { get; set; }

    private string? _path;
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
    public string? Security { get; set; }
    public string? AllowInsecure { get; set; }
    public string? Flow { get; set; }
    public string? Sni { get; set; }
    public string? Alpn { get; set; }
    public string? Fingerprint { get; set; }
    public string? PublicKey { get; set; }
    public string? ShortId { get; set; }
    public string? SpiderX { get; set; }
    public string? QuicSecurity { get; set; }
    public string? QuicKey { get; set; }
    public string? GrpcMode { get; set; }
    public string? GrpcServiceName { get; set; }
    public string? KcpSeed { get; set; }
    public string? Password { get; set; }
    public string? Plugin { get; set; }
    public string? PluginArgs { get; set; }
    public int? Version { get; set; }
    public string? ObfsType { get; set; }
    public string? ObfsPassword { get; set; }
    public string? CongestionControl { get; set; }
    public string? UdpRelayMode { get; set; }
    public string? DisableSni { get; set; }


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
                Password = Id,
                Transport = ParseTransport()!,
                Tls = ParseTls()!,
            },
            ProfileType.VMess => new VMessOutbound
            {
                Server = Address,
                ServerPort = (int)Port,
                Uuid = Id,
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
                Uuid = Id,
                CongestionControl = CongestionControl,
                UdpRelayMode = UdpRelayMode,
                Tls = ParseTls(),
            },
            _ => throw new NotImplementedException($"""Profile type "{Type}" is not implemented!""")
        };
    }

    private static string[]? _shadowSocksEncriptions;
    private string ValidateShadowsocksEncryption()
    {
        if (_shadowSocksEncriptions is null)
        {
            var shadowSocksEncriptionFields = typeof(ShadowsocksEncryptions).GetFields(BindingFlags.Static | BindingFlags.Public);
            _shadowSocksEncriptions = shadowSocksEncriptionFields.Select(f => (string)f.GetValue(null)!).ToArray();
        }

        if (_shadowSocksEncriptions.Contains(Encryption))
        {
            return Encryption!;
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

    public static bool operator ==(ProfileItem? left, ProfileItem? right)
    {
        if (left is null || right is null)
            return false;

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

    public static bool operator !=(ProfileItem? left, ProfileItem? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return this == obj as ProfileItem;
    }

    public bool Equals(ProfileItem? other)
    {
        return this == other;
    }

    private string DebugView()
    {
        return this.ToProfileUrl();
    }
}