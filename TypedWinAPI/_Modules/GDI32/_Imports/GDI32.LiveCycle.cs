using System.Runtime.InteropServices;

namespace TypedWinAPI.GDI32;

unsafe partial class GDI32
{
    #region Create

    [LibraryImport(DLL, SetLastError = true)]
    public static partial HDC CreateCompatibleDC(HDC hdc);
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HBitmap CreateCompatibleBitmap(HDC hdc, int cx, int cy);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial HBrush CreateSolidBrush(Color crColor);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial HPen CreatePen(PenStyle fnPenStyle, int nWidth, Color crColor);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial HFont CreateFontW(
        int nHeight, int nWidth, int nEscapement, int nOrientation,
        FontWeight fnWeight, byte fdwItalic, byte fdwUnderline, byte fdwStrikeOut,
        FontCharSet fdwCharSet, FontOutputPrecision fdwOutputPrecision, FontClipPrecision fdwClipPrecision,
        FontQuality fdwQuality, FontPitchAndFamily fdwPitchAndFamily, char* lpszFace);

#if ManagedStrings
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial HFont CreateFontW(
        int nHeight, int nWidth, int nEscapement, int nOrientation,
        FontWeight fnWeight, byte fdwItalic, byte fdwUnderline, byte fdwStrikeOut,
        FontCharSet fdwCharSet, FontOutputPrecision fdwOutputPrecision, FontClipPrecision fdwClipPrecision,
        FontQuality fdwQuality, FontPitchAndFamily fdwPitchAndFamily, string lpszFace);
#endif

#endregion

    #region Delete

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 DeleteObject(HObj ho);
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 DeleteDC(HDC hdc);

    #endregion

    [LibraryImport(DLL, SetLastError = true)]
    public static partial HObj SelectObject(HDC hdc, Handle h);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial HObj GetStockObject(StockObjects i);
}