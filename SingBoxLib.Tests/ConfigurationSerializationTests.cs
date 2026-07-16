#pragma warning disable MSTEST0037

using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SingBoxLib.Configuration;
using SingBoxLib.Configuration.Certificate;
using SingBoxLib.Configuration.Service;
using SingBoxLib.Configuration.Service.Abstract;
using SingBoxLib.Configuration.Service.Models;
using SingBoxLib.Configuration.Dns;
using SingBoxLib.Configuration.Dns.Abstract;
using SingBoxLib.Configuration.Endpoint;
using SingBoxLib.Configuration.Endpoint.Abstract;
using SingBoxLib.Configuration.Experimental;
using SingBoxLib.Configuration.Inbound;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Log;
using SingBoxLib.Configuration.Ntp;
using SingBoxLib.Configuration.Outbound;
using SingBoxLib.Configuration.Outbound.Abstract;
using SingBoxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Route;
using SingBoxLib.Configuration.Route.Abstract;
using SingBoxLib.Configuration.Serialization;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport;
using SingBoxLib.Configuration.NetworkNamespace;
using SingBoxLib.Configuration.NetworkNamespace.Abstract;
using SingBoxLib.Configuration.CertificateProvider;
using SingBoxLib.Configuration.CertificateProvider.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace SingBoxLib.Tests;

