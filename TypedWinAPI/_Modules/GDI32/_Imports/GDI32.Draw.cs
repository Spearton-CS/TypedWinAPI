using System.Runtime.CompilerServices;
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 Rectangle(HDC hdc, User32.Rect rect) => Rectangle(hdc, rect.Left, rect.Top, rect.Right, rect.Bottom);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 MoveToEx(HDC hdc, int x, int y, User32.Point* lpPoint);
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 MoveToEx(HDC hdc, int x, int y, ref User32.Point lpPoint);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 MoveToEx(HDC hdc, int x, int y) => MoveToEx(hdc, x, y, null);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 LineTo(HDC hdc, int x, int y);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 Ellipse(HDC hdc, int left, int top, int right, int bottom);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 Ellipse(HDC hdc, User32.Rect rect) => Ellipse(hdc, rect.Left, rect.Top, rect.Right, rect.Bottom);
}