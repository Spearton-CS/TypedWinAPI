namespace TypedWinAPI.User32;

[Flags]
public enum HotKeyModifier : byte
{
    None = 0x00,
    Shift = 0x01, // HOTKEYF_SHIFT
    Control = 0x02, // HOTKEYF_CONTROL
    Alt = 0x04, // HOTKEYF_ALT
    Ext = 0x08  // HOTKEYF_EXT (Extended key modifier)
}