[TestClass]
public sealed class ConfigurationSerializationTests
{
    private SingBoxConfig CreateFullyPopulatedConfig()
    {
        return new SingBoxConfig
        {
            Log = new LogConfig
            {
                Level = LogLevels.Debug,
                Output = "stdout",
                Timestamp = true
            },
            Ntp = new NtpConfig
            {
                Enabled = true,
                Server = "time.google.com",
                ServerPort = 123,
                Interval = "30m",
                Detour = "direct",
                BindInterface = "eth0",
                INet4BindAddress = "127.0.0.1",
                INet6BindAddress = "::1",
                RoutingMark = 42,
                ReuseAddress = true,
                TcpFastOpen = true,
                TcpMultiPath = true,
                UdpFragment = true,
                ConnectTimeout = "5s",
                DomainResolver = null,
                NetworkType = ["wifi"],
                FallbackNetworkType = ["cellular"],
                FallbackDelay = "300ms"
            },
            Endpoints = new List<EndpointConfig>
            {
                new WireGuardEndpoint
                {
                    Tag = "wg-endpoint",
                    System = false,
                    Name = "wg0",
                    Mtu = 1420,
                    Address = new List<string> { "10.0.0.2/32" },
                    PrivateKey = "privatekeyprivatekeyprivatekeyprivatekey",
                    ListenPort = 51820,
                    Peers = new List<WireGuardPeer>
                    {
                        new WireGuardPeer
                        {
                            Address = "198.51.100.1",
                            Port = 51820,
                            PublicKey = "publickeypublickeypublickeypublickey",
                            PreSharedKey = "presharedkeypresharedkeypresharedkey",
                            AllowedIps = new List<string> { "0.0.0.0/0" },
                            PersistentKeepaliveInterval = 25,
                            Reserved = new List<int> { 0, 0, 0 }
                        }
                    },
                    UdpTimeout = "5m",
                    Workers = 4
                },
                new TailscaleEndpoint
                {
                    Tag = "ts-ep",
                    StateDirectory = "/var/lib/tailscale",
                    AuthKey = "tskey-auth-...",
                    ControlUrl = "https://controlplane.tailscale.com",
                    Ephemeral = true,
                    Hostname = "sing-box",
                    AcceptRoutes = true,
                    ExitNode = "exit-node",
                    ExitNodeAllowLanAccess = true,
                    AdvertiseRoutes = new List<string> { "10.0.0.0/24" },
                    AdvertiseExitNode = true,
                    AdvertiseTags = new List<string> { "tag:server" },
                    RelayServerPort = 41641,
                    RelayServerStaticEndpoints = new List<string> { "127.0.0.1:41641" },
                    SystemInterface = true,
                    SystemInterfaceName = "tailscale0",
                    SystemInterfaceMtu = 1280,
                    UdpTimeout = "5m",
                    SshServer = new TailscaleSshServerConfig { Enabled = true, DisablePty = false }
                }
            },
            Inbounds = new List<InboundConfig>
            {
                new DirectInbound("direct-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 8080,
                    Network = "tcp",
                    OverrideAddress = "1.1.1.1",
                    OverridePort = 80
                },
                new HttpInbound("http-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 8081,
                    Users = new List<ProxyUser> { new ProxyUser { Username = "user", Password = "pwd" } },
                    Tls = new InboundTlsConfig { Enabled = true, ServerName = "example.com" }
                },
                new HysteriaInbound("hysteria-in")
                {
                    Listen = "::",
                    ListenPort = 443,
                    UpMbps = 100,
                    DownMbps = 100,
                    Obfs = "obfs-password"
                },
                new Hysteria2Inbound("hysteria2-in")
                {
                    Listen = "::",
                    ListenPort = 444,
                    UpMbps = 50,
                    DownMbps = 50,
                    Users = new List<ProxyUserInbound> { new ProxyUserInbound { Password = "obfs2-password" } },
                    Obfs = new Hysteria2Obfs { Type = "salamander", Password = "obfs2" }
                },
                new MixedInbound("mixed-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 1080
                },
                new NaiveInbound("naive-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 8082,
                    Network = "tcp"
                },
                new RedirectInbound("redirect-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 8083
                },
                new ShadowsocksInbound("shadowsocks-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 8388,
                    Method = "aes-128-gcm",
                    Password = "sspassword"
                },
                new ShadowTlsInbound("shadowtls-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 8443,
                    Handshake = new HandshakeConfig { Server = "example.com", ServerPort = 443 }
                },
                new SocksInbound("socks-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 1081
                },
                new TransparentProxyInbound("tproxy-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 1082
                },
                new TrojanInbound("trojan-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 8444,
                    Users = new List<ProxyUserInbound> { new ProxyUserInbound { Password = "trojanpassword" } }
                },
                new TuicInbound("tuic-in")
                {
                    Listen = "::",
                    ListenPort = 8445,
                    Users = new List<TuicUser> { new TuicUser { Password = "tuicpassword" } }
                },
                new TunInbound("tun-in")
                {
                    InterfaceName = "tun0",
                    Stack = "gvisor"
                },
                new VLessInbound("vless-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 8446,
                    Users = new List<VLessUser> { new VLessUser { Uuid = "vlessuuid" } }
                },
                new VMessInbound("vmess-in")
                {
                    Listen = "127.0.0.1",
                    ListenPort = 8447,
                    Users = new List<VMessUser> { new VMessUser { Name = "user1", Uuid = "vmessuuid", AlterId = 0 } }
                },
                new CloudflaredInbound
                {
                    Tag = "cloudflared-in",
                    Token = "my-cloudflare-token",
                    HaConnections = 2,
                    Protocol = "quic"
                },
                new SnellInbound
                {
                    Tag = "snell-in",
                    Version = 6,
                    Psk = "password12345",
                    Mode = "default",
                    Users = new List<SnellUser> { new SnellUser { Name = "user1", UserKey = "key1" } }
                },
                new AnyTlsInbound
                {
                    Tag = "anytls-in",
                    Users = new List<AnyTlsUser> { new AnyTlsUser { Name = "user1", Password = "password" } },
                    PaddingScheme = new List<string> { "stop=8" }
                }
            },
            Outbounds = new List<OutboundConfig>
            {
                new DirectOutbound("direct-out")
                {
                    Detour = "upstream",
                    BindInterface = "eth1"
                },
                new HttpOutbound("http-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 8080,
                    Username = "user",
                    Password = "pwd"
                },
                new HysteriaOutbound("hysteria-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 443,
                    UpMbps = 100,
                    DownMbps = 100,
                    Obfs = "obfs-pass"
                },
                new Hysteria2Outbound("hysteria2-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 444,
                    Password = "obfs2-pass",
                    Obfs = new Hysteria2Obfs { Type = "salamander", Password = "obfs2" }
                },
                new SelectorOutbound("selector-out")
                {
                    Outbounds = new List<string> { "direct-out", "socks-out" },
                    Default = "direct-out"
                },
                new ShadowsocksOutbound("shadowsocks-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 8388,
                    Encryption = "aes-128-gcm",
                    Password = "sspassword"
                },
                new ShadowTlsOutbound("shadowtls-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 8443,
                    Password = "shadowtls-pass"
                },
                new SocksOutbound("socks-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 1080,
                    Version = "5",
                    Username = "user",
                    Password = "pwd"
                },
                new SshOutbound("ssh-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 22,
                    User = "sshuser",
                    Password = "sshpassword"
                },
                new TorOutbound("tor-out")
                {
                    ExecutablePath = "/usr/bin/tor",
                    ExtraArgs = new List<string> { "--quiet" }
                },
                new TrojanOutbound("trojan-out")
                {
                    Server = "127.0.0.1",
                    Port = 8444,
                    Password = "trojanpassword"
                },
                new TuicOutbound("tuic-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 8445,
                    Password = "tuicpassword",
                    Uuid = "tuicuuid"
                },
                new UrlTestOutbound("urltest-out")
                {
                    Outbounds = new List<string> { "direct-out", "socks-out" },
                    Url = "https://www.google.com/generate_204",
                    Interval = "10m"
                },
                new VLessOutbound("vless-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 8446,
                    Uuid = "vlessuuid"
                },
                new VMessOutbound("vmess-out")
                {
                    Server = "127.0.0.1",
                    ServerPort = 8447,
                    Uuid = "vmessuuid",
                    Security = "auto"
                },
                new AnyTlsOutbound
                {
                    Tag = "anytls-out",
                    Server = "127.0.0.1",
                    ServerPort = 1080,
                    Password = "password",
                    Tls = new OutboundTlsConfig { Enabled = true }
                },
                new SnellOutbound
                {
                    Tag = "snell-out",
                    Server = "127.0.0.1",
                    ServerPort = 1080,
                    Version = 6,
                    Psk = "password12345",
                    Mode = "default"
                },
                new BridgeOutbound
                {
                    Tag = "bridge-out",
                    Interface = "eth0",
                    BridgeName = "br0"
                },
                new BlockOutbound
                {
                    Tag = "block-out"
                },
                new WireGuardOutbound
                {
                    Tag = "wireguard-out",
                    Server = "127.0.0.1",
                    ServerPort = 51820,
                    PrivateKey = "private-key"
                }
            },
            Route = new RouteConfig
            {
                Final = "direct-out",
                AutoDetectInterface = true,
                OverrideAndroidVpn = false,
                DefaultInterface = "eth0",
                DefaultMark = 100,
                DefaultNetworkStrategy = "fallback",
                DefaultNetworkType = new List<string> { "wifi" },
                DefaultFallbackNetworkType = new List<string> { "cellular" },
                DefaultFallbackDelay = "300ms",
                FindProcess = true,
                FindNeighbor = true,
                DhcpLeaseFiles = new List<string> { "/var/lib/dhcp/dhcpd.leases" },
                Rules = new List<RouteRuleBase>
                {
                    new RouteRule
                    {
                        Action = new RuleAction { Action = "route", Outbound = "direct-out" },
                        Network = new List<string> { "tcp" },
                        Domain = new List<string> { "example.com" },
                        IpCidr = new List<string> { "127.0.0.1/32" }
                    },
                    new RouteLogicalRule
                    {
                        Mode = "and",
                        Invert = false,
                        Action = new RuleAction { Action = "route", Outbound = "direct-out" },
                        Rules = new List<RouteRuleBase>
                        {
                            new RouteRule
                            {
                                Action = new RuleAction { Action = "route", Outbound = "direct-out" },
                                Domain = new List<string> { "sub.example.com" }
                            }
                        }
                    }
                },
                RuleSet = new List<RouteRuleSetBase>
                {
                    new RouteRuleSetInline
                    {
                        Tag = "inline-ruleset",
                        Rules = new List<RouteRuleHeadlessBase>
                        {
                            new RouteRuleHeadless
                            {
                                Network = new List<string> { "tcp" },
                                Domain = new List<string> { "example.com" }
                            }
                        }
                    },
                    new RouteRuleSetLocal
                    {
                        Tag = "local-ruleset",
                        Format = "source",
                        Path = "/etc/sing-box/rules.json"
                    },
                    new RouteRuleSetRemote
                    {
                        Tag = "remote-ruleset",
                        Format = "binary",
                        Url = "https://example.com/rules.srs",
                        UpdateInterval = "1d"
                    }
                }
            },
            Dns = new DnsConfig
            {
                Final = "local-dns",
                Strategy = DnsStrategy.PreferIpv4,
                DisableCache = false,
                DisableExpire = true,
                CacheCapacity = 2048,
                ReverseMapping = true,
                ClientSubnet = "1.1.1.1",
                Servers = new List<DnsServer>
                {
                    new LocalDnsServer
                    {
                        Tag = "local-dns",
                        PreferGo = true,
                        NeighborDomain = new List<string> { ".lan" }
                    },
                    new HostsDnsServer
                    {
                        Tag = "hosts-dns",
                        Path = new List<string> { "/etc/hosts" },
                        Predefined = new Dictionary<string, object>
                        {
                            { "example.com", "127.0.0.1" }
                        }
                    },
                    new TcpDnsServer
                    {
                        Tag = "tcp-dns",
                        Server = "8.8.8.8",
                        ServerPort = 53
                    },
                    new UdpDnsServer
                    {
                        Tag = "udp-dns",
                        Server = "8.8.4.4",
                        ServerPort = 53
                    },
                    new TlsDnsServer
                    {
                        Tag = "tls-dns",
                        Server = "1.1.1.1",
                        ServerPort = 853,
                        Tls = new OutboundTlsConfig { Enabled = true, ServerName = "cloudflare-dns.com" }
                    },
                    new QuicDnsServer
                    {
                        Tag = "quic-dns",
                        Server = "9.9.9.9",
                        ServerPort = 853,
                        Tls = new OutboundTlsConfig { Enabled = true, ServerName = "dns.quad9.net" }
                    },
                    new HttpsDnsServer
                    {
                        Tag = "https-dns",
                        Server = "1.1.1.1",
                        ServerPort = 443,
                        Path = "/dns-query",
                        Headers = new Dictionary<string, string> { { "User-Agent", "sing-box" } },
                        Tls = new OutboundTlsConfig { Enabled = true }
                    },
                    new H3DnsServer
                    {
                        Tag = "h3-dns",
                        Server = "1.1.1.1",
                        ServerPort = 443,
                        Path = "/dns-query",
                        Headers = new Dictionary<string, string> { { "User-Agent", "sing-box" } },
                        Tls = new OutboundTlsConfig { Enabled = true }
                    },
                    new DhcpDnsServer
                    {
                        Tag = "dhcp-dns",
                        Interface = "eth0"
                    },
                    new MdnsDnsServer
                    {
                        Tag = "mdns-dns",
                        Interface = new List<string> { "eth0" }
                    },
                    new FakeIpDnsServer
                    {
                        Tag = "fakeip-dns",
                        Inet4Range = "198.18.0.0/15",
                        Inet6Range = "fc00::/18"
                    },
                    new TailscaleDnsServer
                    {
                        Tag = "tailscale-dns",
                        Endpoint = "ts-ep",
                        AcceptDefaultResolvers = true,
                        AcceptSearchDomain = true
                    },
                    new ResolvedDnsServer
                    {
                        Tag = "resolved-dns",
                        Service = "resolved-service",
                        AcceptDefaultResolvers = true
                    }
                },
                Rules = new List<DnsRuleBase>
                {
                    new DnsRule
                    {
                        Action = new DnsAction { Server = "local-dns", ClientSubnet = "1.1.1.1" },
                        Domain = new List<string> { "example.com" }
                    },
                    new DnsLogicalRule
                    {
                        Mode = "and",
                        Rules = new List<DnsRuleBase>
                        {
                            new DnsRule
                            {
                                Action = new DnsAction { Server = "local-dns" },
                                Domain = new List<string> { "sub.example.com" }
                            }
                        },
                        Action = new DnsAction { Action = "route", Server = "local-dns" }
                    }
                },
                Fakeip = new FakeIp
                {
                    Enabled = true,
                    Inet4Range = "198.18.0.0/15",
                    Inet6Range = "fc00::/18"
                }
            },
            Experimental = new ExperimentalConfig
            {
                ClashApi = new ClashApi
                {
                    ExternalController = "127.0.0.1:9090",
                    ExternalUi = "ui",
                    Secret = "secretkey",
                    DefaultMode = "rule"
                },
                CacheFile = new CacheFile
                {
                    Enabled = true,
                    Path = "cache.db",
                    CacheId = "mycache",
                    StoreRdrc = true,
                    RdrcTimeout = "7d"
                },
                Api = new V2rayApi
                {
                    Listen = "127.0.0.1:8080",
                    Stats = new Stats
                    {
                        Enabled = true,
                        Inbounds = new List<string> { "socks-in" },
                        Outbounds = new List<string> { "direct-out" }
                    }
                }
            },
            Certificate = new CertificateConfig
            {
                Store = "mozilla",
                Certificate = new List<string> { "-----BEGIN CERTIFICATE-----\n...\n-----END CERTIFICATE-----" },
                CertificatePath = new List<string> { "/etc/ssl/certs/ca-certificates.crt" }
            },
            Services = new List<ServiceConfig>
            {
                new ApiServiceConfig
                {
                    Tag = "api-service",
                    Secret = "mysecret",
                    Dashboard = true
                },
                new CcmServiceConfig
                {
                    Tag = "ccm-service",
                    CredentialPath = "/path/to/creds.json",
                    UsagesPath = "/path/to/usages.json",
                    Users = new List<CcmUser> { new CcmUser { Name = "alice", Token = "tok1" } },
                    Headers = new Dictionary<string, string> { { "Custom-Header", "Value" } }
                },
                new DerpServiceConfig
                {
                    Tag = "derp-service",
                    ConfigPath = "derper.key",
                    VerifyClientEndpoint = new List<string> { "wg-endpoint" },
                    VerifyClientUrl = "https://example.com/verify",
                    Home = "blank",
                    MeshWith = new List<DerpMeshServer>
                    {
                        new DerpMeshServer
                        {
                            Server = "127.0.0.1",
                            ServerPort = "8080",
                            Host = "derp-mesh",
                            Tls = new OutboundTlsConfig { Enabled = true }
                        }
                    },
                    MeshPsk = "secret-psk",
                    Stun = 3478
                },
                new HysteriaRealmServiceConfig
                {
                    Tag = "hysteria-realm-service",
                    Users = new List<HysteriaRealmUser> { new HysteriaRealmUser { Name = "realm-user", Token = "realm-tok", MaxRealms = 5 } }
                },
                new OcmServiceConfig
                {
                    Tag = "ocm-service",
                    CredentialPath = "/path/to/ocm.json",
                    UsagesPath = "/path/to/ocm-usages.json",
                    Users = new List<OcmUser> { new OcmUser { Name = "bob", Token = "ocm-tok" } },
                    Headers = new Dictionary<string, string> { { "Ocm-Header", "Val" } }
                },
                new ResolvedServiceConfig
                {
                    Tag = "resolved-service",
                    Listen = "127.0.0.53",
                    ListenPort = 53
                },
                new SsmApiServiceConfig
                {
                    Tag = "ssm-api-service",
                    Servers = new Dictionary<string, string> { { "/", "ss-in" } },
                    CachePath = "/path/to/ssm-cache.json"
                },
                new UsbipServerServiceConfig
                {
                    Tag = "usbip-server-service",
                    Provider = "default",
                    Devices = new List<UsbDeviceMatch> { new UsbDeviceMatch { BusId = "1-2", VendorId = 123, ProductId = 456, Serial = "12345" } }
                },
                new UsbipClientServiceConfig
                {
                    Tag = "usbip-client-service",
                    Server = "127.0.0.1",
                    ServerPort = 3240,
                    Devices = new List<UsbDeviceMatch> { new UsbDeviceMatch { BusId = "1-2", VendorId = 123, ProductId = 456, Serial = "12345" } }
                }
            },
            HttpClients = new List<HttpClientConfig>
            {
                new HttpClientConfig
                {
                    Tag = "my-http-client",
                    Engine = "go",
                    Version = 2,
                    DisableVersionFallback = false,
                    Headers = new Dictionary<string, string> { { "User-Agent", "sing-box" } },
                    Detour = "direct"
                }
            },
            CertificateProviders = new List<CertificateProviderConfig>
            {
                new AcmeCertificateProvider
                {
                    Tag = "acme-prov",
                    Domain = new List<string> { "example.com" },
                    Email = "admin@example.com",
                    Provider = "letsencrypt"
                },
                new TailscaleCertificateProvider
                {
                    Tag = "ts-prov",
                    Endpoint = "ts-ep"
                },
                new CloudflareOriginCaCertificateProvider
                {
                    Tag = "cf-prov",
                    Domain = new List<string> { "example.com" },
                    ApiToken = "token"
                }
            },
            NetworkNamespaces = new List<NetworkNamespaceConfig>
            {
                new DefaultNetworkNamespace
                {
                    Tag = "netns-default",
                    Path = "sing"
                },
                new UnshareNetworkNamespace
                {
                    Tag = "netns-unshare",
                    PidFile = "sing.pid"
                }
            }
        };
    }

