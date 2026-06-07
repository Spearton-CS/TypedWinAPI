using System.Runtime.InteropServices;

namespace TypedWinAPI.Shell32;

[StructLayout(LayoutKind.Explicit, Size = 120)]
public unsafe struct ExecuteInfoW()
{
    [FieldOffset(0)] public uint cbSize = 120; //sizeof(ShellExecuteInfoW);
    [FieldOffset(8)] public ExecuteMask fMask;
    [FieldOffset(16)] public User32.HWND hwnd;
    [FieldOffset(24)] public char* lpVerb; //"open", "runas", "print" and etc.
    [FieldOffset(32)] public char* lpFile;
    [FieldOffset(40)] public char* lpParameters;
    [FieldOffset(48)] public char* lpDirectory;
    [FieldOffset(56)] public User32.ShowWindowCommand nShow;
    [FieldOffset(64)] public Kernel32.HInstance hInstApp;
    [FieldOffset(72)] public SHItemID* lpIDList;
    [FieldOffset(80)] public char* lpClass;
    [FieldOffset(88)] public ADVAPI32.HKey hKeyClass;
    [FieldOffset(96)] public User32.HotKey dwHotKey;
    [FieldOffset(104)] public User32.HIcon hIcon;
    [FieldOffset(104)] public SHCore.HMonitor hMonitor;
    [FieldOffset(112)] public HProcess hProcess;
}