using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

unsafe partial class User32
{
    #region System metrics

    /// <summary> Retrieves the specified system metric or system configuration setting. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetSystemMetrics(SystemMetricIndex nIndex);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial int GetSystemMetricsForDpi(SystemMetricIndex nIndex, uint dpi);

    #endregion

    #region DPI (Windows 10 and 11 only)

    [LibraryImport(DLL, SetLastError = true)]
    public static partial uint GetDpiForWindow(HWND hwnd);

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 SetProcessDpiAwarenessContext(DpiAwarenessContext value);

    #endregion
}