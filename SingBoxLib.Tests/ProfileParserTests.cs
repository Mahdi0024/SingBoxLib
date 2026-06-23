using System.Text;
using SingBoxLib.Parsing;

namespace SingBoxLib.Tests;

[TestClass]
public sealed class ProfileParserTests
{
    [TestMethod]
    public void VLess_ParseAndSerialize_ShouldRoundTrip()
    {
        // Arrange
        var originalUrl = "vless://myuuid@myhost.com:443?flow=xtls-rprx-vision&security=tls&sni=myhost.com#MyVLessName";

        // Act
        var profile = ProfileParser.ParseProfileUrl(originalUrl);

        // Assert Parsing
        Assert.AreEqual(ProfileType.VLess, profile.Type);
        Assert.AreEqual("myuuid", profile.Id);
        Assert.AreEqual("myhost.com", profile.Address);
        Assert.AreEqual((ushort)443, profile.Port);
        Assert.AreEqual("xtls-rprx-vision", profile.Flow);
        Assert.AreEqual("tls", profile.Security);
        Assert.AreEqual("myhost.com", profile.Sni);
        Assert.AreEqual("MyVLessName", profile.Name);

        // Act Serialization
        var reserializedUrl = profile.ToProfileUrl();

        // Assert Roundtrip
        var roundtrippedProfile = ProfileParser.ParseProfileUrl(reserializedUrl);
        Assert.AreEqual(profile.Type, roundtrippedProfile.Type);
        Assert.AreEqual(profile.Id, roundtrippedProfile.Id);
        Assert.AreEqual(profile.Address, roundtrippedProfile.Address);
        Assert.AreEqual(profile.Port, roundtrippedProfile.Port);
        Assert.AreEqual(profile.Flow, roundtrippedProfile.Flow);
        Assert.AreEqual(profile.Security, roundtrippedProfile.Security);
        Assert.AreEqual(profile.Sni, roundtrippedProfile.Sni);
        Assert.AreEqual(profile.Name, roundtrippedProfile.Name);
    }

    [TestMethod]
    public void Trojan_ParseAndSerialize_ShouldRoundTrip()
    {
        // Arrange
        var originalUrl = "trojan://mypassword@myhost.com:443?security=tls&sni=myhost.com#MyTrojanName";

        // Act
        var profile = ProfileParser.ParseProfileUrl(originalUrl);

        // Assert Parsing
        Assert.AreEqual(ProfileType.Trojan, profile.Type);
        Assert.AreEqual("mypassword", profile.Id);
        Assert.AreEqual("myhost.com", profile.Address);
        Assert.AreEqual((ushort)443, profile.Port);
        Assert.AreEqual("tls", profile.Security);
        Assert.AreEqual("myhost.com", profile.Sni);
        Assert.AreEqual("MyTrojanName", profile.Name);

        // Act Serialization
        var reserializedUrl = profile.ToProfileUrl();

        // Assert Roundtrip
        var roundtrippedProfile = ProfileParser.ParseProfileUrl(reserializedUrl);
        Assert.AreEqual(profile.Type, roundtrippedProfile.Type);
        Assert.AreEqual(profile.Id, roundtrippedProfile.Id);
        Assert.AreEqual(profile.Address, roundtrippedProfile.Address);
        Assert.AreEqual(profile.Port, roundtrippedProfile.Port);
        Assert.AreEqual(profile.Security, roundtrippedProfile.Security);
        Assert.AreEqual(profile.Sni, roundtrippedProfile.Sni);
        Assert.AreEqual(profile.Name, roundtrippedProfile.Name);
    }

    [TestMethod]
    public void Tuic_ParseAndSerialize_ShouldRoundTrip()
    {
        // Arrange
        var originalUrl = "tuic://myuuid:mypassword@myhost.com:443?congestion_control=bbr#MyTuicName";

        // Act
        var profile = ProfileParser.ParseProfileUrl(originalUrl);

        // Assert Parsing
        Assert.AreEqual(ProfileType.Tuic, profile.Type);
        Assert.AreEqual("myuuid", profile.Id);
        Assert.AreEqual("mypassword", profile.Password);
        Assert.AreEqual("myhost.com", profile.Address);
        Assert.AreEqual((ushort)443, profile.Port);
        Assert.AreEqual("bbr", profile.CongestionControl);
        Assert.AreEqual("MyTuicName", profile.Name);

        // Act Serialization
        var reserializedUrl = profile.ToProfileUrl();

        // Assert Roundtrip
        var roundtrippedProfile = ProfileParser.ParseProfileUrl(reserializedUrl);
        Assert.AreEqual(profile.Type, roundtrippedProfile.Type);
        Assert.AreEqual(profile.Id, roundtrippedProfile.Id);
        Assert.AreEqual(profile.Password, roundtrippedProfile.Password);
        Assert.AreEqual(profile.Address, roundtrippedProfile.Address);
        Assert.AreEqual(profile.Port, roundtrippedProfile.Port);
        Assert.AreEqual(profile.CongestionControl, roundtrippedProfile.CongestionControl);
        Assert.AreEqual(profile.Name, roundtrippedProfile.Name);
    }

