#nullable enable
// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypedWinAPI.Contracts;
using TypedWinAPI.Contracts.Struct;
using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.Kernel32;

/// <summary>
/// Mapped from VIDEO_MODE_INFORMATION (WDK).
/// This is the standard return structure for video query IOCTLs.
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 48)
]
public unsafe struct VideoModeInformation()  :
    IStructContracts<VideoModeInformation>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is VideoModeInformation other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(VideoModeInformation other) => this == other;
    public static bool operator ==(VideoModeInformation a, VideoModeInformation b)
    {
        if (a.Length != b.Length)
            return false;
        if (a.ModeIndex != b.ModeIndex)
            return false;
        if (a.VisScreenWidth != b.VisScreenWidth)
            return false;
        if (a.VisScreenHeight != b.VisScreenHeight)
            return false;
        if (a.BitsPerPlane != b.BitsPerPlane)
            return false;
        if (a.NumberOfPlanes != b.NumberOfPlanes)
            return false;
        if (a.Frequency != b.Frequency)
            return false;
        if (a.XMillimeter != b.XMillimeter)
            return false;
        if (a.YMillimeter != b.YMillimeter)
            return false;
        if (a.NumberOfButtons != b.NumberOfButtons)
            return false;
        if (a.NumberOfPointerButtons != b.NumberOfPointerButtons)
            return false;
        if (a.Interlaced != b.Interlaced)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
		return $"Res: {VisScreenWidth}x{VisScreenHeight} @ {Frequency}Hz";
    }

    public static bool operator !=(VideoModeInformation a, VideoModeInformation b)
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
		Length = 48;
		ModeIndex = default;
		VisScreenWidth = default;
		VisScreenHeight = default;
		BitsPerPlane = default;
		NumberOfPlanes = default;
		Frequency = default;
		XMillimeter = default;
		YMillimeter = default;
		NumberOfButtons = default;
		NumberOfPointerButtons = default;
		Interlaced = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type uint on offset 0
    /// </summary>
    [FieldOffset(0)] public uint Length = 48;
    /// <summary>
    /// Field of type VideoDisplayMode on offset 4
    /// </summary>
    [FieldOffset(4)] public VideoDisplayMode ModeIndex;
    /// <summary>
    /// Field of type uint on offset 8
    /// </summary>
    [FieldOffset(8)] public uint VisScreenWidth;
    /// <summary>
    /// Field of type uint on offset 12
    /// </summary>
    [FieldOffset(12)] public uint VisScreenHeight;
    /// <summary>
    /// Field of type uint on offset 16
    /// </summary>
    [FieldOffset(16)] public uint BitsPerPlane;
    /// <summary>
    /// Field of type uint on offset 20
    /// </summary>
    [FieldOffset(20)] public uint NumberOfPlanes;
    /// <summary>
    /// Field of type uint on offset 24
    /// </summary>
    [FieldOffset(24)] public uint Frequency;
    /// <summary>
    /// Field of type uint on offset 28
    /// </summary>
    [FieldOffset(28)] public uint XMillimeter;
    /// <summary>
    /// Field of type uint on offset 32
    /// </summary>
    [FieldOffset(32)] public uint YMillimeter;
    /// <summary>
    /// Field of type uint on offset 36
    /// </summary>
    [FieldOffset(36)] public uint NumberOfButtons;
    /// <summary>
    /// Field of type uint on offset 40
    /// </summary>
    [FieldOffset(40)] public uint NumberOfPointerButtons;
    /// <summary>
    /// Field of type Bool4 on offset 44
    /// </summary>
    [FieldOffset(44)] public Bool4 Interlaced;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 40)
]
public unsafe struct DriveLayoutGpt :
    IStructContracts<DriveLayoutGpt>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is DriveLayoutGpt other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(DriveLayoutGpt other) => this == other;
    public static bool operator ==(DriveLayoutGpt a, DriveLayoutGpt b)
    {
        if (a.DiskId != b.DiskId)
            return false;
        if (a.StartingUsableOffset != b.StartingUsableOffset)
            return false;
        if (a.UsableLength != b.UsableLength)
            return false;
        if (a.MaxPartitionCount != b.MaxPartitionCount)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            DriveLayoutGpt: {
                DiskId: {{DiskId}}
                StartingUsableOffset: {{StartingUsableOffset}}
                UsableLength: {{UsableLength}}
                MaxPartitionCount: {{MaxPartitionCount}}
            }
            """;
    }

    public static bool operator !=(DriveLayoutGpt a, DriveLayoutGpt b)
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
		DiskId = default;
		StartingUsableOffset = default;
		UsableLength = default;
		MaxPartitionCount = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type Guid on offset 0
    /// </summary>
    [FieldOffset(0)] public Guid DiskId;
    /// <summary>
    /// Field of type long on offset 16
    /// </summary>
    [FieldOffset(16)] public long StartingUsableOffset;
    /// <summary>
    /// Field of type long on offset 24
    /// </summary>
    [FieldOffset(24)] public long UsableLength;
    /// <summary>
    /// Field of type uint on offset 32
    /// </summary>
    [FieldOffset(32)] public uint MaxPartitionCount;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 192)
]
public unsafe struct DriveLayoutInformationEx :
    IStructContracts<DriveLayoutInformationEx>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is DriveLayoutInformationEx other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(DriveLayoutInformationEx other) => this == other;
    public static bool operator ==(DriveLayoutInformationEx a, DriveLayoutInformationEx b)
    {
        if (a.PartitionStyle != b.PartitionStyle)
            return false;
        if (a.PartitionCount != b.PartitionCount)
            return false;
        if (a.Mbr != b.Mbr)
            return false;
        if (a.Gpt != b.Gpt)
            return false;
        if (a.FirstEntry != b.FirstEntry)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            DriveLayoutInformationEx: {
                PartitionStyle: {{PartitionStyle}}
                PartitionCount: {{PartitionCount}}
                Mbr: {{Mbr}}
                Gpt: {{Gpt}}
                FirstEntry: {{FirstEntry}}
            }
            """;
    }

    public static bool operator !=(DriveLayoutInformationEx a, DriveLayoutInformationEx b)
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
		PartitionStyle = default;
		PartitionCount = default;
		Mbr = default;
		Gpt = default;
		FirstEntry = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type PartitionStyle on offset 0
    /// </summary>
    [FieldOffset(0)] public PartitionStyle PartitionStyle;
    /// <summary>
    /// Field of type uint on offset 4
    /// </summary>
    [FieldOffset(4)] public uint PartitionCount;
    /// <summary>
    /// Field of type DriveLayoutMbr on offset 8
    /// </summary>
    [FieldOffset(8)] public DriveLayoutMbr Mbr;
    /// <summary>
    /// Field of type DriveLayoutGpt on offset 8
    /// </summary>
    [FieldOffset(8)] public DriveLayoutGpt Gpt;
    /// <summary>
    /// Field of type PartitionInformationEx on offset 48
    /// </summary>
    [FieldOffset(48)] public PartitionInformationEx FirstEntry;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 40)
]
public unsafe struct DriveLayoutMbr :
    IStructContracts<DriveLayoutMbr>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is DriveLayoutMbr other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(DriveLayoutMbr other) => this == other;
    public static bool operator ==(DriveLayoutMbr a, DriveLayoutMbr b)
    {
        if (a.Signature != b.Signature)
            return false;
        if (a.CheckSum != b.CheckSum)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            DriveLayoutMbr: {
                Signature: {{Signature}}
                CheckSum: {{CheckSum}}
            }
            """;
    }

    public static bool operator !=(DriveLayoutMbr a, DriveLayoutMbr b)
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
		Signature = default;
		CheckSum = default;
    }

    #endregion

    #region Constants

    /// <summary>
    /// Constant of type uint
    /// </summary>
    public const uint SignatureConst = 0xAA55;

    #endregion

    #region Fields

    /// <summary>
    /// Field of type uint on offset 0
    /// </summary>
    [FieldOffset(0)] public uint Signature;
    /// <summary>
    /// Field of type uint on offset 4
    /// </summary>
    [FieldOffset(4)] public uint CheckSum;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 144)
]
public unsafe struct PartitionInformationEx :
    IStructContracts<PartitionInformationEx>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is PartitionInformationEx other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PartitionInformationEx other) => this == other;
    public static bool operator ==(PartitionInformationEx a, PartitionInformationEx b)
    {
        if (a.PartitionStyle != b.PartitionStyle)
            return false;
        if (a.StartingOffset != b.StartingOffset)
            return false;
        if (a.PartitionLength != b.PartitionLength)
            return false;
        if (a.PartitionNumber != b.PartitionNumber)
            return false;
        if (a.RewritePartition != b.RewritePartition)
            return false;
        if (a.Mbr != b.Mbr)
            return false;
        if (a.Gpt != b.Gpt)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            PartitionInformationEx: {
                PartitionStyle: {{PartitionStyle}}
                StartingOffset: {{StartingOffset}}
                PartitionLength: {{PartitionLength}}
                PartitionNumber: {{PartitionNumber}}
                RewritePartition: {{RewritePartition}}
                Mbr: {{Mbr}}
                Gpt: {{Gpt}}
            }
            """;
    }

    public static bool operator !=(PartitionInformationEx a, PartitionInformationEx b)
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
		PartitionStyle = default;
		StartingOffset = default;
		PartitionLength = default;
		PartitionNumber = default;
		RewritePartition = default;
		Mbr = default;
		Gpt = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type PartitionStyle on offset 0
    /// </summary>
    [FieldOffset(0)] public PartitionStyle PartitionStyle;
    /// <summary>
    /// Field of type long on offset 8
    /// </summary>
    [FieldOffset(8)] public long StartingOffset;
    /// <summary>
    /// Field of type long on offset 16
    /// </summary>
    [FieldOffset(16)] public long PartitionLength;
    /// <summary>
    /// Field of type uint on offset 24
    /// </summary>
    [FieldOffset(24)] public uint PartitionNumber;
    /// <summary>
    /// Field of type Bool1 on offset 28
    /// </summary>
    [FieldOffset(28)] public Bool1 RewritePartition;
    /// <summary>
    /// Field of type PartitionInformationMbr on offset 32
    /// </summary>
    [FieldOffset(32)] public PartitionInformationMbr Mbr;
    /// <summary>
    /// Field of type PartitionInformationGpt on offset 32
    /// </summary>
    [FieldOffset(32)] public PartitionInformationGpt Gpt;

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 112)
]
public unsafe struct PartitionInformationGpt :
    IStructContracts<PartitionInformationGpt>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is PartitionInformationGpt other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PartitionInformationGpt other) => this == other;
    public static bool operator ==(PartitionInformationGpt a, PartitionInformationGpt b)
    {
        if (a.PartitionType != b.PartitionType)
            return false;
        if (a.PartitionId != b.PartitionId)
            return false;
        if (a.Attributes != b.Attributes)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            PartitionInformationGpt: {
                PartitionType: {{PartitionType}}
                PartitionId: {{PartitionId}}
                Attributes: {{Attributes}}
            }
            """;
    }

    public static bool operator !=(PartitionInformationGpt a, PartitionInformationGpt b)
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
		PartitionType = default;
		PartitionId = default;
		Attributes = default;
		Name[36] = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type Guid on offset 0
    /// </summary>
    [FieldOffset(0)] public Guid PartitionType;
    /// <summary>
    /// Field of type Guid on offset 16
    /// </summary>
    [FieldOffset(16)] public Guid PartitionId;
    /// <summary>
    /// Field of type PartitionAttributes on offset 32
    /// </summary>
    [FieldOffset(32)] public PartitionAttributes Attributes;
    /// <summary>
    /// Field of type fixed char on offset 40
    /// </summary>
    [FieldOffset(40)] public fixed char Name[36];

    #endregion
}

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 112)
]
public unsafe struct PartitionInformationMbr :
    IStructContracts<PartitionInformationMbr>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is PartitionInformationMbr other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(PartitionInformationMbr other) => this == other;
    public static bool operator ==(PartitionInformationMbr a, PartitionInformationMbr b)
    {
        if (a.PartitionType != b.PartitionType)
            return false;
        if (a.BootIndicator != b.BootIndicator)
            return false;
        if (a.RecognizedPartition != b.RecognizedPartition)
            return false;
        if (a.HiddenSectors != b.HiddenSectors)
            return false;
        if (a.PartitionId != b.PartitionId)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
        return
            $$"""
            PartitionInformationMbr: {
                PartitionType: {{PartitionType}}
                BootIndicator: {{BootIndicator}}
                RecognizedPartition: {{RecognizedPartition}}
                HiddenSectors: {{HiddenSectors}}
                PartitionId: {{PartitionId}}
            }
            """;
    }

    public static bool operator !=(PartitionInformationMbr a, PartitionInformationMbr b)
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
		PartitionType = default;
		BootIndicator = default;
		RecognizedPartition = default;
		HiddenSectors = default;
		PartitionId = default;
    }

    #endregion

    #region Fields

    /// <summary>
    /// Field of type PartitionType on offset 0
    /// </summary>
    [FieldOffset(0)] public PartitionType PartitionType;
    /// <summary>
    /// Field of type Bool1 on offset 1
    /// </summary>
    [FieldOffset(1)] public Bool1 BootIndicator;
    /// <summary>
    /// Field of type Bool1 on offset 2
    /// </summary>
    [FieldOffset(2)] public Bool1 RecognizedPartition;
    /// <summary>
    /// Field of type uint on offset 4
    /// </summary>
    [FieldOffset(4)] public uint HiddenSectors;
    /// <summary>
    /// Field of type Guid on offset 8
    /// </summary>
    [FieldOffset(8)] public Guid PartitionId;

    #endregion
}
#nullable restore