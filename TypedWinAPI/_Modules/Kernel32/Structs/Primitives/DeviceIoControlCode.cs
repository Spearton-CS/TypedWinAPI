using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using TypedWinAPI.Contracts;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 4)]
public readonly record struct DeviceIoControlCode(
    [field: FieldOffset(0)] uint Raw)
    : IEqualityOperators<DeviceIoControlCode, DeviceIoControlCode, bool>, IEquatable<DeviceIoControlCode>,
        IEqualityOperators<DeviceIoControlCode, uint, bool>, IEquatable<uint>, IExplicitCast<DeviceIoControlCode, uint>
{
    /// <summary>
    /// Manually construct a control code (equivalent to CTL_CODE macro).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DeviceIoControlCode(DeviceType deviceType, uint function, Method method, DeviceAccess access)
        : this(((uint)deviceType << 16) | ((uint)access << 14) | (function << 2) | (uint)method) { }

    [FieldOffset(2)] public readonly DeviceType DeviceType;

    /// <summary>
    /// Function code (12 bits: bits 2-13).
    /// </summary>
    public readonly uint Function
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Raw >> 2) & 0x0FFF;
    }

    /// <summary>
    /// Access check flags (2 bits: bits 14-15).
    /// </summary>
    public readonly DeviceAccess Access
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (DeviceAccess)((Raw >> 14) & 0x03);
    }

    /// <summary>
    /// Buffering method (2 bits: bits 0-1).
    /// </summary>
    public readonly Method Method
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Method)(Raw & 0x03);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(uint other)
        => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(DeviceIoControlCode a, uint b) => a.Raw == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(DeviceIoControlCode a, uint b) => a.Raw != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(DeviceIoControlCode code) => code.Raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator DeviceIoControlCode(uint value) => new(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() =>
        $"0x{Raw:X8} [Device: {DeviceType}, Function: {Function}, Access: {Access}, Method: {Method}]";
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode() => Raw.GetHashCode();
}