using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipGraphicsClear")]
    public static partial Status Clear(HGraphics graphics, Color color);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipFillRectangle")]
    public static partial Status FillRectangle(
        HGraphics graphics, HBrush brush,
        float x, float y, float width, float height);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipFillPath")]
    public static partial Status FillPath(HGraphics graphics, HBrush brush, HPath path);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawEllipse")]
    public static partial Status DrawEllipse(
        HGraphics graphics, HPen pen,
        float x, float y, float width, float height);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipFillEllipse")]
    public static partial Status FillEllipse(
        HGraphics graphics, HBrush brush,
        float x, float y, float width, float height);
}