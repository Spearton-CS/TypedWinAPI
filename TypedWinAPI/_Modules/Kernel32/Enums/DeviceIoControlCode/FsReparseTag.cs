namespace TypedWinAPI.Kernel32;

public enum FsReparseTag : uint
{
    MountPoint = 0xA0000003,
    SymbolicLink = 0xA000000C,
    AppExecLink = 0x8000001B
}