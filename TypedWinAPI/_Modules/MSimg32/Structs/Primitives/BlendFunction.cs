using System.Runtime.CompilerServices;

namespace TypedWinAPI.MSimg32;

[SkipLocalsInit]
partial struct BlendFunction
{
    public BlendFunction() => UnsignedRaw = 0;
    public BlendFunction(uint unsig) => UnsignedRaw = unsig;
    public BlendFunction(int sig) => SignedRaw = sig;
    public BlendFunction(byte constantAlpha, bool usePerPixelAlpha)
    {
        BlendOp = 0; // AC_SRC_OVER
        BlendFlags = 0;
        SourceConstantAlpha = constantAlpha;
        AlphaFormat = usePerPixelAlpha ? (byte)1 : (byte)0;
    }
    public BlendFunction(byte blendOp, byte blendFlags, byte sourceConstantAlpha, byte alphaFormat)
    {
        BlendOp = blendOp;
        BlendFlags = blendFlags;
        SourceConstantAlpha = sourceConstantAlpha;
        AlphaFormat = alphaFormat;
    }
}