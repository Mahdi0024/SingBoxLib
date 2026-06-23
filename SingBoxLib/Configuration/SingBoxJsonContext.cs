using System.Text.Json.Serialization;
using SingBoxLib.Configuration;
using SingBoxLib.Parsing.ProfileModels;
using SingBoxLib.Runtime.Api.Clash.Models;
using SingBoxLib.Runtime.Api.Clash;

namespace SingBoxLib.Configuration;

[JsonSourceGenerationOptions(WriteIndented = false, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(SingBoxConfig))]
[JsonSerializable(typeof(LogInfo))]
[JsonSerializable(typeof(TrafficInfo))]
[JsonSerializable(typeof(VersionInfo))]
[JsonSerializable(typeof(ConfigInfo))]
[JsonSerializable(typeof(RuleInfo))]
[JsonSerializable(typeof(ProxyInfo))]
[JsonSerializable(typeof(ProxyDelayInfo))]
[JsonSerializable(typeof(VMessProfileModel))]
[JsonSerializable(typeof(ClashApiWrapper.ReloadConfigRequest))]
[JsonSerializable(typeof(ClashApiWrapper.RulesResponse))]
[JsonSerializable(typeof(ClashApiWrapper.ProxiesResponse))]
internal partial class SingBoxJsonContext : JsonSerializerContext
{
}
