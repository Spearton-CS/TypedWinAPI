using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

/// <summary>
/// Provides a comprehensive wrapper for user interface functions (user32.dll).
/// </summary>
public static unsafe partial class User32
{
    /// <summary>
    /// The name of the native library.
    /// </summary>
    public const string DLL = "user32.dll";

    #region Cursor

    /// <summary> Loads the specified cursor resource from the executable file associated with an application instance. </summary>
    [LibraryImport(DLL, SetLastError = true)]
    public static partial HCursor LoadCursorW(Kernel32.HInstance hInstance, char* lpCursorName);
#if ManagedStrings
    /// <summary> Loads the specified cursor resource using a managed string. </summary>
    [LibraryImport(DLL, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial HCursor LoadCursorW(Kernel32.HInstance hInstance, string lpCursorName);
#endif

#endregion
}