#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.Kernel32;

/// <summary>
/// Blittable (unmanaged) small struct with size 20. Abstraction over Win32 DiskFormatParameters
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 20)]
public unsafe partial struct DiskFormatParameters :
	IEqualityOperators<DiskFormatParameters, DiskFormatParameters, bool>, IEquatable<DiskFormatParameters>
{
	#region Construct

	public DiskFormatParameters(
MediaType MediaType,
uint StartCylinderNumber,
uint EndCylinderNumber,
uint StartHeadNumber,
uint EndHeadNumber
	)
	{
		this.MediaType = MediaType;

		this.StartCylinderNumber = StartCylinderNumber;

		this.EndCylinderNumber = EndCylinderNumber;

		this.StartHeadNumber = StartHeadNumber;

		this.EndHeadNumber = EndHeadNumber;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public MediaType MediaType;

	[FieldOffset(4)] public uint StartCylinderNumber;

	[FieldOffset(8)] public uint EndCylinderNumber;

	[FieldOffset(12)] public uint StartHeadNumber;

	[FieldOffset(16)] public uint EndHeadNumber;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is DiskFormatParameters other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(DiskFormatParameters other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(DiskFormatParameters a, DiskFormatParameters b)
	{
		return
		a.MediaType == b.MediaType &&

		a.StartCylinderNumber == b.StartCylinderNumber &&

		a.EndCylinderNumber == b.EndCylinderNumber &&

		a.StartHeadNumber == b.StartHeadNumber &&

		a.EndHeadNumber == b.EndHeadNumber
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(DiskFormatParameters a, DiskFormatParameters b)
	{
		return
		!(a.MediaType == b.MediaType) ||

		!(a.StartCylinderNumber == b.StartCylinderNumber) ||

		!(a.EndCylinderNumber == b.EndCylinderNumber) ||

		!(a.StartHeadNumber == b.StartHeadNumber) ||

		!(a.EndHeadNumber == b.EndHeadNumber)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	DiskFormatParameters
	{
		MediaType: {{MediaType}},

		StartCylinderNumber: {{StartCylinderNumber}},

		EndCylinderNumber: {{EndCylinderNumber}},

		StartHeadNumber: {{StartHeadNumber}},

		EndHeadNumber: {{EndHeadNumber}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 24. Abstraction over Win32 DiskGeometry
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 24)]
public unsafe partial struct DiskGeometry :
	IEqualityOperators<DiskGeometry, DiskGeometry, bool>, IEquatable<DiskGeometry>
{
	#region Construct

	public DiskGeometry(
long Cylinders,
MediaType MediaType,
uint TracksPerCylinder,
uint SectorsPerTrack,
uint BytesPerSector
	)
	{
		this.Cylinders = Cylinders;

		this.MediaType = MediaType;

		this.TracksPerCylinder = TracksPerCylinder;

		this.SectorsPerTrack = SectorsPerTrack;

		this.BytesPerSector = BytesPerSector;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public long Cylinders;

	[FieldOffset(8)] public MediaType MediaType;

	[FieldOffset(12)] public uint TracksPerCylinder;

	[FieldOffset(16)] public uint SectorsPerTrack;

	[FieldOffset(20)] public uint BytesPerSector;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is DiskGeometry other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(DiskGeometry other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(DiskGeometry a, DiskGeometry b)
	{
		return
		a.Cylinders == b.Cylinders &&

		a.MediaType == b.MediaType &&

		a.TracksPerCylinder == b.TracksPerCylinder &&

		a.SectorsPerTrack == b.SectorsPerTrack &&

		a.BytesPerSector == b.BytesPerSector
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(DiskGeometry a, DiskGeometry b)
	{
		return
		!(a.Cylinders == b.Cylinders) ||

		!(a.MediaType == b.MediaType) ||

		!(a.TracksPerCylinder == b.TracksPerCylinder) ||

		!(a.SectorsPerTrack == b.SectorsPerTrack) ||

		!(a.BytesPerSector == b.BytesPerSector)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	DiskGeometry
	{
		Cylinders: {{Cylinders}},

		MediaType: {{MediaType}},

		TracksPerCylinder: {{TracksPerCylinder}},

		SectorsPerTrack: {{SectorsPerTrack}},

		BytesPerSector: {{BytesPerSector}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 32. Abstraction over Win32 DiskGeometryEx
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 32)]
public unsafe partial struct DiskGeometryEx :
	IEqualityOperators<DiskGeometryEx, DiskGeometryEx, bool>, IEquatable<DiskGeometryEx>
{
	#region Construct

	public DiskGeometryEx(
DiskGeometry Geometry,
long DiskSize
	)
	{
		this.Geometry = Geometry;

		this.DiskSize = DiskSize;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public DiskGeometry Geometry;

	[FieldOffset(24)] public long DiskSize;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is DiskGeometryEx other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(DiskGeometryEx other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(DiskGeometryEx a, DiskGeometryEx b)
	{
		return
		a.Geometry == b.Geometry &&

		a.DiskSize == b.DiskSize
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(DiskGeometryEx a, DiskGeometryEx b)
	{
		return
		!(a.Geometry == b.Geometry) ||

		!(a.DiskSize == b.DiskSize)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	DiskGeometryEx
	{
		Geometry: {{Geometry}},

		DiskSize: {{DiskSize}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 16. Abstraction over Win32 FsFileZeroDataInformation
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 16)]
public unsafe partial struct FsFileZeroDataInformation :
	IEqualityOperators<FsFileZeroDataInformation, FsFileZeroDataInformation, bool>, IEquatable<FsFileZeroDataInformation>
{
	#region Construct

	public FsFileZeroDataInformation(
long FileOffset,
long BeyondFinalZero
	)
	{
		this.FileOffset = FileOffset;

		this.BeyondFinalZero = BeyondFinalZero;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public long FileOffset;

	[FieldOffset(8)] public long BeyondFinalZero;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is FsFileZeroDataInformation other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(FsFileZeroDataInformation other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(FsFileZeroDataInformation a, FsFileZeroDataInformation b)
	{
		return
		a.FileOffset == b.FileOffset &&

		a.BeyondFinalZero == b.BeyondFinalZero
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(FsFileZeroDataInformation a, FsFileZeroDataInformation b)
	{
		return
		!(a.FileOffset == b.FileOffset) ||

		!(a.BeyondFinalZero == b.BeyondFinalZero)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	FsFileZeroDataInformation
	{
		FileOffset: {{FileOffset}},

		BeyondFinalZero: {{BeyondFinalZero}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 32. Abstraction over Win32 FsMoveFileParams
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 32)]
public unsafe partial struct FsMoveFileParams :
	IEqualityOperators<FsMoveFileParams, FsMoveFileParams, bool>, IEquatable<FsMoveFileParams>
{
	#region Construct

	public FsMoveFileParams(
Handle FileHandle,
long StartingVcn,
long StartingLcn,
uint ClusterCount
	)
	{
		this.FileHandle = FileHandle;

		this.StartingVcn = StartingVcn;

		this.StartingLcn = StartingLcn;

		this.ClusterCount = ClusterCount;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public Handle FileHandle;

	[FieldOffset(8)] public long StartingVcn;

	[FieldOffset(16)] public long StartingLcn;

	[FieldOffset(24)] public uint ClusterCount;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is FsMoveFileParams other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(FsMoveFileParams other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(FsMoveFileParams a, FsMoveFileParams b)
	{
		return
		a.FileHandle == b.FileHandle &&

		a.StartingVcn == b.StartingVcn &&

		a.StartingLcn == b.StartingLcn &&

		a.ClusterCount == b.ClusterCount
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(FsMoveFileParams a, FsMoveFileParams b)
	{
		return
		!(a.FileHandle == b.FileHandle) ||

		!(a.StartingVcn == b.StartingVcn) ||

		!(a.StartingLcn == b.StartingLcn) ||

		!(a.ClusterCount == b.ClusterCount)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	FsMoveFileParams
	{
		FileHandle: {{FileHandle}},

		StartingVcn: {{StartingVcn}},

		StartingLcn: {{StartingLcn}},

		ClusterCount: {{ClusterCount}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 24. Abstraction over Win32 FsReparseDataBuffer
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 24)]
public unsafe partial struct FsReparseDataBuffer :
	IEqualityOperators<FsReparseDataBuffer, FsReparseDataBuffer, bool>, IEquatable<FsReparseDataBuffer>
{

	#region Fields

	[FieldOffset(0)] public FsReparseDataBufferHeader Header;

	[FieldOffset(8)] public ushort SymlinkSubstituteNameOffset;

	[FieldOffset(10)] public ushort SymlinkSubstituteNameLength;

	[FieldOffset(12)] public ushort SymlinkPrintNameOffset;

	[FieldOffset(14)] public ushort SymlinkPrintNameLength;

	[FieldOffset(16)] public uint SymlinkFlags;

	[FieldOffset(8)] public ushort MountPointSubstituteNameOffset;

	[FieldOffset(10)] public ushort MountPointSubstituteNameLength;

	[FieldOffset(12)] public ushort MountPointPrintNameOffset;

	[FieldOffset(14)] public ushort MountPointPrintNameLength;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is FsReparseDataBuffer other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(FsReparseDataBuffer other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(FsReparseDataBuffer a, FsReparseDataBuffer b)
	{
		return
		a.Header == b.Header &&

		a.SymlinkSubstituteNameOffset == b.SymlinkSubstituteNameOffset &&

		a.SymlinkSubstituteNameLength == b.SymlinkSubstituteNameLength &&

		a.SymlinkPrintNameOffset == b.SymlinkPrintNameOffset &&

		a.SymlinkPrintNameLength == b.SymlinkPrintNameLength &&

		a.SymlinkFlags == b.SymlinkFlags
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(FsReparseDataBuffer a, FsReparseDataBuffer b)
	{
		return
		!(a.Header == b.Header) ||

		!(a.SymlinkSubstituteNameOffset == b.SymlinkSubstituteNameOffset) ||

		!(a.SymlinkSubstituteNameLength == b.SymlinkSubstituteNameLength) ||

		!(a.SymlinkPrintNameOffset == b.SymlinkPrintNameOffset) ||

		!(a.SymlinkPrintNameLength == b.SymlinkPrintNameLength) ||

		!(a.SymlinkFlags == b.SymlinkFlags)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	FsReparseDataBuffer
	{
		Header: {{Header}},

		SymlinkSubstituteNameOffset: {{SymlinkSubstituteNameOffset}},

		SymlinkSubstituteNameLength: {{SymlinkSubstituteNameLength}},

		SymlinkPrintNameOffset: {{SymlinkPrintNameOffset}},

		SymlinkPrintNameLength: {{SymlinkPrintNameLength}},

		SymlinkFlags: {{SymlinkFlags}},

		MountPointSubstituteNameOffset: {{MountPointSubstituteNameOffset}},

		MountPointSubstituteNameLength: {{MountPointSubstituteNameLength}},

		MountPointPrintNameOffset: {{MountPointPrintNameOffset}},

		MountPointPrintNameLength: {{MountPointPrintNameLength}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 24. Abstraction over Win32 MountMgrMountPoint
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 24)]
public unsafe partial struct MountMgrMountPoint :
	IEqualityOperators<MountMgrMountPoint, MountMgrMountPoint, bool>, IEquatable<MountMgrMountPoint>
{
	#region Construct

	public MountMgrMountPoint(
uint SymbolicLinkNameOffset,
uint SymbolicLinkNameLength,
uint UniqueIdOffset,
uint UniqueIdLength,
uint DeviceNameOffset,
ushort DeviceNameLength
	)
	{
		this.SymbolicLinkNameOffset = SymbolicLinkNameOffset;

		this.SymbolicLinkNameLength = SymbolicLinkNameLength;

		this.UniqueIdOffset = UniqueIdOffset;

		this.UniqueIdLength = UniqueIdLength;

		this.DeviceNameOffset = DeviceNameOffset;

		this.DeviceNameLength = DeviceNameLength;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public uint SymbolicLinkNameOffset;

	[FieldOffset(4)] public uint SymbolicLinkNameLength;

	[FieldOffset(8)] public uint UniqueIdOffset;

	[FieldOffset(12)] public uint UniqueIdLength;

	[FieldOffset(16)] public uint DeviceNameOffset;

	[FieldOffset(20)] public ushort DeviceNameLength;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is MountMgrMountPoint other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(MountMgrMountPoint other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(MountMgrMountPoint a, MountMgrMountPoint b)
	{
		return
		a.SymbolicLinkNameOffset == b.SymbolicLinkNameOffset &&

		a.SymbolicLinkNameLength == b.SymbolicLinkNameLength &&

		a.UniqueIdOffset == b.UniqueIdOffset &&

		a.UniqueIdLength == b.UniqueIdLength &&

		a.DeviceNameOffset == b.DeviceNameOffset &&

		a.DeviceNameLength == b.DeviceNameLength
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(MountMgrMountPoint a, MountMgrMountPoint b)
	{
		return
		!(a.SymbolicLinkNameOffset == b.SymbolicLinkNameOffset) ||

		!(a.SymbolicLinkNameLength == b.SymbolicLinkNameLength) ||

		!(a.UniqueIdOffset == b.UniqueIdOffset) ||

		!(a.UniqueIdLength == b.UniqueIdLength) ||

		!(a.DeviceNameOffset == b.DeviceNameOffset) ||

		!(a.DeviceNameLength == b.DeviceNameLength)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	MountMgrMountPoint
	{
		SymbolicLinkNameOffset: {{SymbolicLinkNameOffset}},

		SymbolicLinkNameLength: {{SymbolicLinkNameLength}},

		UniqueIdOffset: {{UniqueIdOffset}},

		UniqueIdLength: {{UniqueIdLength}},

		DeviceNameOffset: {{DeviceNameOffset}},

		DeviceNameLength: {{DeviceNameLength}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 32. Abstraction over Win32 PartitionInformation
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 32)]
public unsafe partial struct PartitionInformation :
	IEqualityOperators<PartitionInformation, PartitionInformation, bool>, IEquatable<PartitionInformation>
{
	#region Construct

	public PartitionInformation(
long StartingOffset,
long PartitionLength,
uint HiddenSectors,
uint PartitionNumber,
PartitionType PartitionType,
Bool1 BootIndicator,
Bool1 RecognizedPartition,
Bool1 RewritePartition
	)
	{
		this.StartingOffset = StartingOffset;

		this.PartitionLength = PartitionLength;

		this.HiddenSectors = HiddenSectors;

		this.PartitionNumber = PartitionNumber;

		this.PartitionType = PartitionType;

		this.BootIndicator = BootIndicator;

		this.RecognizedPartition = RecognizedPartition;

		this.RewritePartition = RewritePartition;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public long StartingOffset;

	[FieldOffset(8)] public long PartitionLength;

	[FieldOffset(16)] public uint HiddenSectors;

	[FieldOffset(20)] public uint PartitionNumber;

	[FieldOffset(24)] public PartitionType PartitionType;

	[FieldOffset(25)] public Bool1 BootIndicator;

	[FieldOffset(26)] public Bool1 RecognizedPartition;

	[FieldOffset(27)] public Bool1 RewritePartition;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is PartitionInformation other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(PartitionInformation other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(PartitionInformation a, PartitionInformation b)
	{
		return
		a.StartingOffset == b.StartingOffset &&

		a.PartitionLength == b.PartitionLength &&

		a.HiddenSectors == b.HiddenSectors &&

		a.PartitionNumber == b.PartitionNumber &&

		a.PartitionType == b.PartitionType &&

		a.BootIndicator == b.BootIndicator &&

		a.RecognizedPartition == b.RecognizedPartition &&

		a.RewritePartition == b.RewritePartition
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(PartitionInformation a, PartitionInformation b)
	{
		return
		!(a.StartingOffset == b.StartingOffset) ||

		!(a.PartitionLength == b.PartitionLength) ||

		!(a.HiddenSectors == b.HiddenSectors) ||

		!(a.PartitionNumber == b.PartitionNumber) ||

		!(a.PartitionType == b.PartitionType) ||

		!(a.BootIndicator == b.BootIndicator) ||

		!(a.RecognizedPartition == b.RecognizedPartition) ||

		!(a.RewritePartition == b.RewritePartition)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	PartitionInformation
	{
		StartingOffset: {{StartingOffset}},

		PartitionLength: {{PartitionLength}},

		HiddenSectors: {{HiddenSectors}},

		PartitionNumber: {{PartitionNumber}},

		PartitionType: {{PartitionType}},

		BootIndicator: {{BootIndicator}},

		RecognizedPartition: {{RecognizedPartition}},

		RewritePartition: {{RewritePartition}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 12. Abstraction over Win32 StorageDeviceNumber
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 12)]
public unsafe partial struct StorageDeviceNumber :
	IEqualityOperators<StorageDeviceNumber, StorageDeviceNumber, bool>, IEquatable<StorageDeviceNumber>
{
	#region Construct

	public StorageDeviceNumber(
DeviceType DeviceType,
uint DeviceNumber,
uint PartitionNumber
	)
	{
		this.DeviceType = DeviceType;

		this.DeviceNumber = DeviceNumber;

		this.PartitionNumber = PartitionNumber;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public DeviceType DeviceType;

	[FieldOffset(4)] public uint DeviceNumber;

	[FieldOffset(8)] public uint PartitionNumber;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is StorageDeviceNumber other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(StorageDeviceNumber other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(StorageDeviceNumber a, StorageDeviceNumber b)
	{
		return
		a.DeviceType == b.DeviceType &&

		a.DeviceNumber == b.DeviceNumber &&

		a.PartitionNumber == b.PartitionNumber
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(StorageDeviceNumber a, StorageDeviceNumber b)
	{
		return
		!(a.DeviceType == b.DeviceType) ||

		!(a.DeviceNumber == b.DeviceNumber) ||

		!(a.PartitionNumber == b.PartitionNumber)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	StorageDeviceNumber
	{
		DeviceType: {{DeviceType}},

		DeviceNumber: {{DeviceNumber}},

		PartitionNumber: {{PartitionNumber}}
	}
	""";

	#endregion
#endif
}
/// <summary>
/// Blittable (unmanaged) small struct with size 12. Abstraction over Win32 StoragePropertyQuery
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 12)]
public unsafe partial struct StoragePropertyQuery :
	IEqualityOperators<StoragePropertyQuery, StoragePropertyQuery, bool>, IEquatable<StoragePropertyQuery>
{
	#region Construct

	public StoragePropertyQuery(
StoragePropertyId PropertyId,
StorageQueryType QueryType,
byte AdditionalParameters
	)
	{
		this.PropertyId = PropertyId;

		this.QueryType = QueryType;

		this.AdditionalParameters = AdditionalParameters;

	}

	#endregion

	#region Fields

	[FieldOffset(0)] public StoragePropertyId PropertyId;

	[FieldOffset(4)] public StorageQueryType QueryType;

	[FieldOffset(8)] public byte AdditionalParameters;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals(object? obj) => obj is StoragePropertyQuery other ? Equals(other) : false;
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(StoragePropertyQuery other) => this == other;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(StoragePropertyQuery a, StoragePropertyQuery b)
	{
		return
		a.PropertyId == b.PropertyId &&

		a.QueryType == b.QueryType &&

		a.AdditionalParameters == b.AdditionalParameters
;
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(StoragePropertyQuery a, StoragePropertyQuery b)
	{
		return
		!(a.PropertyId == b.PropertyId) ||

		!(a.QueryType == b.QueryType) ||

		!(a.AdditionalParameters == b.AdditionalParameters)
;
	}

	#endregion
#if ManagedStrings
	#region Format And Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override string ToString() =>
	$$"""
	StoragePropertyQuery
	{
		PropertyId: {{PropertyId}},

		QueryType: {{QueryType}},

		AdditionalParameters: {{AdditionalParameters}}
	}
	""";

	#endregion
#endif
}
#nullable restore

