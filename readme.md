
<div align="center">

# SingBoxLib
Configure and run sing-box with ease.  
Based on `sing-box`'s [official documentation](http://sing-box.sagernet.org/configuration/).

![Nuget](https://img.shields.io/nuget/v/SingBoxLib)
![Nuget](https://img.shields.io/nuget/dt/SingBoxLib)
![GitHub](https://img.shields.io/github/license/Mahdi0024/singboxlib)

</div>


## Configuration examples
for more configuration examples, including Route Rules or Dns configuration, please refer to `sing-box`'s [official documentation](http://sing-box.sagernet.org/configuration/).
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
- Please note that tun inbound requires your app to have administrator privileges.
- Always set `Route.AutoDetectInterface` to true when using tun inbound.

```cs
var config = new SingBoxConfig
{

    ... Outbounds, etc....

    Inbounds = new()
    {
        new TunInbound
        {
            InterfaceName = "myTunInterface",
            INet4Address = "172.19.0.1/30",
            Stack = TunStacks.System,
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

### Running

- In order to use this library for running `sing-box` you first need to obtain it's executable from its [original repository](https://github.com/SagerNet/sing-box/releases).  
- You need to have the path to this executable and pass it to `SingBoxWrapper`'s constructor.
```cs
var wrapper = new SingBoxWrapper("sing-box.exe");
```
if you need `sing-box`'s logs, you need to subscribe to the `Onlog` event:
```cs
wrapper.OnLog += (sender, log) =>
{
    Console.WriteLine(log);
};
```
you can pass a `CancellationToken` to the `SingBoxWrapper.StartAsync` method, if you cancel it, the `sing-box` proccess will end. this parameter is optional.
```cs
// config is a SingBoxConfig instance.
var cts = new CancelationTokenSource();
await wrapper.StartAsync(config,cts.Token);
```


### Parse profiles
At this moment the following formats are supported (the `sing-box` itself can support more protocols):
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

## Clash Api
- ClashApi can be used for accessing Traffic info, Logs, `sing-box`'s internal url tester, selector outbound and more.  
- in order to be able to use this api, you first need to populate the `Experimental.ClashApi` property in your `SingBoxConfig`.
```cs
var config = new SingBoxConfig
{
    ... other config parameters....

    Experimental = new()
    {
        ClashApi = new()
        {
            ExternalController = "127.0.0.1:9090", 
        }
    }
};
```
After running the `sing-box`'s proccess with the above changes to your config, you shoud create an instance of `ClashApiWrapper`:
```cs
using SingBoxLib.Runtime.Api.Clash;
....

var clashApi = new ClashApiWrapper("http://127.0.0.1:9090");
```
## Getting logs using `ClashApi`:
- the `GetLogs` methods return an `IAsyncEnumerable<LogInfo>` 
- the `LogInfo` class contains two properties: `Level` which indicates log level and `Payload` which is a line of logs.
- you can pass a `CancelationToken` for when you want to stop getting more logs. this parameter is optional.
```cs
await foreach(var logInfo in clashApi.GetLogs(cts.Token))
{
    Console.WriteLine($"{logInfo.Level}>> {logInfo.Payload}");
}
```
## Getting Traffic info using `ClashApi`:
- the `GetTraffic` methods return an `IAsyncEnumerable<TrafficInfo>` 
- the `LogInfo` class contains two properties: `Up` and `Down`, which indicate the traffic used the the past second in `Bytes`.
- you can pass a `CancelationToken` for when you want to stop getting more traffic info. this parameter is optional.
```cs
await foreach(var trafficInfo in clashApi.GetTraffic(cts.Token))
{
    Console.WriteLine($"Up: {trafficInfo.Up}, Down: {trafficInfo.Down}");
}
```
## UrlTest a proxy using `ClashApi`:
- `name` parameter is the same as `Tag` in Outbound configuration.
```cs
var delayInfo = clashApi.GetProxyDelay(name: "out-1", timeout: 1000, url: "http://cp.cloudflare.com");
Console.WriteLine(delayInfo.Delay);
```


