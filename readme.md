# SingBoxLib
<div align="center">

![Nuget](https://img.shields.io/nuget/v/SingBoxLib)
![Nuget](https://img.shields.io/nuget/dt/SingBoxLib)

</div>

Configure and run sing-box with ease.
Based on sing-box's [official documentation](http://sing-box.sagernet.org/configuration/).
## Usage examples
### Mixed inbound with Trojan outbound and grpc transport with tls:
```cs
var config = new SingBoxConfig
{
    Inbounds = new()
    {
        new MixedInbound
        {
            Listen = "127.0.0.1",
            ListenPort = 2080
        }
    },
    Outbounds = new()
    {
        new TrojanOutbound
        {
            Server = "yourserver.server",
            Port = 443,
            Password = "my top secret password!",
            Transport = new GrpcTransport
            {
                ServiceName = "grpcSeviceNameGoesHere",
            },
            Tls = new()
            {
                Enabled = true,
                ServerName = "sniGoesHere",
                Alpn = new() { "listOfAplnsGoHere" }
            }
        }
    }
};
```
### Tun inbound:
```cs
var config = new SingBoxConfig
{
    Inbounds = new()
    {
        new TunInbound
        {
            InterfaceName = "myTunInterface",
            INet4Address = "172.19.0.1/30",
            Stack = TunStacks.gVisor,
            Mtu = 1500,
            AutoRoute = true,
        }
    },
    Route = new()
    {
        AutoDetectInterface = true
    }
};
```

### Parse profiles
At this moment the following formats are supported:
`VMess` `VLess` `Shadowsocks` `Trojan` `Socks` `Http`
```cs
var myProfileUrl = "trojan://myLovelyPassword@myserver.server:443?security=tls&sni=mySni&type=grpc&serviceName=myGrpcPath#MyTrojanServer";
var myProfile = ProfileParser.ParseProfileUrl(myProfileUrl);

// convert to outbound and use directly in sing-box config:
var myOutbound = myProfile.ToOutboundConfig();
```
Additionally you can convert parsed profiles back to string url:
```cs
var myProfileUrl = myProfile.ToProfileUrl();
```
### Url testing
You can use `UrlTester` and `ParallelUrlTester` classes to easily test if the proxies are healthy and valid
```cs
var myProfileUrl = "trojan://myLovelyPassword@myserver.server:443?security=tls&sni=mySni&type=grpc&serviceName=myGrpcPath#MyTrojanServer";
var myProfile = ProfileParser.ParseProfileUrl(myProfileUrl);

var urlTester = new UrlTester(
    new SingBoxWrapper("sing-box-path"),
    // local port
    2080,
    // timeout in miliseconds
    3000,
    // retry count (will still do the retries even if proxy works, returns fastest result)
    5,
    // url to test using the proxy, defauts to http://cp.cloudflare.com, optional
    null
    );

var testResult = await urlTester.TestAsync(myProfile);
Console.WriteLine($"Success: {testResult.Success}, Delay: {testResult.Delay}");
```
Parallel:
```cs
var parallelTester = new ParallelUrlTester(
        new SingBoxWrapper("sing-box-path"),
    // A list of open local ports, must be equal or bigger than total test thread count
    // make sure they are not occupied by other applications running on your system
    new int[] { 2080, 2081, 2082, 2083, 2084, 2085 },
    // max number of concurrent testing
    6,
    // timeout in miliseconds
    3000,
    // retry count (will still do the retries even if proxy works, returns fastest result)
    5,
    // url to test using the proxy, defauts to http://cp.cloudflare.com, optional
    null);

List<ProfileItem> profilesToTest = GetMyProfilesFormSomewhere();
var results = new ConcurrentBag<UrlTestResult>();

await parallelTester.ParallelTestAsync(profilesToTest, new Progress<UrlTestResult>((result =>
{
    results.Add(result);
})), default(CancellationToken));
```
