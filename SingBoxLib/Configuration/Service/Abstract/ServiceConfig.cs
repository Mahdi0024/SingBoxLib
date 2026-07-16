namespace SingBoxLib.Configuration.Service.Abstract;

/// <summary>
/// Represents the base class for service configurations.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ApiServiceConfig), "api")]
[JsonDerivedType(typeof(CcmServiceConfig), "ccm")]
[JsonDerivedType(typeof(DerpServiceConfig), "derp")]
[JsonDerivedType(typeof(HysteriaRealmServiceConfig), "hysteria-realm")]
[JsonDerivedType(typeof(OcmServiceConfig), "ocm")]
[JsonDerivedType(typeof(ResolvedServiceConfig), "resolved")]
[JsonDerivedType(typeof(SsmApiServiceConfig), "ssm-api")]
[JsonDerivedType(typeof(UsbipServerServiceConfig), "usbip-server")]
[JsonDerivedType(typeof(UsbipClientServiceConfig), "usbip-client")]
public abstract class ServiceConfig
{
    /// <summary>
    /// Gets or sets the service type.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; internal set; }

    /// <summary>
    /// Gets or sets the unique tag for the service.
    /// </summary>
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }
}
