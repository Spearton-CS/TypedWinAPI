using System.Runtime.InteropServices;

namespace TypedWinAPI.GDI32;

[StructLayout(LayoutKind.Explicit, Size = 40)]
public unsafe struct BitmapInfo()
{
    [FieldOffset(0)] public int biSize = 40;
    [FieldOffset(4)] public int biWidth;
    [FieldOffset(8)] public int biHeight;
    [FieldOffset(12)] public short biPlanes;
    [FieldOffset(14)] public BitCount biBitCount;
    [FieldOffset(16)] public Compression biCompression;
    [FieldOffset(20)] public int biSizeImage;
    [FieldOffset(24)] public int biXPelsPerMeter;
    [FieldOffset(28)] public int biYPelsPerMeter;
    [FieldOffset(32)] public int biClrUsed;
    [FieldOffset(36)] public int biClrImportant;
}