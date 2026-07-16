
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
if you need `sing-box`'s logs, you need to subscribe to the `OnLog` event:
```cs
wrapper.OnLog += (sender, logArgs) =>
{
    Console.WriteLine($"[{logArgs.Stream}] {logArgs.Line}");
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
`VMess` `VLess` `Shadowsocks` `Trojan` `Socks` `Http` `Hysteria2` `Tuic`
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
    // local port for Clash API controller
    2080,
    // max number of concurrent testing tasks
    6,
    // timeout in milliseconds
    3000,
    // test chunk count (size of each batch tested concurrently)
    10,
    // url to test using the proxy, defaults to http://cp.cloudflare.com, optional
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
- the `GetLogs` method returns an `IAsyncEnumerable<LogInfo>` 
- the `LogInfo` class contains two properties: `Level` which indicates log level and `Payload` which is a line of logs.
- you can pass a `CancelationToken` for when you want to stop getting more logs. this parameter is optional.
```cs
await foreach(var logInfo in clashApi.GetLogs(cts.Token))
{
    Console.WriteLine($"{logInfo.Level}>> {logInfo.Payload}");
}
```
## Getting Traffic info using `ClashApi`:
- the `GetTraffic` method returns an `IAsyncEnumerable<TrafficInfo>` 
- the `TrafficInfo` class contains two properties: `Up` and `Down`, which indicate the traffic used the the past second in `Bytes`.
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
var delayInfo = await clashApi.GetProxyDelay(name: "out-1", timeout: 1000, url: "http://cp.cloudflare.com");
Console.WriteLine(delayInfo.Delay);
```


## Public API Reference

### 1. `SingBoxConfig` (Configuration Root)
Represents the root configuration of a sing-box instance.
* **Methods:**
  * `string ToJson(bool writeIndented = false)`: Serializes the configuration instance into a JSON string using the source-generated context.
  * `static SingBoxConfig? FromJson(string json)`: Deserializes a JSON string into a `SingBoxConfig` instance.

### 2. `SingBoxJsonContext` (Source Generation Context)
A `public partial class` inheriting from `JsonSerializerContext` that provides reflection-free, pre-compiled JSON serialization metadata for Native AOT.
* **Static Accessor:**
  * `public static SingBoxJsonContext Default { get; }`

### 3. `SingBoxWrapper` (Process Runner)
Manages the lifecycle and logging of a `sing-box` process.
* **Constructor:**
  * `public SingBoxWrapper(string executablePath)`
* **Events:**
  * `public event Action<SingBoxWrapper, LogEventArgs>? OnLog`: Triggers whenever standard output or standard error logs are emitted.
* **Methods:**
  * `public async Task<CommandResult> StartAsync(SingBoxConfig config, CancellationToken cancellationToken)`: Starts the `sing-box` process and pipes the configuration to it.

### 4. `LogEventArgs` (Log Record)
A `readonly struct` mapping standard output and error lines.
* **Properties:**
  * `public string Stream { get; }`: Returns `"stdout"` or `"stderr"`.
  * `public string Line { get; }`: Returns the raw log line.

### 5. `ProfileParser` (Proxy URI Parser)
A static helper class used to parse and format URI connection strings.
* **Methods:**
  * `static ProfileItem ParseProfileUrl(string url)`: Parses supported proxy URI strings.
  * `static string ToProfileUrl(this ProfileItem profile)`: Extension method that formats a `ProfileItem` back into a proxy URI string.

### 6. `ProfileItem` (Proxy Profile Data)
A model class representing a parsed proxy node's properties.
* **Properties:**
  * `public ProfileType? Type { get; set; }` (Includes VMess, VLess, Shadowsocks, Trojan, Socks, Http, Hysteria2, Tuic)
  * Various configuration properties such as `Id`, `Password`, `Address`, `Port`, `Security`, `Network`, `Path`, `Sni`, etc.
* **Methods:**
  * `public OutboundConfig ToOutboundConfig()`: Extension method to convert the profile item directly into a `sing-box` compatible outbound configuration instance.

### 7. `UrlTester` (Latency Tester)
Measures latency for a single proxy profile.
* **Constructor:**
  * `public UrlTester(SingBoxWrapper singBoxWrapper, int localport, int timeout, int attempts, string? testUrl = null)`
* **Methods:**
  * `public async Task<UrlTestResult> TestAsync(ProfileItem profile)`