    [TestMethod]
    public void Hysteria2_ParseAndSerialize_ShouldRoundTrip()
    {
        // Arrange
        var originalUrl = "hy2://mypassword@myhost.com:443?congestion_control=bbr#MyHy2Name";

        // Act
        var profile = ProfileParser.ParseProfileUrl(originalUrl);

        // Assert Parsing
        Assert.AreEqual(ProfileType.Hysteria2, profile.Type);
        Assert.AreEqual("mypassword", profile.Password);
        Assert.AreEqual("myhost.com", profile.Address);
        Assert.AreEqual((ushort)443, profile.Port);
        Assert.AreEqual("bbr", profile.CongestionControl);
        Assert.AreEqual("MyHy2Name", profile.Name);

        // Act Serialization
        var reserializedUrl = profile.ToProfileUrl();

        // Assert Roundtrip
        var roundtrippedProfile = ProfileParser.ParseProfileUrl(reserializedUrl);
        Assert.AreEqual(profile.Type, roundtrippedProfile.Type);
        Assert.AreEqual(profile.Password, roundtrippedProfile.Password);
        Assert.AreEqual(profile.Address, roundtrippedProfile.Address);
        Assert.AreEqual(profile.Port, roundtrippedProfile.Port);
        Assert.AreEqual(profile.CongestionControl, roundtrippedProfile.CongestionControl);
        Assert.AreEqual(profile.Name, roundtrippedProfile.Name);
    }

    [TestMethod]
    public void VMess_ParseAndSerialize_ShouldRoundTrip()
    {
        // Arrange
        var json = """{"add":"myhost.com","port":443,"id":"myuuid","aid":"0","scy":"auto","net":"ws","type":"none","host":"myhost.com","path":"/path","tls":"tls","ps":"MyVMessName"}""";
        var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
        var originalUrl = $"vmess://{base64}";

        // Act
        var profile = ProfileParser.ParseProfileUrl(originalUrl);

        // Assert Parsing
        Assert.AreEqual(ProfileType.VMess, profile.Type);
        Assert.AreEqual("myhost.com", profile.Address);
        Assert.AreEqual((ushort)443, profile.Port);
        Assert.AreEqual("myuuid", profile.Id);
        Assert.AreEqual(0, profile.AlterId);
        Assert.AreEqual("auto", profile.Encryption);
        Assert.AreEqual("ws", profile.Network);
        Assert.AreEqual("myhost.com", profile.RequestHost);
        Assert.AreEqual("/path", profile.Path);
        Assert.AreEqual("tls", profile.Security);
        Assert.AreEqual("MyVMessName", profile.Name);

        // Act Serialization
        var reserializedUrl = profile.ToProfileUrl();

        // Assert Roundtrip
        var roundtrippedProfile = ProfileParser.ParseProfileUrl(reserializedUrl);
        Assert.AreEqual(profile.Type, roundtrippedProfile.Type);
        Assert.AreEqual(profile.Address, roundtrippedProfile.Address);
        Assert.AreEqual(profile.Port, roundtrippedProfile.Port);
        Assert.AreEqual(profile.Id, roundtrippedProfile.Id);
        Assert.AreEqual(profile.AlterId, roundtrippedProfile.AlterId);
        Assert.AreEqual(profile.Encryption, roundtrippedProfile.Encryption);
        Assert.AreEqual(profile.Network, roundtrippedProfile.Network);
        Assert.AreEqual(profile.RequestHost, roundtrippedProfile.RequestHost);
        Assert.AreEqual(profile.Path, roundtrippedProfile.Path);
        Assert.AreEqual(profile.Security, roundtrippedProfile.Security);
        Assert.AreEqual(profile.Name, roundtrippedProfile.Name);
    }

    [TestMethod]
    public void Shadowsocks_ParseAndSerialize_ShouldRoundTrip()
    {
        // Arrange
        // aes-128-gcm:sspassword base64 -> YWVzLTEyOC1nY206c3NwYXNzd29yZA==
        var originalUrl = "ss://YWVzLTEyOC1nY206c3NwYXNzd29yZA==@127.0.0.1:8388#MySSName";

        // Act
        var profile = ProfileParser.ParseProfileUrl(originalUrl);

        // Assert Parsing
        Assert.AreEqual(ProfileType.Shadowsocks, profile.Type);
        Assert.AreEqual("aes-128-gcm", profile.Encryption);
        Assert.AreEqual("sspassword", profile.Password);
        Assert.AreEqual("127.0.0.1", profile.Address);
        Assert.AreEqual((ushort)8388, profile.Port);
        Assert.AreEqual("MySSName", profile.Name);

        // Act Serialization
        var reserializedUrl = profile.ToProfileUrl();

        // Assert Roundtrip
        var roundtrippedProfile = ProfileParser.ParseProfileUrl(reserializedUrl);
        Assert.AreEqual(profile.Type, roundtrippedProfile.Type);
        Assert.AreEqual(profile.Encryption, roundtrippedProfile.Encryption);
        Assert.AreEqual(profile.Password, roundtrippedProfile.Password);
        Assert.AreEqual(profile.Address, roundtrippedProfile.Address);
        Assert.AreEqual(profile.Port, roundtrippedProfile.Port);
        Assert.AreEqual(profile.Name, roundtrippedProfile.Name);
    }

