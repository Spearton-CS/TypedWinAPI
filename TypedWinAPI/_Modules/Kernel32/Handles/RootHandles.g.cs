using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using TypedWinAPI.Contracts;

namespace TypedWinAPI.Kernel32;


/// <summary>
/// 
/// </summary>
[
    StructLayout(LayoutKind.Explicit, Size = 8),
    DebuggerDisplay("{ToString(),nq}"),
    DebuggerStepThrough,
    SkipLocalsInit
]
public unsafe readonly struct HInstance :
    IHandleTSelfContracts<HInstance>, IHandleTBaseHandleContracts<HInstance, Handle>, IHandleContracts<HInstance>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HInstance() => HandleValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HInstance(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HInstance(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HInstance(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HInstance(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HInstance MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HInstance)Handle.MinValue;
    }
    public static HInstance MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HInstance)Handle.MaxValue;
    }

    public static HInstance Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HInstance)Handle.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator <<(HInstance a, int shift) => (HInstance)(a.HandleValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator >>(HInstance a, int shift) => (HInstance)(a.HandleValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator >>>(HInstance a, int shift) => (HInstance)(a.HandleValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator &(HInstance a, HInstance b) => (HInstance)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator |(HInstance a, HInstance b) => (HInstance)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator ^(HInstance a, HInstance b) => (HInstance)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator ~(HInstance a) => (HInstance)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator &(HInstance a, Handle b) => (HInstance)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator |(HInstance a, Handle b) => (HInstance)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator ^(HInstance a, Handle b) => (HInstance)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator &(HInstance a, nuint b) => (HInstance)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator |(HInstance a, nuint b) => (HInstance)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator ^(HInstance a, nuint b) => (HInstance)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator &(HInstance a, nint b) => (HInstance)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator |(HInstance a, nint b) => (HInstance)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator ^(HInstance a, nint b) => (HInstance)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator &(HInstance a, void* b) => (HInstance)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator |(HInstance a, void* b) => (HInstance)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance operator ^(HInstance a, void* b) => (HInstance)(a.UnsignedValue ^ (nuint)b);

    #endregion

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HInstance other ? this == other
            : obj is Handle h ? this == h
                : obj is nuint unsig ? this == unsig
                    : obj is nint sig && this == sig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HInstance other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(void* other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HInstance a, HInstance b) => a.HandleValue == b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HInstance a, HInstance b) => a.HandleValue != b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HInstance a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HInstance a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HInstance a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HInstance a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HInstance a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HInstance a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HInstance a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HInstance a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HandleValue.GetHashCode();

    #endregion

    #region Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(object? obj)
        => obj is HInstance other ? CompareTo(other)
            : obj is Handle h ? CompareTo(h)
                : obj is nuint unsig ? CompareTo(unsig)
                    : obj is nint sig ? CompareTo(sig)
                        : 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HInstance other) => HandleValue.CompareTo(other.HandleValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HInstance a, HInstance b) => a.HandleValue < b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HInstance a, HInstance b) => a.HandleValue > b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HInstance a, HInstance b) => a.HandleValue <= b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HInstance a, HInstance b) => a.HandleValue >= b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HInstance a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HInstance a, Handle b) => a.HandleValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HInstance a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HInstance a, Handle b) => a.HandleValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HInstance a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HInstance a, nuint b) => a.UnsignedValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HInstance a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HInstance a, nuint b) => a.UnsignedValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HInstance a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HInstance a, nint b) => a.SignedValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HInstance a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HInstance a, nint b) => a.SignedValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HInstance a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HInstance a, void* b) => a.PointerValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HInstance a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HInstance a, void* b) => a.PointerValue >= b;

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => HandleValue.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HandleValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HandleValue.TryFormat(destination, out written, format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance Parse(string s, IFormatProvider? provider = null) => (HInstance)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HInstance result)
    {
        Unsafe.SkipInit(out result);
	return Handle.TryParse(s, provider, out Unsafe.As<HInstance, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HInstance)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HInstance result)
    {
        Unsafe.SkipInit(out result);
	return Handle.TryParse(s, provider, out Unsafe.As<HInstance, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HInstance Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HInstance)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HInstance result)
    {
        Unsafe.SkipInit(out result);
	return Handle.TryParse(s, provider, out Unsafe.As<HInstance, Handle>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HInstance(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HInstance(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HInstance(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HInstance(nint sig) => new(sig);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HInstance h) => h.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HInstance h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HInstance h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HInstance h) => h.SignedValue;

    #endregion
}

/// <summary>
/// Handle to a Kernel32 device
/// </summary>
[
    StructLayout(LayoutKind.Explicit, Size = 8),
    DebuggerDisplay("{ToString(),nq}"),
    DebuggerStepThrough,
    SkipLocalsInit
]
public unsafe readonly struct HDevice :
    IHandleTSelfContracts<HDevice>, IHandleTBaseHandleContracts<HDevice, Handle>, IHandleContracts<HDevice>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HDevice() => HandleValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HDevice(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HDevice(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HDevice(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HDevice(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HDevice MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HDevice)Handle.MinValue;
    }
    public static HDevice MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HDevice)Handle.MaxValue;
    }

    public static HDevice Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HDevice)Handle.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator <<(HDevice a, int shift) => (HDevice)(a.HandleValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator >>(HDevice a, int shift) => (HDevice)(a.HandleValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator >>>(HDevice a, int shift) => (HDevice)(a.HandleValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator &(HDevice a, HDevice b) => (HDevice)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator |(HDevice a, HDevice b) => (HDevice)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator ^(HDevice a, HDevice b) => (HDevice)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator ~(HDevice a) => (HDevice)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator &(HDevice a, Handle b) => (HDevice)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator |(HDevice a, Handle b) => (HDevice)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator ^(HDevice a, Handle b) => (HDevice)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator &(HDevice a, nuint b) => (HDevice)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator |(HDevice a, nuint b) => (HDevice)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator ^(HDevice a, nuint b) => (HDevice)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator &(HDevice a, nint b) => (HDevice)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator |(HDevice a, nint b) => (HDevice)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator ^(HDevice a, nint b) => (HDevice)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator &(HDevice a, void* b) => (HDevice)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator |(HDevice a, void* b) => (HDevice)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice operator ^(HDevice a, void* b) => (HDevice)(a.UnsignedValue ^ (nuint)b);

    #endregion

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HDevice other ? this == other
            : obj is Handle h ? this == h
                : obj is nuint unsig ? this == unsig
                    : obj is nint sig && this == sig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HDevice other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(void* other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HDevice a, HDevice b) => a.HandleValue == b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HDevice a, HDevice b) => a.HandleValue != b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HDevice a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HDevice a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HDevice a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HDevice a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HDevice a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HDevice a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HDevice a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HDevice a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HandleValue.GetHashCode();

    #endregion

    #region Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(object? obj)
        => obj is HDevice other ? CompareTo(other)
            : obj is Handle h ? CompareTo(h)
                : obj is nuint unsig ? CompareTo(unsig)
                    : obj is nint sig ? CompareTo(sig)
                        : 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HDevice other) => HandleValue.CompareTo(other.HandleValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HDevice a, HDevice b) => a.HandleValue < b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HDevice a, HDevice b) => a.HandleValue > b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HDevice a, HDevice b) => a.HandleValue <= b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HDevice a, HDevice b) => a.HandleValue >= b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HDevice a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HDevice a, Handle b) => a.HandleValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HDevice a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HDevice a, Handle b) => a.HandleValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HDevice a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HDevice a, nuint b) => a.UnsignedValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HDevice a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HDevice a, nuint b) => a.UnsignedValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HDevice a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HDevice a, nint b) => a.SignedValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HDevice a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HDevice a, nint b) => a.SignedValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HDevice a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HDevice a, void* b) => a.PointerValue > b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HDevice a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HDevice a, void* b) => a.PointerValue >= b;

    #endregion

    #region Format and Parse

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => HandleValue.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => HandleValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HandleValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => HandleValue.TryFormat(destination, out written, format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice Parse(string s, IFormatProvider? provider = null) => (HDevice)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HDevice result)
    {
        Unsafe.SkipInit(out result);
	return Handle.TryParse(s, provider, out Unsafe.As<HDevice, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HDevice)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HDevice result)
    {
        Unsafe.SkipInit(out result);
	return Handle.TryParse(s, provider, out Unsafe.As<HDevice, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HDevice Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HDevice)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HDevice result)
    {
        Unsafe.SkipInit(out result);
	return Handle.TryParse(s, provider, out Unsafe.As<HDevice, Handle>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HDevice(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HDevice(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HDevice(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HDevice(nint sig) => new(sig);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HDevice h) => h.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HDevice h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HDevice h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HDevice h) => h.SignedValue;

    #endregion
}
