namespace TypedWinAPI.Kernel32;

/// <summary>
/// Defines how data is passed between the application and the driver.
/// </summary>
public enum Method : byte
{
    /// <summary> Input and output buffers are both buffered. </summary>
    Buffered = 0,
    /// <summary> Input buffer is direct, output is direct. </summary>
    InDirect = 1,
    /// <summary> Output buffer is direct. </summary>
    OutDirect = 2,
    /// <summary> Neither buffered nor direct. </summary>
    Neither = 3
}