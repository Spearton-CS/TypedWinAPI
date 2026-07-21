using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
#if ManagedStrings
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipMeasureString", StringMarshalling = StringMarshalling.Utf16)]
    public static partial Status MeasureString(
        HGraphics graphics,
        string text, int length, HFont font,
        in RectF layoutRect, HStringFormat stringFormat, out RectF boundingBox,
        out int codepointsFitted, out int linesFilled);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawString", StringMarshalling = StringMarshalling.Utf16)]
    public static partial Status DrawString(
        HGraphics graphics,
        string text, int length, HFont font,
        in RectF layoutRect, HStringFormat stringFormat,
        HBrush brush);
#endif

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipMeasureString")]
    public static partial Status MeasureString(
        HGraphics graphics,
        char* text, int length, HFont font,
        in RectF layoutRect, HStringFormat stringFormat, out RectF boundingBox,
        out int codepointsFitted, out int linesFilled);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDrawString")]
    public static partial Status DrawString(
        HGraphics graphics,
        char* text, int length, HFont font,
        in RectF layoutRect, HStringFormat stringFormat,
        HBrush brush);
}