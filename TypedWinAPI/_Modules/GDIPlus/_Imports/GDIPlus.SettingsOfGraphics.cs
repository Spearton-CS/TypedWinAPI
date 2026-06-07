using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    /// <summary> Sets the rendering quality (Antialiasing). </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetSmoothingMode")]
    public static partial Status SetSmoothingMode(HGraphics graphics, SmoothingMode smoothingMode);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetTextRenderingHint")]
    public static partial Status SetTextRenderingHint(HGraphics graphics, TextRenderingHint hint);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetPixelOffsetMode")]
    public static partial Status SetPixelOffsetMode(HGraphics graphics, PixelOffsetMode pixelOffsetMode);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetInterpolationMode")]
    public static partial Status SetInterpolationMode(HGraphics graphics, InterpolationMode interpolationMode);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetWorldTransform")]
    public static partial Status SetWorldTransform(HGraphics graphics, HMatrix matrix);
}