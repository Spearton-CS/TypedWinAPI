using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetStringFormatAlign")]
    public static partial Status SetStringFormatAlign(HStringFormat format, StringAlignment align);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdipSetStringFormatLineAlign")]
    public static partial Status SetStringFormatLineAlign(HStringFormat format, StringAlignment align);
}