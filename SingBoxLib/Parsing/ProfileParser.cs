using NeoSmart.Utils;
using SingBoxLib.Exceptions;
using SingBoxLib.Parsing.ProfileModels;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace SingBoxLib.Parsing;

public static class ProfileParser
{
    //Implemented:
    private const string VLessProtocol = "vless://";

    private const string TrojanProtocol = "trojan://";
    private const string VMessProtocol = "vmess://";
    private const string ShadowsocksProtocol = "ss://";
    private const string Socks4Protocol = "socks4://";
    private const string Socks5Protocol = "socks5://";
    private const string HttpProtocol = "http://";
    private const string HttpsProtocol = "https://";

    public static ProfileItem ParseProfileUrl(string url)
    {
        if (url.StartsWith(VLessProtocol))
        {
            var profile = ParseProfileUrl(new Uri(url));
            profile.Type = ProfileType.VLess;
            return profile;
        }
        if (url.StartsWith(TrojanProtocol))
        {
            var profile = ParseProfileUrl(new Uri(url));
            profile.Type = ProfileType.Trojan;
            return profile;
        }
        if (url.StartsWith(VMessProtocol))
        {
            return ParseVMess(url);
        }
        if (url.StartsWith(ShadowsocksProtocol))
        {
            return ParseShadowsocks(url);
        }
        if (url.StartsWith(Socks4Protocol))
        {
            return ParseSocks(url, 4);
        }
        if (url.StartsWith(Socks5Protocol))
        {
            return ParseSocks(url, 5);
        }
        if (url.StartsWith(HttpProtocol))
        {
            return ParseHttp(url, false);
        }
        if (url.StartsWith(HttpsProtocol))
        {
            return ParseHttp(url, true);
        }
        throw new UnsupportedProfileException(url);
    }

    private static ProfileItem ParseHttp(string profileUrl, bool tls)
    {
        var url = new Uri(profileUrl);
        var address = url.IdnHost;
        var port = url.Port;
        var name = url.GetComponents(UriComponents.Fragment, UriFormat.Unescaped);

        var userPass = url.UserInfo.Split(':');
        var username = userPass[0];
        var password = userPass[1];
        var security = tls ? "tls" : null;

        return new ProfileItem
        {
            Address = address,
            Port = port,
            Id = username,
            Password = password,
            Security = security,
        };
    }

    private static ProfileItem ParseSocks(string profileUrl, int version)
    {
        var url = new Uri(profileUrl);
        var address = url.IdnHost;
        var port = url.Port;
        var name = url.GetComponents(UriComponents.Fragment, UriFormat.Unescaped);

        var userPass = url.UserInfo.Split(':');
        var username = userPass[0];
        var password = userPass[1];

        return new ProfileItem
        {
            Address = address,
            Port = port,
            Id = username,
            Password = password,
            Version = version
        };
    }

