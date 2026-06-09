#nullable enable
// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypedWinAPI.Contracts;
using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.SHCore;

/// <summary>
/// Handle to a SHCore monitor
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HMonitor :
    // --- Default contracts ---
    IHandleTSelfContracts<HMonitor>,
    IHandleTBaseHandleContracts<HMonitor, Handle>,
    IHandleContracts<HMonitor>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMonitor() => HandleValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMonitor(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMonitor(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMonitor(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HMonitor(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HMonitor MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HMonitor)Handle.MinValue;
    }

    public static HMonitor MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HMonitor)Handle.MaxValue;
    }

    public static HMonitor Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HMonitor)Handle.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator <<(HMonitor a, int shift) => (HMonitor)(a.HandleValue << shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator >>(HMonitor a, int shift) => (HMonitor)(a.HandleValue >> shift);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator >>>(HMonitor a, int shift) => (HMonitor)(a.HandleValue >>> shift);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator &(HMonitor a, HMonitor b) => (HMonitor)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator |(HMonitor a, HMonitor b) => (HMonitor)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator ^(HMonitor a, HMonitor b) => (HMonitor)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator ~(HMonitor a) => (HMonitor)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator &(HMonitor a, Handle b) => (HMonitor)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator |(HMonitor a, Handle b) => (HMonitor)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator ^(HMonitor a, Handle b) => (HMonitor)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator &(HMonitor a, nuint b) => (HMonitor)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator |(HMonitor a, nuint b) => (HMonitor)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator ^(HMonitor a, nuint b) => (HMonitor)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator &(HMonitor a, nint b) => (HMonitor)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator |(HMonitor a, nint b) => (HMonitor)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator ^(HMonitor a, nint b) => (HMonitor)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator &(HMonitor a, void* b) => (HMonitor)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator |(HMonitor a, void* b) => (HMonitor)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor operator ^(HMonitor a, void* b) => (HMonitor)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HMonitor other ? this == other
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HMonitor other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(void* other) => this == other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo([NotNullWhen(true)] object? obj)
        => obj is HMonitor other ? CompareTo(other)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HMonitor other) => HandleValue.CompareTo(other.HandleValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HMonitor a, HMonitor b) => a.HandleValue == b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HMonitor a, HMonitor b) => a.HandleValue != b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HMonitor a, HMonitor b) => a.HandleValue < b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HMonitor a, HMonitor b) => a.HandleValue > b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HMonitor a, HMonitor b) => a.HandleValue <= b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HMonitor a, HMonitor b) => a.HandleValue >= b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HMonitor a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HMonitor a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HMonitor a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HMonitor a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HMonitor a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HMonitor a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HMonitor a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HMonitor a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HMonitor a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HMonitor a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HMonitor a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HMonitor a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HMonitor a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HMonitor a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HMonitor a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HMonitor a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HMonitor a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HMonitor a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HMonitor a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HMonitor a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HMonitor a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HMonitor a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HMonitor a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HMonitor a, void* b) => a.PointerValue >= b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => HandleValue.GetHashCode();

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
    public static HMonitor Parse(string s, IFormatProvider? provider = null) => (HMonitor)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HMonitor result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HMonitor, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HMonitor)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HMonitor result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HMonitor, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HMonitor Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HMonitor)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HMonitor result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HMonitor, Handle>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMonitor(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HMonitor h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMonitor(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HMonitor h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMonitor(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HMonitor h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HMonitor(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HMonitor h) => h.PointerValue;

    #endregion
}
#nullable restore