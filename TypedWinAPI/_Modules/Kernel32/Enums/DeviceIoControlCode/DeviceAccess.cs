namespace TypedWinAPI.Kernel32;

/// <summary>
/// Defines the required access rights to issue the control code.
/// </summary>
[Flags]
public enum DeviceAccess : byte
{
    /// <summary> Request all access. </summary>
    Any = 0,
    /// <summary> Read access. </summary>
    Read = 1,
    /// <summary> Write access. </summary>
    Write = 2
}