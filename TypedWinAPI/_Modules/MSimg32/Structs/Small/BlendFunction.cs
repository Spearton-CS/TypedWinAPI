using System.Runtime.InteropServices;

namespace TypedWinAPI.MSimg32;

[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct BlendFunction
{
    public BlendFunction(byte constantAlpha, bool usePerPixelAlpha)
    {
        BlendOp = 0; // AC_SRC_OVER
        BlendFlags = 0;
        SourceConstantAlpha = constantAlpha;
        AlphaFormat = usePerPixelAlpha ? (byte)1 : (byte)0;
    }

    [FieldOffset(0)] public int SignedRaw;
    [FieldOffset(0)] public uint UnsignedRaw;

    [FieldOffset(0)] public byte BlendOp;
    [FieldOffset(1)] public byte BlendFlags;
    [FieldOffset(2)] public byte SourceConstantAlpha;
    [FieldOffset(3)] public byte AlphaFormat;
}