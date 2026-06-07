using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipGetImageWidth")]
    public static partial Status GetImageWidth(HImage image, out uint width);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipGetImageHeight")]
    public static partial Status GetImageHeight(HImage image, out uint height);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawImage")]
    public static partial Status DrawImage(HGraphics graphics, HImage image, float x, float y);
}