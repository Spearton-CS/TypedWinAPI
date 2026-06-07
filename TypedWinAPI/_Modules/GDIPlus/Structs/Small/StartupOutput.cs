using System.Runtime.InteropServices;

namespace TypedWinAPI.GDIPlus;

[StructLayout(LayoutKind.Explicit, Size = 16)]
public unsafe struct StartupOutput
{
    /// <summary>
    /// The hook procedure called by GDI+ to start a background thread.
    /// </summary>
    [FieldOffset(0)] public delegate* unmanaged[Stdcall]<out nint, delegate* unmanaged[Stdcall]<void>, Status> NotificationHook;

    /// <summary>
    /// The unhook procedure called by GDI+ to terminate a background thread.
    /// </summary>
    [FieldOffset(8)] public delegate* unmanaged[Stdcall]<nint, void> NotificationUnhook;
}