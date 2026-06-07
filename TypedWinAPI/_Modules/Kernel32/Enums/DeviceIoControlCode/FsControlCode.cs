namespace TypedWinAPI.Kernel32;

public enum FsControlCode : uint
{
    // Volume Operations
    LockVolume = 0x00090018,
    UnlockVolume = 0x0009001C,
    DismountVolume = 0x00090020,
    IsVolumeMounted = 0x00090028,
    IsVolumeDirty = 0x00090078,
    GetVolumeData = 0x00090064, // Detailed NTFS info
    GetVolumeBitmap = 0x0009006F, // Cluster usage map

    // File & Cluster Operations
    GetRetrievalPointers = 0x00090073, // Physical cluster mapping for a file
    MoveFile = 0x00090074, // Defrag-style move clusters
    SetCompression = 0x0009C010,
    SetEncryption = 0x000900D7,
    SetSparse = 0x000900C4, // Sparse file support
    SetZeroData = 0x000980C8, // Fill file range with zeros
    QueryAllocatedRanges = 0x000940CF,

    // USN Journal (Change Tracking)
    CreateUsnJournal = 0x000900E7,
    QueryUsnJournal = 0x000900F4,
    ReadUsnJournal = 0x000900BB,

    // Transactions & Symlinks
    GetReparsePoint = 0x000900A8, // Read symlink/junction target
    DeleteReparsePoint = 0x000900AC,
    SetReparsePoint = 0x000900A4,

    AllowExtendedDasdIo = 0x00090083  // Raw access beyond valid data length
}