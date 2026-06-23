namespace SingBoxLib.Configuration.Shared;

/// <summary>
/// Constants representing Shadowsocks encryption methods.
/// </summary>
public static class ShadowsocksEncryptions
{
    /// <summary>
    /// No encryption.
    /// </summary>
    public const string None = "none";

    /// <summary>
    /// blake3-aes-128-gcm encryption.
    /// </summary>
    public const string Blake3Aes128Gcm = "2022-blake3-aes-128-gcm";

    /// <summary>
    /// blake3-aes-256-gcm encryption.
    /// </summary>
    public const string Blake3Aes256Gcm = "2022-blake3-aes-256-gcm";

    /// <summary>
    /// blake3-chacha20-poly1305 encryption.
    /// </summary>
    public const string Blake3Chacha20Poly1305 = "2022-blake3-chacha20-poly1305";

    /// <summary>
    /// aes-128-gcm encryption.
    /// </summary>
    public const string Aes128Gcm = "aes-128-gcm";

    /// <summary>
    /// aes-192-gcm encryption.
    /// </summary>
    public const string Aes192Gcm = "aes-192-gcm";

    /// <summary>
    /// aes-256-gcm encryption.
    /// </summary>
    public const string Aes256Gcm = "aes-256-gcm";

    /// <summary>
    /// chacha20-ietf-poly1305 encryption.
    /// </summary>
    public const string Chacha20IetfPoly1305 = "chacha20-ietf-poly1305";

    /// <summary>
    /// xchacha20-ietf-poly1305 encryption.
    /// </summary>
    public const string Xchacha20IetfPoly1305 = "xchacha20-ietf-poly1305";

    /// <summary>
    /// aes-128-ctr encryption (legacy).
    /// </summary>
    public const string Aes128Ctr = "aes-128-ctr";

    /// <summary>
    /// aes-192-ctr encryption (legacy).
    /// </summary>
    public const string Aes192Ctr = "aes-192-ctr";

    /// <summary>
    /// aes-256-ctr encryption (legacy).
    /// </summary>
    public const string Aes256Ctr = "aes-256-ctr";

    /// <summary>
    /// aes-128-cfb encryption (legacy).
    /// </summary>
    public const string Aes128Cfb = "aes-128-cfb";

    /// <summary>
    /// aes-192-cfb encryption (legacy).
    /// </summary>
    public const string Aes192Cfb = "aes-192-cfb";

    /// <summary>
    /// aes-256-cfb encryption (legacy).
    /// </summary>
    public const string Aes256Cfb = "aes-256-cfb";

    /// <summary>
    /// rc4-md5 encryption (legacy).
    /// </summary>
    public const string Rc4Md5 = "rc4-md5";

    /// <summary>
    /// chacha20-ietf encryption (legacy).
    /// </summary>
    public const string Chacha20Ietf = "chacha20-ietf";

    /// <summary>
    /// xchacha20 encryption (legacy).
    /// </summary>
    public const string Xchacha20 = "xchacha20";
}