    private static ProfileItem ParseShadowsocks(string profileUrl)
    {
        profileUrl = HttpUtility.UrlDecode(profileUrl);

        var profile = new ProfileItem
        {
            Type = ProfileType.Shadowsocks
        };

        var (data, name) = GetDataName(profileUrl);
        profile.Name = name;

        if (data.Contains("?"))
        {
            (data, var plugin, var pluginArgs) = GetDataPlugin(data);
            profile.Plugin = plugin;
            profile.PluginArgs = pluginArgs;
        }

        if (data.Contains("@"))
        {
            (data, var address, var port) = GetDataAddressPort(data);
            profile.Address = address;
            profile.Port = int.Parse(port);
        }

        data = Encoding.UTF8.GetString(UrlBase64.Decode(data));

        if (data.Contains("?"))
        {
            (data, var plugin, var pluginArgs) = GetDataPlugin(data);
            profile.Plugin = plugin;
            profile.PluginArgs = pluginArgs;
        }

        if (data.Contains("@"))
        {
            (data, var address, var port) = GetDataAddressPort(data);
            profile.Address = address;
            profile.Port = int.Parse(port);
        }

        (var encryption, var password) = GetEcryptionPassword(data);

        profile.Encryption = encryption;
        profile.Password = password;

        return profile;

        (string data, string? name) GetDataName(string profileUrl)
        {
            profileUrl = profileUrl.Replace(ShadowsocksProtocol, "");
            if (!profileUrl.Contains("#"))
            {
                return (profileUrl, null);
            }
            var dataAndName = profileUrl.Split("#");
            var data = dataAndName[0];
            var name = dataAndName[1];

            return (data, name);
        }
        (string data, string plugin, string pluginArgs) GetDataPlugin(string rawData)
        {
            var dataAndPluginData = rawData.Split("?");
            var data = dataAndPluginData[0];
            var pluginData = HttpUtility.UrlDecode(dataAndPluginData[1]).Split(";");
            var plugin = pluginData[0].Split('=')[1];
            var pluginArgs = string.Join(";", pluginData.Skip(1));

            return (data, plugin, pluginArgs);
        }
        (string data, string address, string port) GetDataAddressPort(string rawData)
        {
            var dataAddressPort = rawData.Split("@");
            var data = dataAddressPort[0];
            var addressPort = dataAddressPort[1].Split(":");

            return (data, addressPort[0], addressPort[1]);
        }
        (string encryption, string password) GetEcryptionPassword(string rawData)
        {
            var encPass = rawData.Split(":");
            return (encPass[0], encPass[1]);
        }
    }

    private static ProfileItem ParseVMess(string profileUrl)
    {
        var profileBase64 = profileUrl.Substring(8);

        var profileJson = Encoding.UTF8.GetString(Convert.FromBase64String(profileBase64));
        var parsedProfile = JsonConvert.DeserializeObject<VMessProfileModel>(profileJson);
        return parsedProfile!.MapToProfileItem();
    }

    private static ProfileItem ParseProfileUrl(Uri profileUrl)
    {
        var args = HttpUtility.ParseQueryString(profileUrl.Query);

        var profile = new ProfileItem
        {
            Id = profileUrl.UserInfo,
            Address = profileUrl.IdnHost,
            Port = profileUrl.Port,
            Name = profileUrl.GetComponents(UriComponents.Fragment, UriFormat.Unescaped),
            Flow = args["flow"],
            Security = args["security"],
            Encryption = args["encryption"],
            Sni = args["sni"],
            Alpn = HttpUtility.UrlDecode(args["alpn"]),
            Fingerprint = HttpUtility.UrlDecode(args["fp"]),
            PublicKey = HttpUtility.UrlDecode(args["pbk"]),
            ShortId = HttpUtility.UrlDecode(args["sid"]),
            SpiderX = HttpUtility.UrlDecode(args["spx"]),
            HeaderType = args["headerType"],
            RequestHost = HttpUtility.UrlDecode(args["host"]),
            Network = args["type"],
            GrpcServiceName = HttpUtility.UrlDecode(args["serviceName"]),
            GrpcMode = HttpUtility.UrlDecode(args["mode"]),
            Path = HttpUtility.UrlDecode(args["path"]),
            KcpSeed = HttpUtility.UrlDecode(args["seed"]),
            QuicSecurity = args["quicSecurity"],
            QuicKey = HttpUtility.UrlDecode(args["key"])
        };

        return profile;
    }

    public static string ToProfileUrl(this ProfileItem profile)
    {
        return profile.Type switch
        {
            ProfileType.VLess or ProfileType.Trojan => ProfileToStandardUrl(profile),
            ProfileType.VMess => ProfileToVMessUrl(profile),
            ProfileType.Shadowsocks => ProfileToShadowsocksUrl(profile),
            ProfileType.Socks => ProfileToSocksUrl(profile),
            ProfileType.Http => ProfileToHttpUrl(profile),
            _ => throw new NotImplementedException($"profile type *{profile.Type}* is not implemented.")
        };
    }