    [TestMethod]
    public void SingBoxConfig_ShouldSerializeAllConfigurationTypes()
    {
        var config = CreateFullyPopulatedConfig();

        // Act
        string json = config.ToJson();

        // Assert
        Assert.IsFalse(string.IsNullOrEmpty(json), "Serialized JSON should not be null or empty.");

        // Verify it is a valid JSON document
        using var document = JsonDocument.Parse(json);
        var root = document.RootElement;

        // Verify structural presence of root sections
        Assert.IsTrue(root.TryGetProperty("log", out var logProp));
        Assert.AreEqual("debug", logProp.GetProperty("level").GetString());

        Assert.IsTrue(root.TryGetProperty("ntp", out var ntpProp));
        Assert.AreEqual("time.google.com", ntpProp.GetProperty("server").GetString());

        Assert.IsTrue(root.TryGetProperty("endpoints", out var endpointsProp));
        Assert.AreEqual(2, endpointsProp.GetArrayLength());
        Assert.AreEqual("wg-endpoint", endpointsProp[0].GetProperty("tag").GetString());
        Assert.AreEqual("ts-ep", endpointsProp[1].GetProperty("tag").GetString());

        Assert.IsTrue(root.TryGetProperty("inbounds", out var inboundsProp));
        Assert.AreEqual(19, inboundsProp.GetArrayLength());

        // Verify every inbound type serialized correctly
        var inboundTypes = inboundsProp.EnumerateArray().Select(x => x.GetProperty("type").GetString()).ToList();
        CollectionAssert.Contains(inboundTypes, "direct");
        CollectionAssert.Contains(inboundTypes, "http");
        CollectionAssert.Contains(inboundTypes, "hysteria");
        CollectionAssert.Contains(inboundTypes, "hysteria2");
        CollectionAssert.Contains(inboundTypes, "mixed");
        CollectionAssert.Contains(inboundTypes, "naive");
        CollectionAssert.Contains(inboundTypes, "redirect");
        CollectionAssert.Contains(inboundTypes, "shadowsocks");
        CollectionAssert.Contains(inboundTypes, "shadowtls");
        CollectionAssert.Contains(inboundTypes, "socks");
        CollectionAssert.Contains(inboundTypes, "tproxy");
        CollectionAssert.Contains(inboundTypes, "trojan");
        CollectionAssert.Contains(inboundTypes, "tuic");
        CollectionAssert.Contains(inboundTypes, "tun");
        CollectionAssert.Contains(inboundTypes, "vless");
        CollectionAssert.Contains(inboundTypes, "vmess");
        CollectionAssert.Contains(inboundTypes, "cloudflared");
        CollectionAssert.Contains(inboundTypes, "snell");
        CollectionAssert.Contains(inboundTypes, "anytls");

        Assert.IsTrue(root.TryGetProperty("outbounds", out var outboundsProp));
        Assert.AreEqual(20, outboundsProp.GetArrayLength());

        // Verify every outbound type serialized correctly
        var outboundTypes = outboundsProp.EnumerateArray().Select(x => x.GetProperty("type").GetString()).ToList();
        CollectionAssert.Contains(outboundTypes, "direct");
        CollectionAssert.Contains(outboundTypes, "http");
        CollectionAssert.Contains(outboundTypes, "hysteria");
        CollectionAssert.Contains(outboundTypes, "hysteria2");
        CollectionAssert.Contains(outboundTypes, "selector");
        CollectionAssert.Contains(outboundTypes, "shadowsocks");
        CollectionAssert.Contains(outboundTypes, "shadowtls");
        CollectionAssert.Contains(outboundTypes, "socks");
        CollectionAssert.Contains(outboundTypes, "ssh");
        CollectionAssert.Contains(outboundTypes, "tor");
        CollectionAssert.Contains(outboundTypes, "trojan");
        CollectionAssert.Contains(outboundTypes, "tuic");
        CollectionAssert.Contains(outboundTypes, "urltest");
        CollectionAssert.Contains(outboundTypes, "vless");
        CollectionAssert.Contains(outboundTypes, "vmess");
        CollectionAssert.Contains(outboundTypes, "anytls");
        CollectionAssert.Contains(outboundTypes, "snell");
        CollectionAssert.Contains(outboundTypes, "bridge");
        CollectionAssert.Contains(outboundTypes, "block");
        CollectionAssert.Contains(outboundTypes, "wireguard");

        Assert.IsTrue(root.TryGetProperty("route", out var routeProp));
        Assert.AreEqual("direct-out", routeProp.GetProperty("final").GetString());
        Assert.AreEqual(2, routeProp.GetProperty("rules").GetArrayLength());
        Assert.AreEqual(3, routeProp.GetProperty("rule_set").GetArrayLength());

        Assert.IsTrue(root.TryGetProperty("dns", out var dnsProp));
        Assert.AreEqual("local-dns", dnsProp.GetProperty("final").GetString());
        Assert.AreEqual(13, dnsProp.GetProperty("servers").GetArrayLength());
        Assert.AreEqual(2, dnsProp.GetProperty("rules").GetArrayLength());

        var serverTypes = dnsProp.GetProperty("servers").EnumerateArray().Select(x => x.GetProperty("type").GetString()).ToList();
        CollectionAssert.Contains(serverTypes, "local");
        CollectionAssert.Contains(serverTypes, "hosts");
        CollectionAssert.Contains(serverTypes, "tcp");
        CollectionAssert.Contains(serverTypes, "udp");
        CollectionAssert.Contains(serverTypes, "tls");
        CollectionAssert.Contains(serverTypes, "quic");
        CollectionAssert.Contains(serverTypes, "https");
        CollectionAssert.Contains(serverTypes, "h3");
        CollectionAssert.Contains(serverTypes, "dhcp");
        CollectionAssert.Contains(serverTypes, "mdns");
        CollectionAssert.Contains(serverTypes, "fakeip");
        CollectionAssert.Contains(serverTypes, "tailscale");
        CollectionAssert.Contains(serverTypes, "resolved");

        Assert.IsTrue(root.TryGetProperty("certificate", out var certProp));
        Assert.AreEqual("mozilla", certProp.GetProperty("store").GetString());

        Assert.IsTrue(root.TryGetProperty("services", out var servicesProp));
        Assert.AreEqual(9, servicesProp.GetArrayLength());

        var serviceTypes = servicesProp.EnumerateArray().Select(x => x.GetProperty("type").GetString()).ToList();
        CollectionAssert.Contains(serviceTypes, "api");
        CollectionAssert.Contains(serviceTypes, "ccm");
        CollectionAssert.Contains(serviceTypes, "derp");
        CollectionAssert.Contains(serviceTypes, "hysteria-realm");
        CollectionAssert.Contains(serviceTypes, "ocm");
        CollectionAssert.Contains(serviceTypes, "resolved");
        CollectionAssert.Contains(serviceTypes, "ssm-api");
        CollectionAssert.Contains(serviceTypes, "usbip-server");
        CollectionAssert.Contains(serviceTypes, "usbip-client");

        Assert.IsTrue(root.TryGetProperty("experimental", out var expProp));
        Assert.IsTrue(expProp.TryGetProperty("clash_api", out var clashProp));
        Assert.AreEqual("127.0.0.1:9090", clashProp.GetProperty("external_controller").GetString());

        Assert.IsTrue(root.TryGetProperty("network_namespaces", out var netnsProp));
        Assert.AreEqual(2, netnsProp.GetArrayLength());

        Assert.IsTrue(root.TryGetProperty("certificate_providers", out var certProvProp));
        Assert.AreEqual(3, certProvProp.GetArrayLength());

        Assert.IsTrue(root.TryGetProperty("http_clients", out var httpClientsProp));
        Assert.AreEqual(1, httpClientsProp.GetArrayLength());
    }

