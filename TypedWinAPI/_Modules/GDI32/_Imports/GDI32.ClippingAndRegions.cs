using System.Runtime.InteropServices;

namespace TypedWinAPI.GDI32;

unsafe partial class GDI32
{
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HRegion CreateRectRgn(int x1, int y1, int x2, int y2);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial RegionType SelectClipRgn(HDC hdc, HRegion hrgn);
}