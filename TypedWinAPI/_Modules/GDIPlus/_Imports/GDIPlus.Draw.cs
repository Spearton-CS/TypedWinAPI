using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawLine")]
    public static partial Status DrawLine(
        HGraphics graphics, HPen pen,
        float x1, float y1, float x2, float y2);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawRectangle")]
    public static partial Status DrawRectangle(
        HGraphics graphics, HPen pen,
        float x, float y, float width, float height);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawPath")]
    public static partial Status DrawPath(HGraphics graphics, HPen pen, HPath path);
}