    [TestMethod]
    public void SingBoxConfig_ShouldSerializeAndDeserializeCorrectly()
    {
        var config = CreateFullyPopulatedConfig();

        // Act
        string json = config.ToJson();

        // Try deserializing it back
        var deserialized = SingBoxConfig.FromJson(json);

        // Assert
        Assert.IsNotNull(deserialized, "Deserialized config should not be null.");
        Assert.IsNotNull(deserialized.Log, "Deserialized Log config should not be null.");
        Assert.AreEqual(LogLevels.Debug, deserialized.Log.Level);
        Assert.IsNotNull(deserialized.Ntp, "Deserialized Ntp config should not be null.");
        Assert.AreEqual("time.google.com", deserialized.Ntp.Server);

        Assert.IsNotNull(deserialized.Endpoints, "Deserialized Endpoints should not be null.");
        Assert.AreEqual(2, deserialized.Endpoints.Count);
        var endpoint = deserialized.Endpoints[0] as WireGuardEndpoint;
        Assert.IsNotNull(endpoint, "Deserialized endpoint should be a WireGuardEndpoint.");
        Assert.AreEqual("wg-endpoint", endpoint.Tag);
        Assert.IsNotNull(endpoint.Peers);
        Assert.AreEqual(1, endpoint.Peers.Count);
        Assert.AreEqual("198.51.100.1", endpoint.Peers[0].Address);

        var tsEndpoint = deserialized.Endpoints[1] as TailscaleEndpoint;
        Assert.IsNotNull(tsEndpoint, "Deserialized endpoint should be a TailscaleEndpoint.");
        Assert.AreEqual("ts-ep", tsEndpoint.Tag);
        Assert.AreEqual("/var/lib/tailscale", tsEndpoint.StateDirectory);

        Assert.IsNotNull(deserialized.Inbounds, "Deserialized Inbounds should not be null.");
        Assert.AreEqual(19, deserialized.Inbounds.Count);

        Assert.IsNotNull(deserialized.Outbounds, "Deserialized Outbounds should not be null.");
        Assert.AreEqual(20, deserialized.Outbounds.Count);

        Assert.IsNotNull(deserialized.Route, "Deserialized Route should not be null.");
        Assert.AreEqual("direct-out", deserialized.Route.Final);
        Assert.IsNotNull(deserialized.Route.Rules, "Deserialized Route.Rules should not be null.");
        Assert.AreEqual(2, deserialized.Route.Rules.Count);
        Assert.IsNotNull(deserialized.Route.RuleSet, "Deserialized Route.RuleSet should not be null.");
        Assert.AreEqual(3, deserialized.Route.RuleSet.Count);

        Assert.IsNotNull(deserialized.Dns, "Deserialized Dns should not be null.");
        Assert.AreEqual("local-dns", deserialized.Dns.Final);
        Assert.IsNotNull(deserialized.Dns.Servers, "Deserialized Dns.Servers should not be null.");
        Assert.AreEqual(13, deserialized.Dns.Servers.Count);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[0], typeof(LocalDnsServer));
        Assert.AreEqual(true, ((LocalDnsServer)deserialized.Dns.Servers[0]).PreferGo);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[1], typeof(HostsDnsServer));
        Assert.AreEqual("/etc/hosts", ((HostsDnsServer)deserialized.Dns.Servers[1]).Path?[0]);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[2], typeof(TcpDnsServer));
        Assert.AreEqual("8.8.8.8", ((TcpDnsServer)deserialized.Dns.Servers[2]).Server);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[3], typeof(UdpDnsServer));
        Assert.AreEqual("8.8.4.4", ((UdpDnsServer)deserialized.Dns.Servers[3]).Server);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[4], typeof(TlsDnsServer));
        Assert.AreEqual("cloudflare-dns.com", ((TlsDnsServer)deserialized.Dns.Servers[4]).Tls?.ServerName);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[5], typeof(QuicDnsServer));
        Assert.AreEqual("dns.quad9.net", ((QuicDnsServer)deserialized.Dns.Servers[5]).Tls?.ServerName);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[6], typeof(HttpsDnsServer));
        Assert.AreEqual("/dns-query", ((HttpsDnsServer)deserialized.Dns.Servers[6]).Path);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[7], typeof(H3DnsServer));
        Assert.AreEqual("/dns-query", ((H3DnsServer)deserialized.Dns.Servers[7]).Path);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[8], typeof(DhcpDnsServer));
        Assert.AreEqual("eth0", ((DhcpDnsServer)deserialized.Dns.Servers[8]).Interface);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[9], typeof(MdnsDnsServer));
        Assert.AreEqual("eth0", ((MdnsDnsServer)deserialized.Dns.Servers[9]).Interface?[0]);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[10], typeof(FakeIpDnsServer));
        Assert.AreEqual("198.18.0.0/15", ((FakeIpDnsServer)deserialized.Dns.Servers[10]).Inet4Range);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[11], typeof(TailscaleDnsServer));
        Assert.AreEqual("ts-ep", ((TailscaleDnsServer)deserialized.Dns.Servers[11]).Endpoint);

        Assert.IsInstanceOfType(deserialized.Dns.Servers[12], typeof(ResolvedDnsServer));
        Assert.AreEqual("resolved-service", ((ResolvedDnsServer)deserialized.Dns.Servers[12]).Service);

        Assert.IsNotNull(deserialized.Dns.Rules, "Deserialized Dns.Rules should not be null.");
        Assert.AreEqual(2, deserialized.Dns.Rules.Count);
        Assert.IsNotNull(deserialized.Dns.Fakeip, "Deserialized Dns.Fakeip should not be null.");
        Assert.IsTrue(deserialized.Dns.Fakeip.Enabled == true);

        Assert.IsNotNull(deserialized.Certificate, "Deserialized Certificate should not be null.");
        Assert.AreEqual("mozilla", deserialized.Certificate.Store);

        Assert.IsNotNull(deserialized.Services, "Deserialized Services should not be null.");
        Assert.AreEqual(9, deserialized.Services.Count);

        Assert.IsInstanceOfType(deserialized.Services[0], typeof(ApiServiceConfig));
        Assert.AreEqual("mysecret", ((ApiServiceConfig)deserialized.Services[0]).Secret);

        Assert.IsInstanceOfType(deserialized.Services[1], typeof(CcmServiceConfig));
        Assert.AreEqual("/path/to/creds.json", ((CcmServiceConfig)deserialized.Services[1]).CredentialPath);

        Assert.IsInstanceOfType(deserialized.Services[2], typeof(DerpServiceConfig));
        Assert.AreEqual("derper.key", ((DerpServiceConfig)deserialized.Services[2]).ConfigPath);

        Assert.IsInstanceOfType(deserialized.Services[3], typeof(HysteriaRealmServiceConfig));
        Assert.AreEqual("hysteria-realm-service", ((HysteriaRealmServiceConfig)deserialized.Services[3]).Tag);

        Assert.IsInstanceOfType(deserialized.Services[4], typeof(OcmServiceConfig));
        Assert.AreEqual("/path/to/ocm.json", ((OcmServiceConfig)deserialized.Services[4]).CredentialPath);

        Assert.IsInstanceOfType(deserialized.Services[5], typeof(ResolvedServiceConfig));
        Assert.AreEqual("127.0.0.53", ((ResolvedServiceConfig)deserialized.Services[5]).Listen);

        Assert.IsInstanceOfType(deserialized.Services[6], typeof(SsmApiServiceConfig));
        Assert.AreEqual("/path/to/ssm-cache.json", ((SsmApiServiceConfig)deserialized.Services[6]).CachePath);

        Assert.IsInstanceOfType(deserialized.Services[7], typeof(UsbipServerServiceConfig));
        Assert.AreEqual("default", ((UsbipServerServiceConfig)deserialized.Services[7]).Provider);

        Assert.IsInstanceOfType(deserialized.Services[8], typeof(UsbipClientServiceConfig));
        Assert.AreEqual("127.0.0.1", ((UsbipClientServiceConfig)deserialized.Services[8]).Server);

        Assert.IsNotNull(deserialized.Experimental, "Deserialized Experimental should not be null.");
        Assert.IsNotNull(deserialized.Experimental.ClashApi, "ClashApi should not be null.");
        Assert.AreEqual("127.0.0.1:9090", deserialized.Experimental.ClashApi.ExternalController);

        Assert.IsNotNull(deserialized.NetworkNamespaces);
        Assert.AreEqual(2, deserialized.NetworkNamespaces.Count);
        Assert.IsInstanceOfType(deserialized.NetworkNamespaces[0], typeof(DefaultNetworkNamespace));
        Assert.IsInstanceOfType(deserialized.NetworkNamespaces[1], typeof(UnshareNetworkNamespace));

        Assert.IsNotNull(deserialized.CertificateProviders);
        Assert.AreEqual(3, deserialized.CertificateProviders.Count);
        Assert.IsInstanceOfType(deserialized.CertificateProviders[0], typeof(AcmeCertificateProvider));
        Assert.IsInstanceOfType(deserialized.CertificateProviders[1], typeof(TailscaleCertificateProvider));
        Assert.IsInstanceOfType(deserialized.CertificateProviders[2], typeof(CloudflareOriginCaCertificateProvider));

        Assert.IsNotNull(deserialized.HttpClients);
        Assert.AreEqual(1, deserialized.HttpClients.Count);
        Assert.IsInstanceOfType(deserialized.HttpClients[0], typeof(HttpClientConfig));

        // Serialize again
        string secondJson = deserialized.ToJson();

        // Assert reserialized matches the first serialization
        Assert.AreEqual(json, secondJson, "Reserialized JSON should be identical to the first serialized JSON.");
    }

    [TestMethod]
    public void SingBoxConfig_ShouldSerializeWithIndentation()
    {
        var config = CreateFullyPopulatedConfig();

        // Act
        string indentedJson = config.ToJson(writeIndented: true);

        // Assert
        Assert.IsTrue(indentedJson.Contains("\n") || indentedJson.Contains("\r"), "Indented JSON should contain newline characters.");

        // Deserialize it back
        var deserialized = SingBoxConfig.FromJson(indentedJson);
        Assert.IsNotNull(deserialized, "Deserialized config from indented JSON should not be null.");
        Assert.IsNotNull(deserialized.Log, "Deserialized Log config should not be null.");
        Assert.AreEqual(LogLevels.Debug, deserialized.Log.Level);
    }

    [TestMethod]
    public void SingBoxConfig_ShouldDeserializeListOfOutboundsAndInbounds()
    {
        var outboundsJson = """
        [
            { "type": "direct", "tag": "out1" },
            { "type": "socks", "tag": "out2", "server": "1.1.1.1", "server_port": 1080 }
        ]
        """;

        var inboundsJson = """
        [
            { "type": "direct", "tag": "in1", "listen": "127.0.0.1", "listen_port": 8080 },
            { "type": "http", "tag": "in2", "listen": "::", "listen_port": 8081 }
        ]
        """;

        // Act & Assert for Lists
        var outboundsList = JsonSerializer.Deserialize(outboundsJson, SingBoxJsonContext.Default.ListOutboundConfig);
        Assert.IsNotNull(outboundsList);
        Assert.AreEqual(2, outboundsList.Count);
        Assert.IsInstanceOfType(outboundsList[0], typeof(DirectOutbound));
        Assert.IsInstanceOfType(outboundsList[1], typeof(SocksOutbound));
        Assert.AreEqual("out1", outboundsList[0].Tag);
        Assert.AreEqual("out2", outboundsList[1].Tag);

        var inboundsList = JsonSerializer.Deserialize(inboundsJson, SingBoxJsonContext.Default.ListInboundConfig);
        Assert.IsNotNull(inboundsList);
        Assert.AreEqual(2, inboundsList.Count);
        Assert.IsInstanceOfType(inboundsList[0], typeof(DirectInbound));
        Assert.IsInstanceOfType(inboundsList[1], typeof(HttpInbound));
        Assert.AreEqual("in1", inboundsList[0].Tag);
        Assert.AreEqual("in2", inboundsList[1].Tag);
    }

    [TestMethod]
    public void SingBoxConfig_ShouldDeserializeListOfAllConfigBases()
    {
        var routeRulesJson = """
        [
            { "network": ["tcp"], "domain": ["example.com"], "action": { "action": "route", "outbound": "direct-out" } },
            { "type": "logical", "mode": "and", "rules": [] }
        ]
        """;

        var dnsRulesJson = """
        [
            { "domain": ["example.com"], "action": { "server": "local-dns" } },
            { "type": "logical", "mode": "and", "rules": [] }
        ]
        """;

        var transportsJson = """
        [
            { "type": "grpc", "service_name": "test" },
            { "type": "ws", "path": "/ws" }
        ]
        """;

        var endpointsJson = """
        [
            { "type": "wireguard", "tag": "wg1", "system": false },
            { "type": "tailscale", "tag": "ts1", "state_directory": "state" }
        ]
        """;

        var netnsJson = """
        [
            { "type": "default", "tag": "n1", "path": "sing" },
            { "type": "unshare", "tag": "n2", "pid_file": "pid" }
        ]
        """;

        var certProvidersJson = """
        [
            { "type": "acme", "tag": "acme1", "domain": ["example.com"] },
            { "type": "tailscale", "tag": "ts1", "endpoint": "ts-ep" },
            { "type": "cloudflare-origin-ca", "tag": "cf1", "domain": ["example.com"] }
        ]
        """;

        var httpClientsJson = """
        [
            { "tag": "hc1", "engine": "go" }
        ]
        """;

        // Dns Rules
        var dnsRulesList = JsonSerializer.Deserialize(dnsRulesJson, SingBoxJsonContext.Default.ListDnsRuleBase);
        Assert.IsNotNull(dnsRulesList);
        Assert.AreEqual(2, dnsRulesList.Count);
        Assert.IsInstanceOfType(dnsRulesList[0], typeof(DnsRule));
        Assert.IsInstanceOfType(dnsRulesList[1], typeof(DnsLogicalRule));

        // Route Rules
        var routeRulesList = JsonSerializer.Deserialize(routeRulesJson, SingBoxJsonContext.Default.ListRouteRuleBase);
        Assert.IsNotNull(routeRulesList);
        Assert.AreEqual(2, routeRulesList.Count);
        Assert.IsInstanceOfType(routeRulesList[0], typeof(RouteRule));
        Assert.IsInstanceOfType(routeRulesList[1], typeof(RouteLogicalRule));

        // Transports
        var transportsList = JsonSerializer.Deserialize(transportsJson, SingBoxJsonContext.Default.ListTransportConfig);
        Assert.IsNotNull(transportsList);
        Assert.AreEqual(2, transportsList.Count);
        Assert.IsInstanceOfType(transportsList[0], typeof(GrpcTransport));
        Assert.IsInstanceOfType(transportsList[1], typeof(WebSocketTransport));

        // Endpoints
        var endpointsList = JsonSerializer.Deserialize(endpointsJson, SingBoxJsonContext.Default.ListEndpointConfig);
        Assert.IsNotNull(endpointsList);
        Assert.AreEqual(2, endpointsList.Count);
        Assert.IsInstanceOfType(endpointsList[0], typeof(WireGuardEndpoint));
        Assert.IsInstanceOfType(endpointsList[1], typeof(TailscaleEndpoint));

        // Network Namespaces
        var netnsList = JsonSerializer.Deserialize(netnsJson, SingBoxJsonContext.Default.ListNetworkNamespaceConfig);
        Assert.IsNotNull(netnsList);
        Assert.AreEqual(2, netnsList.Count);
        Assert.IsInstanceOfType(netnsList[0], typeof(DefaultNetworkNamespace));
        Assert.IsInstanceOfType(netnsList[1], typeof(UnshareNetworkNamespace));

        // Certificate Providers
        var certProvidersList = JsonSerializer.Deserialize(certProvidersJson, SingBoxJsonContext.Default.ListCertificateProviderConfig);
        Assert.IsNotNull(certProvidersList);
        Assert.AreEqual(3, certProvidersList.Count);
        Assert.IsInstanceOfType(certProvidersList[0], typeof(AcmeCertificateProvider));
        Assert.IsInstanceOfType(certProvidersList[1], typeof(TailscaleCertificateProvider));
        Assert.IsInstanceOfType(certProvidersList[2], typeof(CloudflareOriginCaCertificateProvider));

        // HTTP Clients
        var httpClientsList = JsonSerializer.Deserialize(httpClientsJson, SingBoxJsonContext.Default.ListHttpClientConfig);
        Assert.IsNotNull(httpClientsList);
        Assert.AreEqual(1, httpClientsList.Count);
        Assert.IsInstanceOfType(httpClientsList[0], typeof(HttpClientConfig));
    }
}