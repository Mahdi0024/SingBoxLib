using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingboxLib.Configuration.Dns;
public sealed class DnsAction
{
    [JsonProperty("action")]
    public string? Action { get; set; }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("rewrite_ttl")]
    public int? RewriteTtl { get; set; }

    [JsonProperty("client_subnet")]
    public string? ClientSubnet { get; set; }

    [JsonProperty("disable_cache")]
    public bool? DisableCache { get; set; }

    [JsonProperty("method")]
    public string? Method { get; set; }

    [JsonProperty("no_drop")]
    public bool? NoDrop { get; set; }
}