    private static string ProfileToHttpUrl(ProfileItem profile)
    {
        var url = new UriBuilder();
        url.Scheme = "socks" + profile.Version;
        url.Host = profile.Address;
        url.Port = (int)profile.Port!;
        url.UserName = profile.Id;
        url.Password = profile.Password;
        url.Fragment = profile.Name;
        return url.Uri.ToString();
    }

    private static string ProfileToSocksUrl(ProfileItem profile)
    {
        var url = new UriBuilder();
        url.Scheme = profile.Security is "tls" ? "https" : "http";
        url.Host = profile.Address;
        url.Port = (int)profile.Port!;
        url.UserName = profile.Id;
        url.Password = profile.Password;
        url.Fragment = profile.Name;
        return url.Uri.ToString();
    }

    private static string ProfileToStandardUrl(ProfileItem profile)
    {
        var protocol = profile.Type switch
        {
            ProfileType.VLess => VLessProtocol,
            ProfileType.Trojan => TrojanProtocol,
            _ => throw new UnreachableException()
        };

        var builder = new UriBuilder(protocol, $"{profile.Id}@{profile.Address}", (int)profile.Port!);
        builder.Fragment = HttpUtility.UrlEncode(profile.Name);

        var args = new Dictionary<string, string?>
        {
            { "flow", profile.Flow},
            { "security", profile.Security },
            { "encryption", profile.Encryption },
            { "sni", profile.Sni},
            { "alpn", profile.Alpn },
            { "fp", profile.Fingerprint},
            { "pbk", profile.PublicKey},
            { "sid", profile.ShortId},
            { "spx", profile.SpiderX },
            { "type", profile.Network },
            { "headerType", profile.HeaderType},
            { "host", profile.RequestHost},
            { "quicSecurity", profile.QuicSecurity},
            { "key",profile.QuicKey},
            { "serviceName", profile.GrpcServiceName},
            { "path",profile.Path},
            { "seed",profile.KcpSeed}
        };

        var query = new StringBuilder();
        foreach (var (key, value) in args)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                query.Append(query.Length == 0 ? '?' : '&');
                query.Append($"{key}={HttpUtility.UrlEncode(value)}");
            }
        }

        builder.Query = query.ToString();

        return builder.ToString();
    }

    private static string ProfileToShadowsocksUrl(ProfileItem profile)
    {
        var shadowSocksData = $"{profile.Encryption}:{profile.Password}";
        var shadowSocksDataBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(shadowSocksData));

        var url = new StringBuilder();

        url.Append(ShadowsocksProtocol)
           .Append(shadowSocksDataBase64)
           .Append("@")
           .Append(profile.Address)
           .Append(":")
           .Append(profile.Port);

        if (profile.Plugin is not null)
        {
            url.Append('?')
               .Append("plugin=")
               .Append(profile.Plugin)
               .Append(';')
               .Append(profile.PluginArgs);
        }

        url.Append('#')
           .Append(profile.Name);

        return HttpUtility.UrlEncode(url.ToString());
    }

    private static string ProfileToVMessUrl(ProfileItem profile)
    {
        var vmessData = new VMessProfileModel
        {
            Address = profile.Address,
            Alpn = profile.Alpn,
            AlterId = profile.AlterId.ToString(),
            Fingerprint = profile.Fingerprint,
            Host = profile.RequestHost,
            Id = profile.Id,
            Name = profile.Name,
            Network = profile.Network,
            Path = profile.Path,
            Port = profile.Port,
            Encryption = profile.Encryption,
            Security = profile.Security,
            Sni = profile.Sni,
        };
        var vmessDataJson = JsonConvert.SerializeObject(vmessData);
        var base64Data = Convert.ToBase64String(Encoding.UTF8.GetBytes(vmessDataJson));

        return $"{VMessProtocol}{base64Data}";
    }
}