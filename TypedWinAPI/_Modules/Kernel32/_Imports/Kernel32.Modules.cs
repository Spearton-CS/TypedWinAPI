using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

unsafe partial class Kernel32
{
    /// <summary>
    /// Retrieves a module handle for the specified module.
    /// </summary>
    /// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file).</param>
    /// <returns>A <see cref="Handle"/> to the module, or a null handle if the function fails.</returns>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HInstance GetModuleHandleW(char* lpModuleName);
#if ManagedStrings
    /// <summary>
    /// Retrieves a module handle for the specified module using a managed string.
    /// </summary>
    /// <param name="lpModuleName">The name of the loaded module.</param>
    /// <returns>A <see cref="Handle"/> to the module.</returns>
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial HInstance GetModuleHandleW(string lpModuleName);
#endif

    /// <summary>
    /// Retrieves the module handle for the current process.
    /// </summary>
    /// <remarks>
    /// This is a convenience wrapper that calls <c>GetModuleHandleW</c> with a null pointer,
    /// which returning the base address of the mapping for the calling process.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance GetCurrentModule() => GetModuleHandleW((char*)null);
}