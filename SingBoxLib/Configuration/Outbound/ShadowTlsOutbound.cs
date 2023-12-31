﻿using SingboxLib.Configuration.Outbound.Shared;
using SingBoxLib.Configuration.Outbound.Abstract;

namespace SingBoxLib.Configuration.Outbound;

public sealed class ShadowTlsOutbound : OutboundWithDialFields
{
    public ShadowTlsOutbound()
    {
        Type = "shadowtls";
        Tag = "shadowtls-out";
    }

    [JsonProperty("server")]
    public string? Server { get; set; }

    [JsonProperty("server_port")]
    public int? ServerPort { get; set; }

    [JsonProperty("version")]
    public int? Version { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("tls")]
    public OutboundTlsConfig? Tls { get; set; }
}