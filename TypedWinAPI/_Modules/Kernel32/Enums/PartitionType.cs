namespace TypedWinAPI.Kernel32;

public enum PartitionType : byte
{
    Unused = 0x00,
    Fat12 = 0x01,
    XenixRoot = 0x02,
    XenixUsr = 0x03,
    Fat16Small = 0x04,
    Extended = 0x05,
    Fat16 = 0x06,
    Ntfs = 0x07,
    Os2 = 0x0A,
    Fat32 = 0x0B,
    Fat32Lba = 0x0C,
    Fat16Lba = 0x0E,
    ExtendedLba = 0x0F,
    LinuxSwap = 0x82,
    LinuxNative = 0x83,
    LinuxExtended = 0x85,
    Hibernation = 0xA0,
    FreeBsd = 0xA5,
    OpenBsd = 0xA6,
    NetBsd = 0xA9,
    Gpt = 0xEE,
    Dynamic = 0x42,
    Db6 = 0xED
}