﻿using SingboxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Converters;
using SingBoxLib.Configuration.Inbound.Abstract;
using SingBoxLib.Configuration.Inbound.Shared;
using SingBoxLib.Configuration.Transport.Abstract;

namespace SingBoxLib.Configuration.Inbound;

public sealed class TrojanInbound : InboundConfig
{
    public TrojanInbound()
    {
        Type = "trojan";
        Tag = "trojan-in";
    }

    [JsonProperty("users")]
    public List<ProxyUserInbound>? Users { get; set; }

    [JsonProperty("tls")]
    public InboundTlsConfig? Tls { get; set; }

    [JsonProperty("fallback")]
    public TrojanFallback? Fallback { get; set; }

    [JsonProperty("fallback_for_alpn")]
    public Dictionary<string, TrojanFallback>? FallbackForAlpn { get; set; }

    [JsonConverter(typeof(TransportConfigJsonConverter))]
    [JsonProperty("transport")]
    public TransportConfig? Transport { get; set; }
}

public sealed class TrojanFallback
{
    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }
}