namespace TypedWinAPI.Kernel32;

public enum DiskControlCode : uint
{
    GetDriveGeometry = 0x00070000, // Legacy geometry (cylinders, tracks)
    GetDriveGeometryEx = 0x000700A0, // Modern geometry with disk size
    GetPartitionInfo = 0x00070004, // Basic partition data
    GetPartitionInfoEx = 0x00070048, // GPT/MBR detailed info
    SetPartitionInfoEx = 0x0007004C, // Modify partition parameters
    GetDriveLayoutEx = 0x00070114, // Full partition table map
    UpdateProperties = 0x00070140, // Sync cache/partition table changes
    FormatTracks = 0x0007C008, // Low-level track formatting
    IsWritable = 0x00070024,  // Check if media is write-protected
    GetLengthInfo = 0x0007405C
}