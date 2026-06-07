using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

[StructLayout(LayoutKind.Explicit, Size = 68)]
public unsafe struct MsgBoxParamsW()
{
    [FieldOffset(0)] public uint cbSize = 68;
    [FieldOffset(4)] public HWND hwndOwner;
    [FieldOffset(12)] public Kernel32.HInstance hInstance;
    [FieldOffset(20)] public char* lpszText;
    [FieldOffset(28)] public char* lpszCaption;
    [FieldOffset(36)] public MessageBoxStyle dwStyle;
    [FieldOffset(40)] public char* lpszIcon;          // Icon resource name
    [FieldOffset(48)] public nuint dwContextHelpId;
    [FieldOffset(56)] public delegate* unmanaged[Stdcall]<HelpInfo*, void> lpfnMsgBoxCallback;
    [FieldOffset(64)] public Kernel32.LanguageId dwLanguageId;
}