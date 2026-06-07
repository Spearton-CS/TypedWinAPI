namespace TypedWinAPI.Kernel32;

public enum MediaType : int
{
    Unknown = 0x00,
    F5_1Pt2_512 = 0x01,      // 5.25", 1.2MB,  512 bytes/sector
    F3_1Pt44_512 = 0x02,     // 3.5",  1.44MB, 512 bytes/sector
    F3_2Pt88_512 = 0x03,     // 3.5",  2.88MB, 512 bytes/sector
    F3_20Pt8_512 = 0x04,     // 3.5",  20.8MB, 512 bytes/sector
    F3_720_512 = 0x05,       // 3.5",  720KB,  512 bytes/sector
    F5_360_512 = 0x06,       // 5.25", 360KB,  512 bytes/sector
    F5_320_512 = 0x07,       // 5.25", 320KB,  512 bytes/sector
    F5_320_1024 = 0x08,      // 5.25", 320KB,  1024 bytes/sector
    F5_180_512 = 0x09,       // 5.25", 180KB,  512 bytes/sector
    F5_160_512 = 0x0A,       // 5.25", 160KB,  512 bytes/sector
    RemovableMedia = 0x0B,   // USB and etc.
    FixedMedia = 0x0C,       // HDD/SSD
    F3_120M_512 = 0x0D,      // 3.5", 120M Floppy
    F3_640_512 = 0x0E,
    F5_640_512 = 0x0F,
    F5_720_512 = 0x10,
    F3_1Pt2_512 = 0x11,
    F3_1Pt23_1024 = 0x12,
    F5_1Pt23_1024 = 0x13,
    F3_128Mb_512 = 0x14,
    F3_230Mb_512 = 0x15,
    F8_256_128 = 0x16,
    F3_200Mb_512 = 0x17,
    F3_240M_512 = 0x18,
    F3_32M_512 = 0x19
}