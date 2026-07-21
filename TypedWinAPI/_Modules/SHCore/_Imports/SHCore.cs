using System.Runtime.InteropServices;

namespace TypedWinAPI.SHCore;

public static unsafe partial class SHCore
{
    public const string DLL = "shcore.dll";

    #region DPI

    /// <summary>
    /// Sets the DPI awareness for the current process.
    /// </summary>
    /// <remarks>Call before creating any UI or windows. Available on Windows 8.1 and later. Do not mix with
    /// SetProcessDPIAware; attempting to change awareness after initialization may fail.</remarks>
    /// <param name="value">One of the PROCESS_DPI_AWARENESS values that specifies the desired DPI awareness level for the process.</param>
    /// <returns>HRESULT indicating success or failure. S_OK if the awareness was set; otherwise an error code such as
    /// E_INVALIDARG or E_ACCESSDENIED.</returns>
    [LibraryImport(SHCore.DLL, SetLastError = true)]
    public static partial HResult SetProcessDpiAwareness(ProcessDpiAwareness value);
    /// <summary>
    /// Retrieves the dots-per-inch (DPI) for the specified monitor.
    /// </summary>
    /// <remarks>Supported on Windows 8.1 and later. The dpiType parameter selects between effective, angular,
    /// or raw DPI; results depend on the process's DPI awareness. Callers must supply a valid monitor handle and handle
    /// failed HRESULTs.</remarks>
    /// <param name="hmon">Handle to the monitor.</param>
    /// <param name="dpiType">Type of DPI to retrieve, specified as a MONITOR_DPI_TYPE value.</param>
    /// <param name="dpiX">Receives the horizontal DPI value.</param>
    /// <param name="dpiY">Receives the vertical DPI value.</param>
    /// <returns>An HRESULT value: S_OK on success; otherwise an error code.</returns>
    [LibraryImport(SHCore.DLL, SetLastError = true)]
    public static partial HResult GetDpiForMonitor(HMonitor hmon, MonitorDpiType dpiType, out uint dpiX, out uint dpiY);

    #endregion
}