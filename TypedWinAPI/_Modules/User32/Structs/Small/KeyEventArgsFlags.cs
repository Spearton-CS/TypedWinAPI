using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

/// <summary>
/// Helper structure to decode keyboard message flags contained in lParam.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8)]
public readonly record struct KeyEventArgsFlags(
    [field: FieldOffset(0)] LParam lParam)
{
    public const nint
        RepeatCountMask = 0x0000_FFFF,
        ScanCodeMask = 0x00FF_0000,
        ExtendedKeyMask = 0x0100_0000,
        ContextCodeMask = 0x2000_0000,
        PreviousStateMask = 0x4000_0000,
        TransitionStateMask = int.MinValue; // 0x8000_0000

    /// <summary>
    /// The repeat count for the current message.
    /// </summary>
    public readonly int RepeatCount
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (int)((nint)lParam & RepeatCountMask);
    }

    /// <summary>
    /// The hardware scan code.
    /// </summary>
    public readonly byte ScanCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (byte)(((nint)lParam & ScanCodeMask) >> 16);
    }

    /// <summary>
    /// Indicates whether the key is an extended key (e.g., right-hand Alt/Ctrl).
    /// </summary>
    public readonly bool IsExtendedKey
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ((nint)lParam & ExtendedKeyMask) != 0;
    }

    /// <summary>
    /// The context code. True if the ALT key is down while the key is pressed.
    /// </summary>
    public readonly bool IsAltDown
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ((nint)lParam & ContextCodeMask) != 0;
    }

    /// <summary>
    /// The previous key state. True if the key was down before the message was sent (autorepeat).
    /// </summary>
    public readonly bool IsRepeat
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ((nint)lParam & PreviousStateMask) != 0;
    }

    /// <summary>
    /// The transition state. False if the key is being pressed, true if it is being released.
    /// </summary>
    public readonly bool IsReleased
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ((nint)lParam & TransitionStateMask) != 0;
    }
}