namespace TypedWinAPI.Kernel32;

[Flags]
public enum PartitionAttributes : ulong
{
    None = 0x0000000000000000,
    GptRequiredPartition = 0x0000000000000001,
    GptNoDriveLetter = 0x8000000000000000,
    GptHidden = 0x4000000000000000,
    GptShadowCopy = 0x2000000000000000,
    GptReadOnly = 0x1000000000000000,
    GptNoBlockIo = 0x0800000000000000
}