### 8. `ParallelUrlTester` (Concurrent Latency Tester)
Measures latency across a collection of profiles concurrently.
* **Constructor:**
  * `public ParallelUrlTester(SingBoxWrapper singBoxWrapper, int clashApiPort, int maxConcurrency, int timeout, int testChunkCount, string? testUrl = null)`
* **Methods:**
  * `public async Task ParallelTestAsync(IEnumerable<ProfileItem> profiles, IProgress<UrlTestResult> progressReporter, CancellationToken cancellationToken)`

### 9. `UrlTestResult` (Test Outcome)
An immutable `readonly struct` representing test outcomes.
* **Properties:**
  * `public required ProfileItem Profile { get; init; }`
  * `public int Delay { get; init; }`
  * `public required bool Success { get; init; }`

### 10. `ClashApiWrapper` (Clash API endpoints client)
Client for interacting with the internal sing-box Clash REST API.
* **Constructor:**
  * `public ClashApiWrapper(string externalControllerUrl)`
* **Methods:**
  * `public IAsyncEnumerable<LogInfo> GetLogs(CancellationToken cancellationToken = default)`
  * `public IAsyncEnumerable<TrafficInfo> GetTraffic(CancellationToken cancellationToken = default)`
  * `public Task<ProxyDelayInfo> GetProxyDelay(string name, int timeout, string? url = null, CancellationToken cancellationToken = default)`

### 11. Fluent Tag Extensions (`TagExtensions`)
Helper extension methods providing a fluent syntax for assigning tags to configurations.
* **Methods:**
  * `public static T WithTag<T>(this T inbound, string tag) where T : InboundConfig`
  * `public static T WithTag<T>(this T outbound, string tag) where T : OutboundConfig`

### 12. `SingBoxGrpcClient` (Native gRPC API Client)
Client for interacting with sing-box's native/V2Ray gRPC APIs.
* **Constructor:**
  * `public SingBoxGrpcClient(string address)`
* **Methods:**
  * `public Task<long> GetStatsAsync(string name, bool reset = false)`
  * `public Task<IDictionary<string, long>> QueryStatsAsync(IEnumerable<string> patterns, bool regexp = false, bool reset = false)`
  * `public Task<SysStatsResponse> GetSysStatsAsync()`

---

## Code Examples

### 1. Initializing and Running Sing-box
How to configure, spawn, and clean up a `sing-box` process:

```csharp
// 1. Define your sing-box configuration
var config = new SingBoxConfig
{
    Inbounds = new List<InboundConfig>
    {
        new MixedInbound("mixed-in")
        {
            Listen = "127.0.0.1",
            ListenPort = 2080
        }
    },
    Outbounds = new List<OutboundConfig>
    {
        new DirectOutbound("direct-out")
    }
};

// 2. Initialize wrapper with path to sing-box executable
var wrapper = new SingBoxWrapper("path/to/sing-box");

// 3. Subscribe to the log event to inspect output or errors
wrapper.OnLog += (sender, logArgs) =>
{
    string stream = logArgs.Stream == LogStream.StandardOutput ? "OUT" : "ERR";
    Console.WriteLine($"[{stream}] {logArgs.Line}");
};

// 4. Start the sing-box process
using var cts = new CancellationTokenSource();
var runTask = wrapper.StartAsync(config, cts.Token);

Console.WriteLine("Sing-box is running. Press any key to stop...");
Console.ReadKey();

// 5. Terminate the sing-box process gracefully by cancelling the token
await cts.CancelAsync();
await runTask;
```

### 2. Latency Testing a Single Node
How to measure proxy node latency:

```csharp
var wrapper = new SingBoxWrapper("path/to/sing-box");

// Parse connection URL
var profileUrl = "trojan://mypassword@myserver.com:443?security=tls&sni=myserver.com#NodeName";
var profile = ProfileParser.ParseProfileUrl(profileUrl);

// Create the latency tester
var urlTester = new UrlTester(
    singBoxWrapper: wrapper,
    localport: 2081,      // The local SOCKS port to bind
    timeout: 3000,        // Request timeout in milliseconds
    attempts: 3,          // Number of latency test attempts
    testUrl: null         // Target URL (defaults to http://cp.cloudflare.com/)
);

Console.WriteLine("Testing proxy latency...");
var result = await urlTester.TestAsync(profile);

if (result.Success)
{
    Console.WriteLine($"[SUCCESS] Name: {result.Profile.Name}, Delay: {result.Delay}ms");
}
else
{
    Console.WriteLine($"[FAILED] Name: {result.Profile.Name}");
}
```

