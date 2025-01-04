namespace SingBoxLib.Configuration.Shared;

public static class ShadowsocksEncryptions
{
    public const string None = "none";

    public const string Blake3Aes128Gcm = "2022-blake3-aes-128-gcm";
    public const string Blake3Aes256Gcm = "2022-blake3-aes-256-gcm";
    public const string Blake3Chacha20Poly1305 = "2022-blake3-chacha20-poly1305";
    public const string Aes128Gcm = "aes-128-gcm";
    public const string Aes192Gcm = "aes-192-gcm";
    public const string Aes256Gcm = "aes-256-gcm";
    public const string Chacha20IetfPoly1305 = "chacha20-ietf-poly1305";
    public const string Xchacha20IetfPoly1305 = "xchacha20-ietf-poly1305";
    // Legacy:
    public const string Aes128Ctr = "aes-128-ctr";
    public const string Aes192Ctr = "aes-192-ctr";
    public const string Aes256Ctr = "aes-256-ctr";
    public const string Aes128Cfb = "aes-128-cfb";
    public const string Aes192Cfb = "aes-192-cfb";
    public const string Aes256Cfb = "aes-256-cfb";
    public const string Rc4Md5 = "rc4-md5";
    public const string Chacha20Ietf = "chacha20-ietf";
    public const string Xchacha20 = "xchacha20";
}