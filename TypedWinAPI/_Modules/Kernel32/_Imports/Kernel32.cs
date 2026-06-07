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
}