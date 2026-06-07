namespace TypedWinAPI.Kernel32;

public enum VideoDisplayMode : uint
{
    // VGA/SVGA Standardized indices
    ModeVga640x480x16 = 0x00,
    ModeVga640x480x256 = 0x01,
    ModeVga800x600x16 = 0x02,
    ModeVga800x600x256 = 0x03,
    ModeVga1024x768x16 = 0x04,
    ModeVga1024x768x256 = 0x05,

    // Extended modes often found in legacy miniports
    ModeHiColor800x600x16bit = 0x10,
    ModeTrueColor1024x768x32bit = 0x20
}