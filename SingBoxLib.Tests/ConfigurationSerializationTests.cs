#pragma warning disable MSTEST0037

using System.Text.Json;
using SingBoxLib.Configuration;
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
using SingBoxLib.Configuration.Route;
using SingBoxLib.Configuration.Route.Abstract;
using SingBoxLib.Configuration.Serialization;
using SingBoxLib.Configuration.Shared;
using SingBoxLib.Configuration.Transport;

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
                        Outbound = "direct-out",
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
                    new DnsServer
                    {
                        Tag = "local-dns",
                        Server = "https://1.1.1.1/dns-query",
                        Strategy = "prefer_ipv4",
                        Detour = "direct-out",
                        ClientSubnet = "1.1.1.1"
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
                        Server = "local-dns"
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
                    CacheId = "mycache"
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
        Assert.AreEqual(1, endpointsProp.GetArrayLength());
        Assert.AreEqual("wg-endpoint", endpointsProp[0].GetProperty("tag").GetString());

        Assert.IsTrue(root.TryGetProperty("inbounds", out var inboundsProp));
        Assert.AreEqual(16, inboundsProp.GetArrayLength());

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

        Assert.IsTrue(root.TryGetProperty("outbounds", out var outboundsProp));
        Assert.AreEqual(15, outboundsProp.GetArrayLength());

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

        Assert.IsTrue(root.TryGetProperty("route", out var routeProp));
        Assert.AreEqual("direct-out", routeProp.GetProperty("final").GetString());
        Assert.AreEqual(2, routeProp.GetProperty("rules").GetArrayLength());
        Assert.AreEqual(3, routeProp.GetProperty("rule_set").GetArrayLength());

        Assert.IsTrue(root.TryGetProperty("dns", out var dnsProp));
        Assert.AreEqual("local-dns", dnsProp.GetProperty("final").GetString());
        Assert.AreEqual(1, dnsProp.GetProperty("servers").GetArrayLength());
        Assert.AreEqual(2, dnsProp.GetProperty("rules").GetArrayLength());

        Assert.IsTrue(root.TryGetProperty("experimental", out var expProp));
        Assert.IsTrue(expProp.TryGetProperty("clash_api", out var clashProp));
        Assert.AreEqual("127.0.0.1:9090", clashProp.GetProperty("external_controller").GetString());
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
        Assert.AreEqual(1, deserialized.Endpoints.Count);
        var endpoint = deserialized.Endpoints[0] as WireGuardEndpoint;
        Assert.IsNotNull(endpoint, "Deserialized endpoint should be a WireGuardEndpoint.");
        Assert.AreEqual("wg-endpoint", endpoint.Tag);
        Assert.IsNotNull(endpoint.Peers);
        Assert.AreEqual(1, endpoint.Peers.Count);
        Assert.AreEqual("198.51.100.1", endpoint.Peers[0].Address);

        Assert.IsNotNull(deserialized.Inbounds, "Deserialized Inbounds should not be null.");
        Assert.AreEqual(16, deserialized.Inbounds.Count);
        
        Assert.IsNotNull(deserialized.Outbounds, "Deserialized Outbounds should not be null.");
        Assert.AreEqual(15, deserialized.Outbounds.Count);

        Assert.IsNotNull(deserialized.Route, "Deserialized Route should not be null.");
        Assert.AreEqual("direct-out", deserialized.Route.Final);
        Assert.IsNotNull(deserialized.Route.Rules, "Deserialized Route.Rules should not be null.");
        Assert.AreEqual(2, deserialized.Route.Rules.Count);
        Assert.IsNotNull(deserialized.Route.RuleSet, "Deserialized Route.RuleSet should not be null.");
        Assert.AreEqual(3, deserialized.Route.RuleSet.Count);

        Assert.IsNotNull(deserialized.Dns, "Deserialized Dns should not be null.");
        Assert.AreEqual("local-dns", deserialized.Dns.Final);
        Assert.IsNotNull(deserialized.Dns.Servers, "Deserialized Dns.Servers should not be null.");
        Assert.AreEqual(1, deserialized.Dns.Servers.Count);
        Assert.IsNotNull(deserialized.Dns.Rules, "Deserialized Dns.Rules should not be null.");
        Assert.AreEqual(2, deserialized.Dns.Rules.Count);
        Assert.IsNotNull(deserialized.Dns.Fakeip, "Deserialized Dns.Fakeip should not be null.");
        Assert.IsTrue(deserialized.Dns.Fakeip.Enabled == true);

        Assert.IsNotNull(deserialized.Experimental, "Deserialized Experimental should not be null.");
        Assert.IsNotNull(deserialized.Experimental.ClashApi, "ClashApi should not be null.");
        Assert.AreEqual("127.0.0.1:9090", deserialized.Experimental.ClashApi.ExternalController);

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
    public void SingBoxConfig_ShouldDeserializeListAndArrayOfOutboundsAndInbounds()
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

        // Act & Assert for Arrays
        var outboundsArray = JsonSerializer.Deserialize(outboundsJson, SingBoxJsonContext.Default.OutboundConfigArray);
        Assert.IsNotNull(outboundsArray);
        Assert.AreEqual(2, outboundsArray.Length);
        Assert.IsInstanceOfType(outboundsArray[0], typeof(DirectOutbound));
        Assert.IsInstanceOfType(outboundsArray[1], typeof(SocksOutbound));

        var inboundsArray = JsonSerializer.Deserialize(inboundsJson, SingBoxJsonContext.Default.InboundConfigArray);
        Assert.IsNotNull(inboundsArray);
        Assert.AreEqual(2, inboundsArray.Length);
        Assert.IsInstanceOfType(inboundsArray[0], typeof(DirectInbound));
        Assert.IsInstanceOfType(inboundsArray[1], typeof(HttpInbound));
    }

    [TestMethod]
    public void SingBoxConfig_ShouldDeserializeListAndArrayOfAllConfigBases()
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
            { "tag": "wg1", "system": false }
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
        Assert.AreEqual(1, endpointsList.Count);
        Assert.IsInstanceOfType(endpointsList[0], typeof(WireGuardEndpoint));
    }
}
