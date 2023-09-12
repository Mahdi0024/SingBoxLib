using SingBoxLib.Configuration.Outbound;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Parsing;

public class ProfileItem : IEquatable<ProfileItem>
{
    public ProfileType? Type { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int? Port { get; set; }
    public string? Id { get; set; }
    public int? AlterId { get; set; }
    public string? Encryption { get; set; }
    public string? Network { get; set; }
    public string? HeaderType { get; set; }
    public string? RequestHost { get; set; }
    public string? Path { get; set; }
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

    public OutboundConfig ToOutboundConfig()
    {
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
                Port = Port,
                Password = Id,
                Transport = ParseTransport()!,
                Tls = ParseTls()!,
            },
            ProfileType.VMess => new VMessOutbound
            {
                Server = Address,
                ServerPort = Port,
                Uuid = Id,
                Security = Encryption,
                AlterId = AlterId,
                Transport = ParseTransport(),
                Tls = ParseTls(),
            },
            ProfileType.Shadowsocks => new ShadowsocksOutbound
            {
                Server = Address,
                ServerPort = Port,
                Encryption = Encryption,
                Password = Password,
                Plugin = Plugin,
                PluginOptions = PluginArgs,
            },
            ProfileType.Http => new HttpOutbound
            {
                Server = Address,
                ServerPort = Port,
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
            _ => throw new NotImplementedException($"""Profile type "{Type}" is not implemented!""")
        };
    }

    private TransportConfig? ParseTransport()
    {
        return Network switch
        {
            Networks.Grpc => new GrpcTransport { ServiceName = GrpcServiceName },
            Networks.Websocket => new WebSocketTransport { Path = Path },
            Networks.Tcp or Networks.Http or Networks.H2 or null or "" => null,
            _ => throw new NotImplementedException($"""Network type "{Network}" is not implemented!""")
        };
    }

    private TlsConfig? ParseTls()
    {
        return Security is "tls" or "reality" ? new TlsConfig
        {
            Enabled = true,
            Insecure = AllowInsecure is "1" or "true",
            Alpn = Alpn is not null ? new List<string>() { Alpn } : null,
            ServerName = Sni,
            Reality = PublicKey is not null ? new RealityConfig
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

        return hash.ToHashCode();
    }

    public static bool operator ==(ProfileItem? left, ProfileItem? right)
    {
        if (left is null || right is null)
            return false;

        return left.Type == right.Type &&
               left.Address == right.Address &&
               left.Port == right.Port &&
               left.Id == right.Id &&
               left.AlterId == right.AlterId &&
               left.Encryption == right.Encryption &&
               left.Network == right.Network &&
               left.HeaderType == right.HeaderType &&
               left.RequestHost == right.RequestHost &&
               left.Path == right.Path &&
               left.Security == right.Security &&
               left.AllowInsecure == right.AllowInsecure &&
               left.Flow == right.Flow &&
               left.Sni == right.Sni &&
               left.Alpn == right.Alpn &&
               left.Fingerprint == right.Fingerprint &&
               left.PublicKey == right.PublicKey &&
               left.ShortId == right.ShortId &&
               left.SpiderX == right.SpiderX &&
               left.QuicSecurity == right.QuicSecurity &&
               left.QuicKey == right.QuicKey &&
               left.GrpcMode == right.GrpcMode &&
               left.GrpcServiceName == right.GrpcServiceName &&
               left.KcpSeed == right.KcpSeed &&
               left.Password == right.Password;
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
}