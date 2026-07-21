using System.Runtime.InteropServices;

namespace TypedWinAPI.GDI32;

unsafe partial class GDI32
{
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 BitBlt(
        HDC hdcDest, int xDest, int yDest, int w, int h,
        HDC hdcSource, int xSrc, int ySrc, TernaryRasterOperations rop);
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 PatBlt(HDC hdc,
        int x, int y, int w, int h,
        TernaryRasterOperations rop);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial BackgroundMode SetBkMode(HDC hdc, BackgroundMode mode);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 Rectangle(HDC hdc, int left, int top, int right, int bottom);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 MoveToEx(HDC hdc, int x, int y, User32.Point* lpPoint);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 LineTo(HDC hdc, int x, int y);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 Ellipse(HDC hdc, int left, int top, int right, int bottom);
}