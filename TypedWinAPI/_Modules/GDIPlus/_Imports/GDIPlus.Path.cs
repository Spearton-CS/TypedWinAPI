using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipAddPathLine")]
    public static partial Status AddPathLine(HPath path, float x1, float y1, float x2, float y2);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipClosePathFigure")]
    public static partial Status ClosePathFigure(HPath path);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipAddPathRectangle")]
    public static partial Status AddPathRectangle(HPath path, float x, float y, float width, float height);
}