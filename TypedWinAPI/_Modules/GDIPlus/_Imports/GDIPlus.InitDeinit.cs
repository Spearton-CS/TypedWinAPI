using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdiplusStartup")]
    public static partial Status Startup(out HSessionToken token, in StartupInput input, StartupOutput* output);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdiplusShutdown")]
    public static partial void Shutdown(HSessionToken token);
}