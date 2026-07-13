#nullable enable
// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// --- Custom usings ---
using System.Numerics;

namespace TypedWinAPI.Kernel32;

/// <summary>
/// 
/// </summary>
[
	// --- Default attrributes ---
	DebuggerDisplay("{ToString(),nq}"),
	SkipLocalsInit,
	StructLayout(LayoutKind.Explicit, Size = 4)
]
public readonly unsafe struct DeviceIoControlCode()  :
	// --- Custom contracts ---
	IEqualityOperators<DeviceIoControlCode, uint, bool>,
	IEquatable<uint>
{
    #region IReadOnlyStructContracts

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals(object? obj)
        => obj is DeviceIoControlCode other && this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(DeviceIoControlCode other) => this == other;
    public static bool operator ==(DeviceIoControlCode a, DeviceIoControlCode b)
    {
        if (a.Raw != b.Raw)
            return false;
        if (a.DeviceType != b.DeviceType)
            return false;

		return true;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString()
    {
		return $"0x{Raw:X8} [Device: {DeviceType}, Function: {Function}, Access: {Access}, Method: {Method}]";
    }

    public static bool operator !=(DeviceIoControlCode a, DeviceIoControlCode b)
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

    #region Fields

    /// <summary>
    /// Field of type uint on offset 0
    /// </summary>
    [FieldOffset(0)] public readonly uint Raw = 0;
    /// <summary>
    /// Field of type DeviceType on offset 2
    /// </summary>
    [FieldOffset(2)] public readonly DeviceType DeviceType;

    #endregion

    #region Properties

    /// <summary>
    /// Function code (12 bits: bits 2-13)
    /// </summary>
    public readonly uint Function
    {
		[
		MethodImpl(MethodImplOptions.AggressiveInlining)
		]
        get
        {
            return (Raw >> 2) & 0x0FFF;
        }
    }
    /// <summary>
    /// Access check flags (2 bits: bits 14-15)
    /// </summary>
    public readonly DeviceAccess Access
    {
		[
		MethodImpl(MethodImplOptions.AggressiveInlining)
		]
        get
        {
            return (DeviceAccess)((Raw >> 14) & 0x03);
        }
    }
    /// <summary>
    /// Buffering method (2 bits: bits 0-1)
    /// </summary>
    public readonly Method Method
    {
		[
		MethodImpl(MethodImplOptions.AggressiveInlining)
		]
        get
        {
            return (Method)(Raw & 0x03);
        }
    }

    #endregion

    #region Functions

    /// <summary>
    /// Function with return type DeviceIoControlCode
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public DeviceIoControlCode (uint raw)
		: this()
    {
        Raw = raw;
    }
    /// <summary>
    /// Manually construct a control code (equivalent to CTL_CODE macro).
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public DeviceIoControlCode (DeviceType deviceType, uint function, Method method, DeviceAccess access)
		: this(((uint)deviceType << 16)
    | ((uint)access << 14)
    | (function << 2)
    | (uint)method)
    {
        
    }
    /// <summary>
    /// Function with return type bool
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly bool Equals(uint other)
    {
        return this == other;
    }
    /// <summary>
    /// Function with return type bool operator
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator ==(DeviceIoControlCode a, uint b)
    {
        return a.Raw == b;
    }
    /// <summary>
    /// Function with return type bool operator
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static bool operator !=(DeviceIoControlCode a, uint b)
    {
        return a.Raw != b;
    }
    /// <summary>
    /// Function with return type int
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public readonly override int GetHashCode()
    {
        return Raw.GetHashCode();
    }
    /// <summary>
    /// Function with return type uint
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator uint (DeviceIoControlCode code)
    {
        return code.Raw;
    }
    /// <summary>
    /// Function with return type DeviceIoControlCode
    /// </summary>
	[
	MethodImpl(MethodImplOptions.AggressiveInlining)
	]
    public static explicit operator DeviceIoControlCode (uint raw)
    {
        return new(raw);
    }

    #endregion
}
#nullable restore