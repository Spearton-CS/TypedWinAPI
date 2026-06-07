using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    #region Create

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateFromHDC")]
    public static partial Status CreateFromHDC(GDI32.HDC hdc, out HGraphics graphics);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateBitmapFromHBITMAP")]
    public static partial Status CreateBitmapFromHBITMAP(GDI32.HBitmap hbm, GDI32.HPalette hpal, out HBitmap bitmap);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateBitmapFromScan0")]
    public static partial Status CreateBitmapFromScan0(
        int width, int height,
        int stride, PixelFormat format,
        byte* scan0, out HBitmap bitmap);

    /// <summary> Creates a pen object with a specified color and width. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreatePen1")]
    public static partial Status CreatePen(Color color, float width, Unit unit, out HPen pen);

    /// <summary> Creates a solid color brush. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateSolidFill")]
    public static partial Status CreateSolidBrush(Color color, out HBrush brush);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateLineBrushI")]
    public static partial Status CreateLineBrush(
        in User32.Point pt1, in User32.Point pt2,
        Color color1, Color color2,
        WrapMode wrapMode, out HBrush brush);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateFontFamilyFromName")]
    public static partial Status CreateFontFamilyFromName(char* name, HFontCollection fontCollection, out HFontFamily fontFamily);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateFontFamilyFromName", StringMarshalling = StringMarshalling.Utf16)]
    public static partial Status CreateFontFamilyFromName(string name, HFontCollection fontCollection, out HFontFamily fontFamily);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateFont")]
    public static partial Status CreateFont(
        HFontFamily fontFamily,
        float emSize, FontStyle style, Unit unit,
        out HFont font);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreatePath")]
    public static partial Status CreatePath(FillMode fillMode, out HPath path);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateStringFormat")]
    public static partial Status CreateStringFormat(StringFormatAttributes formatAttributes, Kernel32.LanguageId language, out HStringFormat format);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipCreateMatrix")]
    public static partial Status CreateMatrix(out HMatrix matrix);

    #endregion

    #region Load

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipLoadImageFromFile")]
    public static partial Status LoadImageFromFile(char* filename, out HImage image);
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipLoadImageFromFile", StringMarshalling = StringMarshalling.Utf16)]
    public static partial Status LoadImageFromFile(string filename, out HImage image);

    #endregion

    #region Delete

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteGraphics")]
    public static partial Status DeleteGraphics(HGraphics graphics);

    /// <summary> Cleans up the pen object and releases its native memory. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeletePen")]
    public static partial Status DeletePen(HPen pen);

    /// <summary> Cleans up the brush object. </summary>
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteBrush")]
    public static partial Status DeleteBrush(HBrush brush);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteFont")]
    public static partial Status DeleteFont(HFont font);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteFontFamily")]
    public static partial Status DeleteFontFamily(HFontFamily fontFamily);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeletePath")]
    public static partial Status DeletePath(HPath path);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteStringFormat")]
    public static partial Status DeleteStringFormat(HStringFormat format);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDeleteMatrix")]
    public static partial Status DeleteMatrix(HMatrix matrix);

    #endregion

    #region Dispose

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipDisposeImage")]
    public static partial Status DisposeImage(HImage image);

    #endregion
}