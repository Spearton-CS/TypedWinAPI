using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

unsafe partial class GDIPlus
{
    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdiplusStartup")]
    public static partial Status Startup(out HSessionToken token, in StartupInput input, StartupOutput* output);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Status Startup(out HSessionToken token, in StartupInput input, out StartupOutput output)
    {
        fixed (StartupOutput* outputPtr = &output)
            return Startup(out token, in input, outputPtr);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Status Startup(out HSessionToken token, in StartupInput input) => Startup(out token, in input, null);

    [LibraryImport(DLL, SetLastError = true, EntryPoint = "GdiplusShutdown")]
    public static partial void Shutdown(HSessionToken token);
}