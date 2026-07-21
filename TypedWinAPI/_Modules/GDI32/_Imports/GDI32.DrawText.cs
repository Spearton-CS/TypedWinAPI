using System.Runtime.InteropServices;

namespace TypedWinAPI.GDI32;

unsafe partial class GDI32
{
    [LibraryImport(DLL, SetLastError = true)]
    public static partial Color SetTextColor(HDC hdc, Color crColor);

    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial Bool4 TextOutW(HDC hdc, int x, int y, char* lpString, int len);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 GetTextExtentPoint32W(HDC hdc, char* lpString, int len, out User32.Size lpSize);

#if ManagedStrings
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial Bool4 TextOutW(HDC hdc, int x, int y, string lpString, int len);

    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial Bool4 GetTextExtentPoint32W(HDC hdc, string lpString, int len, out User32.Size lpSize);
#endif
}