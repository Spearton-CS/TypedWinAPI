using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

[StructLayout(LayoutKind.Explicit, Size = 40)]
public struct HelpInfo()
{
    [FieldOffset(0)] public uint cbSize = 40;
    [FieldOffset(4)] public HelpInfoContextType iContextType;
    [FieldOffset(8)] public int iCtrlId;
    [FieldOffset(16)] public Handle hItemHandle;
    [FieldOffset(16)] public HWND hItemHWND;
    [FieldOffset(16)] public HMenu hItemHMenu;
    [FieldOffset(24)] public nuint dwContextId;
    [FieldOffset(32)] public Point mousePos;
}