using System.Runtime.InteropServices;

namespace TypedWinAPI.GDI32;

unsafe partial class GDI32
{
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HBitmap CreateDIBSection(
        HDC hdc,
        ref BitmapInfo pbmi,
        DibIUsage iUsage,
        out byte* ppvBits,
        Handle hSection, uint dwOffset);
}