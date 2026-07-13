#nullable enable
// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 20)
]
public unsafe struct DiskFormatParameters
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is DiskFormatParameters other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(DiskFormatParameters other) => this == other;
    public static bool operator ==(DiskFormatParameters a, DiskFormatParameters b)
    {
        if (a.MediaType != b.MediaType)
            return false;
        if (a.StartCylinderNumber != b.StartCylinderNumber)
            return false;
        if (a.EndCylinderNumber != b.EndCylinderNumber)
            return false;
        if (a.StartHeadNumber != b.StartHeadNumber)
            return false;
        if (a.EndHeadNumber != b.EndHeadNumber)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            DiskFormatParameters: {
                MediaType: {{MediaType}}
                StartCylinderNumber: {{StartCylinderNumber}}
                EndCylinderNumber: {{EndCylinderNumber}}
                StartHeadNumber: {{StartHeadNumber}}
                EndHeadNumber: {{EndHeadNumber}}
            }
            """;
    }

    public static bool operator !=(DiskFormatParameters a, DiskFormatParameters b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		MediaType = default;
		StartCylinderNumber = default;
		EndCylinderNumber = default;
		StartHeadNumber = default;
		EndHeadNumber = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type MediaType on offset 0
    /// </summary>
    [FieldOffset(0)] public MediaType MediaType;
    /// <summary>
    /// Field of type uint on offset 4
    /// </summary>
    [FieldOffset(4)] public uint StartCylinderNumber;
    /// <summary>
    /// Field of type uint on offset 8
    /// </summary>
    [FieldOffset(8)] public uint EndCylinderNumber;
    /// <summary>
    /// Field of type uint on offset 12
    /// </summary>
    [FieldOffset(12)] public uint StartHeadNumber;
    /// <summary>
    /// Field of type uint on offset 16
    /// </summary>
    [FieldOffset(16)] public uint EndHeadNumber;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 24)
]
public unsafe struct DiskGeometry
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is DiskGeometry other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(DiskGeometry other) => this == other;
    public static bool operator ==(DiskGeometry a, DiskGeometry b)
    {
        if (a.Cylinders != b.Cylinders)
            return false;
        if (a.MediaType != b.MediaType)
            return false;
        if (a.TracksPerCylinder != b.TracksPerCylinder)
            return false;
        if (a.SectorsPerTrack != b.SectorsPerTrack)
            return false;
        if (a.BytesPerSector != b.BytesPerSector)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            DiskGeometry: {
                Cylinders: {{Cylinders}}
                MediaType: {{MediaType}}
                TracksPerCylinder: {{TracksPerCylinder}}
                SectorsPerTrack: {{SectorsPerTrack}}
                BytesPerSector: {{BytesPerSector}}
            }
            """;
    }

    public static bool operator !=(DiskGeometry a, DiskGeometry b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		Cylinders = default;
		MediaType = default;
		TracksPerCylinder = default;
		SectorsPerTrack = default;
		BytesPerSector = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type long on offset 0
    /// </summary>
    [FieldOffset(0)] public long Cylinders;
    /// <summary>
    /// Field of type MediaType on offset 8
    /// </summary>
    [FieldOffset(8)] public MediaType MediaType;
    /// <summary>
    /// Field of type uint on offset 12
    /// </summary>
    [FieldOffset(12)] public uint TracksPerCylinder;
    /// <summary>
    /// Field of type uint on offset 16
    /// </summary>
    [FieldOffset(16)] public uint SectorsPerTrack;
    /// <summary>
    /// Field of type uint on offset 20
    /// </summary>
    [FieldOffset(20)] public uint BytesPerSector;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 32)
]
public unsafe struct DiskGeometryEx
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is DiskGeometryEx other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(DiskGeometryEx other) => this == other;
    public static bool operator ==(DiskGeometryEx a, DiskGeometryEx b)
    {
        if (a.Geometry != b.Geometry)
            return false;
        if (a.DiskSize != b.DiskSize)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            DiskGeometryEx: {
                Geometry: {{Geometry}}
                DiskSize: {{DiskSize}}
            }
            """;
    }

    public static bool operator !=(DiskGeometryEx a, DiskGeometryEx b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		Geometry = default;
		DiskSize = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type DiskGeometry on offset 0
    /// </summary>
    [FieldOffset(0)] public DiskGeometry Geometry;
    /// <summary>
    /// Field of type long on offset 24
    /// </summary>
    [FieldOffset(24)] public long DiskSize;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 16)
]
public unsafe struct FsFileZeroDataInformation
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is FsFileZeroDataInformation other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(FsFileZeroDataInformation other) => this == other;
    public static bool operator ==(FsFileZeroDataInformation a, FsFileZeroDataInformation b)
    {
        if (a.FileOffset != b.FileOffset)
            return false;
        if (a.BeyondFinalZero != b.BeyondFinalZero)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            FsFileZeroDataInformation: {
                FileOffset: {{FileOffset}}
                BeyondFinalZero: {{BeyondFinalZero}}
            }
            """;
    }

    public static bool operator !=(FsFileZeroDataInformation a, FsFileZeroDataInformation b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		FileOffset = default;
		BeyondFinalZero = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type long on offset 0
    /// </summary>
    [FieldOffset(0)] public long FileOffset;
    /// <summary>
    /// Field of type long on offset 8
    /// </summary>
    [FieldOffset(8)] public long BeyondFinalZero;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 32)
]
public unsafe struct FsMoveFileParams
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is FsMoveFileParams other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(FsMoveFileParams other) => this == other;
    public static bool operator ==(FsMoveFileParams a, FsMoveFileParams b)
    {
        if (a.FileHandle != b.FileHandle)
            return false;
        if (a.StartingVcn != b.StartingVcn)
            return false;
        if (a.StartingLcn != b.StartingLcn)
            return false;
        if (a.ClusterCount != b.ClusterCount)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            FsMoveFileParams: {
                FileHandle: {{(nuint)FileHandle:X16}}
                StartingVcn: {{StartingVcn}}
                StartingLcn: {{StartingLcn}}
                ClusterCount: {{ClusterCount}}
            }
            """;
    }

    public static bool operator !=(FsMoveFileParams a, FsMoveFileParams b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		FileHandle = default;
		StartingVcn = default;
		StartingLcn = default;
		ClusterCount = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type void* on offset 0
    /// </summary>
    [FieldOffset(0)] public void* FileHandle;
    /// <summary>
    /// Field of type long on offset 8
    /// </summary>
    [FieldOffset(8)] public long StartingVcn;
    /// <summary>
    /// Field of type long on offset 16
    /// </summary>
    [FieldOffset(16)] public long StartingLcn;
    /// <summary>
    /// Field of type uint on offset 24
    /// </summary>
    [FieldOffset(24)] public uint ClusterCount;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 16)
]
public unsafe struct FsReparseDataBuffer
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is FsReparseDataBuffer other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(FsReparseDataBuffer other) => this == other;
    public static bool operator ==(FsReparseDataBuffer a, FsReparseDataBuffer b)
    {
        if (a.Header != b.Header)
            return false;
        if (a.SymlinkSubstituteNameOffset != b.SymlinkSubstituteNameOffset)
            return false;
        if (a.SymlinkSubstituteNameLength != b.SymlinkSubstituteNameLength)
            return false;
        if (a.SymlinkPrintNameOffset != b.SymlinkPrintNameOffset)
            return false;
        if (a.SymlinkPrintNameLength != b.SymlinkPrintNameLength)
            return false;
        if (a.SymlinkFlags != b.SymlinkFlags)
            return false;
        if (a.MountPointSubstituteNameOffset != b.MountPointSubstituteNameOffset)
            return false;
        if (a.MountPointSubstituteNameLength != b.MountPointSubstituteNameLength)
            return false;
        if (a.MountPointPrintNameOffset != b.MountPointPrintNameOffset)
            return false;
        if (a.MountPointPrintNameLength != b.MountPointPrintNameLength)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
		return Header.ToString();
    }

    public static bool operator !=(FsReparseDataBuffer a, FsReparseDataBuffer b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		Header = default;
		SymlinkSubstituteNameOffset = default;
		SymlinkSubstituteNameLength = default;
		SymlinkPrintNameOffset = default;
		SymlinkPrintNameLength = default;
		SymlinkFlags = default;
		MountPointSubstituteNameOffset = default;
		MountPointSubstituteNameLength = default;
		MountPointPrintNameOffset = default;
		MountPointPrintNameLength = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type FsReparseDataBufferHeader on offset 0
    /// </summary>
    [FieldOffset(0)] public FsReparseDataBufferHeader Header;
    /// <summary>
    /// Field of type ushort on offset 8
    /// </summary>
    [FieldOffset(8)] public ushort SymlinkSubstituteNameOffset;
    /// <summary>
    /// Field of type ushort on offset 10
    /// </summary>
    [FieldOffset(10)] public ushort SymlinkSubstituteNameLength;
    /// <summary>
    /// Field of type ushort on offset 12
    /// </summary>
    [FieldOffset(12)] public ushort SymlinkPrintNameOffset;
    /// <summary>
    /// Field of type ushort on offset 14
    /// </summary>
    [FieldOffset(14)] public ushort SymlinkPrintNameLength;
    /// <summary>
    /// Field of type uint on offset 16
    /// </summary>
    [FieldOffset(16)] public uint SymlinkFlags;
    /// <summary>
    /// Field of type ushort on offset 8
    /// </summary>
    [FieldOffset(8)] public ushort MountPointSubstituteNameOffset;
    /// <summary>
    /// Field of type ushort on offset 10
    /// </summary>
    [FieldOffset(10)] public ushort MountPointSubstituteNameLength;
    /// <summary>
    /// Field of type ushort on offset 12
    /// </summary>
    [FieldOffset(12)] public ushort MountPointPrintNameOffset;
    /// <summary>
    /// Field of type ushort on offset 14
    /// </summary>
    [FieldOffset(14)] public ushort MountPointPrintNameLength;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 8)
]
public unsafe struct FsReparseDataBufferHeader
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is FsReparseDataBufferHeader other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(FsReparseDataBufferHeader other) => this == other;
    public static bool operator ==(FsReparseDataBufferHeader a, FsReparseDataBufferHeader b)
    {
        if (a.ReparseTag != b.ReparseTag)
            return false;
        if (a.ReparseDataLength != b.ReparseDataLength)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
		return $"ReparseTag: 0x{ReparseTag:X8}\r\nReparseDataLength: {ReparseDataLength}";
    }

    public static bool operator !=(FsReparseDataBufferHeader a, FsReparseDataBufferHeader b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		ReparseTag = default;
		ReparseDataLength = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type FsReparseTag on offset 0
    /// </summary>
    [FieldOffset(0)] public FsReparseTag ReparseTag;
    /// <summary>
    /// Field of type ushort on offset 4
    /// </summary>
    [FieldOffset(4)] public ushort ReparseDataLength;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 24)
]
public unsafe struct MountMgrMountPoint
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is MountMgrMountPoint other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(MountMgrMountPoint other) => this == other;
    public static bool operator ==(MountMgrMountPoint a, MountMgrMountPoint b)
    {
        if (a.SymbolicLinkNameOffset != b.SymbolicLinkNameOffset)
            return false;
        if (a.SymbolicLinkNameLength != b.SymbolicLinkNameLength)
            return false;
        if (a.UniqueIdOffset != b.UniqueIdOffset)
            return false;
        if (a.UniqueIdLength != b.UniqueIdLength)
            return false;
        if (a.DeviceNameOffset != b.DeviceNameOffset)
            return false;
        if (a.DeviceNameLength != b.DeviceNameLength)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
		return
		    $"""
		    SymbolicLinkName: {SymbolicLinkNameLength} at {SymbolicLinkNameOffset}
		    UniqueId: {UniqueIdLength} at {UniqueIdOffset}
		    DeviceName: {DeviceNameLength} at {DeviceNameOffset}
		    """;
    }

    public static bool operator !=(MountMgrMountPoint a, MountMgrMountPoint b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		SymbolicLinkNameOffset = default;
		SymbolicLinkNameLength = default;
		UniqueIdOffset = default;
		UniqueIdLength = default;
		DeviceNameOffset = default;
		DeviceNameLength = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type uint on offset 0
    /// </summary>
    [FieldOffset(0)] public uint SymbolicLinkNameOffset;
    /// <summary>
    /// Field of type ushort on offset 4
    /// </summary>
    [FieldOffset(4)] public ushort SymbolicLinkNameLength;
    /// <summary>
    /// Field of type uint on offset 8
    /// </summary>
    [FieldOffset(8)] public uint UniqueIdOffset;
    /// <summary>
    /// Field of type ushort on offset 12
    /// </summary>
    [FieldOffset(12)] public ushort UniqueIdLength;
    /// <summary>
    /// Field of type uint on offset 16
    /// </summary>
    [FieldOffset(16)] public uint DeviceNameOffset;
    /// <summary>
    /// Field of type ushort on offset 20
    /// </summary>
    [FieldOffset(20)] public ushort DeviceNameLength;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 32)
]
public unsafe struct PartitionInformation
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is PartitionInformation other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PartitionInformation other) => this == other;
    public static bool operator ==(PartitionInformation a, PartitionInformation b)
    {
        if (a.StartingOffset != b.StartingOffset)
            return false;
        if (a.PartitionLength != b.PartitionLength)
            return false;
        if (a.HiddenSectors != b.HiddenSectors)
            return false;
        if (a.PartitionNumber != b.PartitionNumber)
            return false;
        if (a.PartitionType != b.PartitionType)
            return false;
        if (a.BootIndicator != b.BootIndicator)
            return false;
        if (a.RecognizedPartition != b.RecognizedPartition)
            return false;
        if (a.RewritePartition != b.RewritePartition)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            PartitionInformation: {
                StartingOffset: {{StartingOffset}}
                PartitionLength: {{PartitionLength}}
                HiddenSectors: {{HiddenSectors}}
                PartitionNumber: {{PartitionNumber}}
                PartitionType: {{PartitionType}}
                BootIndicator: {{BootIndicator}}
                RecognizedPartition: {{RecognizedPartition}}
                RewritePartition: {{RewritePartition}}
            }
            """;
    }

    public static bool operator !=(PartitionInformation a, PartitionInformation b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		StartingOffset = default;
		PartitionLength = default;
		HiddenSectors = default;
		PartitionNumber = default;
		PartitionType = default;
		BootIndicator = default;
		RecognizedPartition = default;
		RewritePartition = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type long on offset 0
    /// </summary>
    [FieldOffset(0)] public long StartingOffset;
    /// <summary>
    /// Field of type long on offset 8
    /// </summary>
    [FieldOffset(8)] public long PartitionLength;
    /// <summary>
    /// Field of type uint on offset 16
    /// </summary>
    [FieldOffset(16)] public uint HiddenSectors;
    /// <summary>
    /// Field of type uint on offset 20
    /// </summary>
    [FieldOffset(20)] public uint PartitionNumber;
    /// <summary>
    /// Field of type PartitionType on offset 24
    /// </summary>
    [FieldOffset(24)] public PartitionType PartitionType;
    /// <summary>
    /// Field of type Bool1 on offset 25
    /// </summary>
    [FieldOffset(25)] public Bool1 BootIndicator;
    /// <summary>
    /// Field of type Bool1 on offset 26
    /// </summary>
    [FieldOffset(26)] public Bool1 RecognizedPartition;
    /// <summary>
    /// Field of type Bool1 on offset 27
    /// </summary>
    [FieldOffset(27)] public Bool1 RewritePartition;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 12)
]
public unsafe struct StorageDeviceNumber
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is StorageDeviceNumber other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(StorageDeviceNumber other) => this == other;
    public static bool operator ==(StorageDeviceNumber a, StorageDeviceNumber b)
    {
        if (a.DeviceType != b.DeviceType)
            return false;
        if (a.DeviceNumber != b.DeviceNumber)
            return false;
        if (a.PartitionNumber != b.PartitionNumber)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            StorageDeviceNumber: {
                DeviceType: {{DeviceType}}
                DeviceNumber: {{DeviceNumber}}
                PartitionNumber: {{PartitionNumber}}
            }
            """;
    }

    public static bool operator !=(StorageDeviceNumber a, StorageDeviceNumber b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		DeviceType = default;
		DeviceNumber = default;
		PartitionNumber = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type DeviceType on offset 0
    /// </summary>
    [FieldOffset(0)] public DeviceType DeviceType;
    /// <summary>
    /// Field of type uint on offset 4
    /// </summary>
    [FieldOffset(4)] public uint DeviceNumber;
    /// <summary>
    /// Field of type uint on offset 8
    /// </summary>
    [FieldOffset(8)] public uint PartitionNumber;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 8)
]
public unsafe struct StorageHotplugInfo()
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is StorageHotplugInfo other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(StorageHotplugInfo other) => this == other;
    public static bool operator ==(StorageHotplugInfo a, StorageHotplugInfo b)
    {
        if (a.Size != b.Size)
            return false;
        if (a.MediaRemovable != b.MediaRemovable)
            return false;
        if (a.MediaHotplug != b.MediaHotplug)
            return false;
        if (a.DeviceHotplug != b.DeviceHotplug)
            return false;
        if (a.WriteCacheEnableOverride != b.WriteCacheEnableOverride)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            StorageHotplugInfo: {
                Size: {{Size}}
                MediaRemovable: {{MediaRemovable}}
                MediaHotplug: {{MediaHotplug}}
                DeviceHotplug: {{DeviceHotplug}}
                WriteCacheEnableOverride: {{WriteCacheEnableOverride}}
            }
            """;
    }

    public static bool operator !=(StorageHotplugInfo a, StorageHotplugInfo b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		Size = 8;
		MediaRemovable = default;
		MediaHotplug = default;
		DeviceHotplug = default;
		WriteCacheEnableOverride = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type uint on offset 0
    /// </summary>
    [FieldOffset(0)] public uint Size = 8;
    /// <summary>
    /// Field of type Bool1 on offset 4
    /// </summary>
    [FieldOffset(4)] public Bool1 MediaRemovable;
    /// <summary>
    /// Field of type Bool1 on offset 5
    /// </summary>
    [FieldOffset(5)] public Bool1 MediaHotplug;
    /// <summary>
    /// Field of type Bool1 on offset 6
    /// </summary>
    [FieldOffset(6)] public Bool1 DeviceHotplug;
    /// <summary>
    /// Field of type Bool1 on offset 7
    /// </summary>
    [FieldOffset(7)] public Bool1 WriteCacheEnableOverride;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 12)
]
public unsafe struct StoragePropertyQuery
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is StoragePropertyQuery other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(StoragePropertyQuery other) => this == other;
    public static bool operator ==(StoragePropertyQuery a, StoragePropertyQuery b)
    {
        if (a.PropertyId != b.PropertyId)
            return false;
        if (a.QueryType != b.QueryType)
            return false;
        if (a.AdditionalParameters != b.AdditionalParameters)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            StoragePropertyQuery: {
                PropertyId: {{PropertyId}}
                QueryType: {{QueryType}}
                AdditionalParameters: {{AdditionalParameters}}
            }
            """;
    }

    public static bool operator !=(StoragePropertyQuery a, StoragePropertyQuery b)
    {
        return !(a == b);
    }

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsReadOnlySpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));
    }

    #endregion
    #region IStructContracts

    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan()
    {
        return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));
    }

    public void Clear()
    {
		PropertyId = default;
		QueryType = default;
		AdditionalParameters = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type StoragePropertyId on offset 0
    /// </summary>
    [FieldOffset(0)] public StoragePropertyId PropertyId;
    /// <summary>
    /// Field of type StorageQueryType on offset 4
    /// </summary>
    [FieldOffset(4)] public StorageQueryType QueryType;
    /// <summary>
    /// Field of type byte on offset 8
    /// </summary>
    [FieldOffset(8)] public byte AdditionalParameters;

    #endregion
}
#nullable restore