### 3. Concurrent Latency Testing (Parallel)
How to concurrently test a batch of nodes using the parallel tester:

```csharp
var wrapper = new SingBoxWrapper("path/to/sing-box");

// Prepare list of nodes to test
var profiles = new List<ProfileItem>
{
    ProfileParser.ParseProfileUrl("vless://uuid1@server1.com:443?security=tls#Node1"),
    ProfileParser.ParseProfileUrl("ss://YWVzLTEyOC1nY206cGFzcw==@server2.com:8388#Node2"),
    ProfileParser.ParseProfileUrl("trojan://pass3@server3.com:443?security=tls#Node3"),
};

// Create a parallel URL tester (uses Clash Api under the hood)
using var parallelTester = new ParallelUrlTester(
    singBoxWrapper: wrapper,
    clashApiPort: 9090,     // Clash API external controller port
    maxConcurrency: 5,      // Max concurrent test tasks
    timeout: 3000,          // Request timeout in milliseconds
    testChunkCount: 10,     // Chunk size (number of proxies tested per batch)
    testUrl: null           // Target URL (defaults to http://cp.cloudflare.com/)
);

var results = new ConcurrentBag<UrlTestResult>();

// Define progress reporter callback
var progress = new Progress<UrlTestResult>(result =>
{
    if (result.Success)
    {
        Console.WriteLine($"[Tested] {result.Profile.Name}: {result.Delay}ms");
    }
    else
    {
        Console.WriteLine($"[Tested] {result.Profile.Name}: Failed");
    }
    results.Add(result);
});

using var cts = new CancellationTokenSource();

Console.WriteLine("Running parallel tests...");
await parallelTester.ParallelTestAsync(profiles, progress, cts.Token);

Console.WriteLine("All tests completed!");
```

### 4. Deserializing with `SingBoxJsonContext` (AOT-Safe)
If your application targets **Native AOT** or requires reflection-free JSON serialization, you must pass `SingBoxJsonContext.Default` to `JsonSerializer`:

#### Deserializing a Single Configuration
```csharp
using System.Text.Json;
using SingBoxLib.Configuration;
using SingBoxLib.Configuration.Serialization;

string jsonString = GetConfigJson();

// AOT-safe deserialization of the root configuration
SingBoxConfig? config = JsonSerializer.Deserialize(jsonString, SingBoxJsonContext.Default.SingBoxConfig);

// Deserializing an individual polymorphic outbound
OutboundConfig? outbound = JsonSerializer.Deserialize(jsonString, SingBoxJsonContext.Default.OutboundConfig);
```

#### Deserializing Lists of Configurations
`SingBoxJsonContext` comes with pre-compiled, AOT-compatible metadata for lists and arrays of all base configuration types:
```csharp

string jsonList = GetOutboundListJson();

// Deserializing a list of polymorphic outbounds
List<OutboundConfig>? outbounds = JsonSerializer.Deserialize(jsonList, SingBoxJsonContext.Default.ListOutboundConfig);

// Deserializing an array of polymorphic outbounds
OutboundConfig[]? outboundsArray = JsonSerializer.Deserialize(jsonList, SingBoxJsonContext.Default.OutboundConfigArray);
```

### 5. Using SingBoxGrpcClient (Native gRPC API)
How to communicate with sing-box's native gRPC API:

```csharp
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SingBoxLib.Runtime.Api.Grpc;

// 1. Initialize the client targeting the listening port (v2ray_api listen address)
using var client = new SingBoxGrpcClient("http://127.0.0.1:2333");

// 2. Query statistics for a tag/name
long downloadBytes = await client.GetStatsAsync("outbound-tag");
Console.WriteLine($"Downloaded: {downloadBytes} bytes");

// 3. Query multiple stats using search patterns/regexes
var queryResult = await client.QueryStatsAsync(new[] { "outbound-tag", "direct" }, regexp: false);
foreach (var (name, value) in queryResult)
{
    Console.WriteLine($"Stat {name}: {value} bytes");
}

// 4. Retrieve system metrics (memory allocation, uptime, etc.)
var sysStats = await client.GetSysStatsAsync();
Console.WriteLine($"Uptime: {sysStats.Uptime} seconds, Alloc: {sysStats.Alloc} bytes");
```
```


