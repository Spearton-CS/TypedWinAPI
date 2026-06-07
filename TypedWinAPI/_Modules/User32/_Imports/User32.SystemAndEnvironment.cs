using System.Runtime.CompilerServices;
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetSystemMetricsValue<T>(SystemMetricIndex nIndex)
        where T : unmanaged
    {
#if DEBUG
        if (sizeof(T) > sizeof(int))
            throw new InvalidCastException("T is too huge for GetSystemMetricsValue. Maximum is 4 byte");
        else
        {
#endif
            int result = GetSystemMetrics(nIndex);
            return Unsafe.As<int, T>(ref result);
#if DEBUG
        }
#endif
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 GetSystemMetricsFlag(SystemMetricIndex nIndex) => (Bool4)GetSystemMetrics(nIndex);

    #endregion
}