    [TestMethod]
    public void Socks_ParseAndSerialize_ShouldRoundTrip()
    {
        // Arrange SOCKS5
        var originalUrl = "socks5://user:pass@127.0.0.1:1080#MySocksName";

        // Act
        var profile = ProfileParser.ParseProfileUrl(originalUrl);

        // Assert Parsing
        Assert.IsNull(profile.Type, "Type is expected to be null due to library omission during parse.");
        Assert.AreEqual(5, profile.Version);
        Assert.AreEqual("user", profile.Id);
        Assert.AreEqual("pass", profile.Password);
        Assert.AreEqual("127.0.0.1", profile.Address);
        Assert.AreEqual((ushort)1080, profile.Port);
        Assert.AreEqual("MySocksName", profile.Name);

        // Manually set Type to allow serialization since ParseSocks omits it
        profile.Type = ProfileType.Socks;

        // Act Serialization
        var reserializedUrl = profile.ToProfileUrl();

        // Assert Roundtrip
        var roundtrippedProfile = ProfileParser.ParseProfileUrl(reserializedUrl);
        Assert.IsNull(roundtrippedProfile.Type);
        Assert.AreEqual(profile.Version, roundtrippedProfile.Version);
        Assert.AreEqual(profile.Id, roundtrippedProfile.Id);
        Assert.AreEqual(profile.Password, roundtrippedProfile.Password);
        Assert.AreEqual(profile.Address, roundtrippedProfile.Address);
        Assert.AreEqual(profile.Port, roundtrippedProfile.Port);
        Assert.AreEqual(profile.Name, roundtrippedProfile.Name);
    }

    [TestMethod]
    public void Http_ParseAndSerialize_ShouldRoundTrip()
    {
        // Arrange HTTP
        var originalUrl = "http://user:pass@127.0.0.1:8080#MyHttpName";

        // Act
        var profile = ProfileParser.ParseProfileUrl(originalUrl);

        // Assert Parsing
        Assert.IsNull(profile.Type, "Type is expected to be null due to library omission during parse.");
        Assert.IsNull(profile.Security);
        Assert.AreEqual("user", profile.Id);
        Assert.AreEqual("pass", profile.Password);
        Assert.AreEqual("127.0.0.1", profile.Address);
        Assert.AreEqual((ushort)8080, profile.Port);
        Assert.AreEqual("MyHttpName", profile.Name);

        // Manually set Type to allow serialization since ParseHttp omits it
        profile.Type = ProfileType.Http;

        // Act Serialization
        var reserializedUrl = profile.ToProfileUrl();

        // Assert Roundtrip
        var roundtrippedProfile = ProfileParser.ParseProfileUrl(reserializedUrl);
        Assert.IsNull(roundtrippedProfile.Type);
        Assert.AreEqual(profile.Security, roundtrippedProfile.Security);
        Assert.AreEqual(profile.Id, roundtrippedProfile.Id);
        Assert.AreEqual(profile.Password, roundtrippedProfile.Password);
        Assert.AreEqual(profile.Address, roundtrippedProfile.Address);
        Assert.AreEqual(profile.Port, roundtrippedProfile.Port);
        Assert.AreEqual(profile.Name, roundtrippedProfile.Name);
    }

    [TestMethod]
    public void Https_ParseAndSerialize_ShouldRoundTrip()
    {
        // Arrange HTTPS
        var originalUrl = "https://user:pass@127.0.0.1:8080#MyHttpsName";

        // Act
        var profile = ProfileParser.ParseProfileUrl(originalUrl);

        // Assert Parsing
        Assert.IsNull(profile.Type, "Type is expected to be null due to library omission during parse.");
        Assert.AreEqual("tls", profile.Security);
        Assert.AreEqual("user", profile.Id);
        Assert.AreEqual("pass", profile.Password);
        Assert.AreEqual("127.0.0.1", profile.Address);
        Assert.AreEqual((ushort)8080, profile.Port);
        Assert.AreEqual("MyHttpsName", profile.Name);

        // Manually set Type to allow serialization since ParseHttp omits it
        profile.Type = ProfileType.Http;

        // Act Serialization
        var reserializedUrl = profile.ToProfileUrl();

        // Assert Roundtrip
        var roundtrippedProfile = ProfileParser.ParseProfileUrl(reserializedUrl);
        Assert.IsNull(roundtrippedProfile.Type);
        Assert.AreEqual(profile.Security, roundtrippedProfile.Security);
        Assert.AreEqual(profile.Id, roundtrippedProfile.Id);
        Assert.AreEqual(profile.Password, roundtrippedProfile.Password);
        Assert.AreEqual(profile.Address, roundtrippedProfile.Address);
        Assert.AreEqual(profile.Port, roundtrippedProfile.Port);
        Assert.AreEqual(profile.Name, roundtrippedProfile.Name);
    }
}
