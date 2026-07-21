using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

/// <summary>
/// Provides access for the core Windows kernel functions (kernel32.dll).
/// </summary>
public static unsafe partial class Kernel32
{
    /// <summary>
    /// The name of the native library.
    /// </summary>
    public const string DLL = "kernel32.dll";

    #region DeviceIoControl

    [LibraryImport(DLL, SetLastError = true)]
    public static partial Bool4 DeviceIoControl(
        HDevice hDevice, DeviceIoControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
    HDevice hDevice, DiskControlCode dwIoControlCode,
    void* lpInBuffer, uint nInBufferSize,
    void* lpOutBuffer, uint nOutBufferSize,
    out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
        HDevice hDevice, FsControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
        HDevice hDevice, MountMgrControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
        HDevice hDevice, StorageControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Bool4 DeviceIoControl(
        HDevice hDevice, VideoControlCode dwIoControlCode,
        void* lpInBuffer, uint nInBufferSize,
        void* lpOutBuffer, uint nOutBufferSize,
        out uint lpBytesReturned, void* lpOverlapped)
        => DeviceIoControl(hDevice, (DeviceIoControlCode)(uint)dwIoControlCode,
            lpInBuffer, nInBufferSize,
            lpOutBuffer, nOutBufferSize,
            out lpBytesReturned, lpOverlapped);


    #endregion

    /// <summary>
    /// Retrieves a module handle for the specified module.
    /// </summary>
    /// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file).</param>
    /// <returns>A <see cref="Handle"/> to the module, or a null handle if the function fails.</returns>
    [LibraryImport(Kernel32.DLL, SetLastError = true)]
    public static partial HInstance GetModuleHandleW(char* lpModuleName);
#if ManagedStrings
    /// <summary>
    /// Retrieves a module handle for the specified module using a managed string.
    /// </summary>
    /// <param name="lpModuleName">The name of the loaded module.</param>
    /// <returns>A <see cref="Handle"/> to the module.</returns>
    [LibraryImport(Kernel32.DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial HInstance GetModuleHandleW(string lpModuleName);
#endif
}