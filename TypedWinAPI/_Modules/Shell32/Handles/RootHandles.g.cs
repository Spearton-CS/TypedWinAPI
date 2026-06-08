// --- Default usings ---
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypedWinAPI.Contracts;
using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.Shell32;

/// <summary>
/// Handle to a Shell32 process
/// </summary>
[
	// --- Default attributes ---
	StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{ToString(),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit
]
public unsafe readonly struct HProcess :
    // --- Default contracts ---
    IHandleTSelfContracts<HProcess>,
    IHandleTBaseHandleContracts<HProcess, Handle>,
    IHandleContracts<HProcess>
{
    #region Construct

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HProcess() => HandleValue = default;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HProcess(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HProcess(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HProcess(nuint unsig) => UnsignedValue = unsig;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public HProcess(nint sig) => SignedValue = sig;

    #endregion

    #region Fields

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;
    [FieldOffset(0)] public readonly nint SignedValue;

    #endregion

    #region Math

    public static HProcess MinValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HProcess)Handle.MinValue;
    }

    public static HProcess MaxValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HProcess)Handle.MaxValue;
    }

    public static HProcess Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HProcess)Handle.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator <<(HProcess a, int shift) => (HProcess)a.HandleValue << shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator >>(HProcess a, int shift) => (HProcess)a.HandleValue >> shift;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator >>>(HProcess a, int shift) => (HProcess)a.HandleValue >>> shift;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator &(HProcess a, HProcess b) => (HProcess)(a.UnsignedValue & b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator |(HProcess a, HProcess b) => (HProcess)(a.UnsignedValue | b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator ^(HProcess a, HProcess b) => (HProcess)(a.UnsignedValue ^ b.UnsignedValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator ~(HProcess a) => (HProcess)~a.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator &(HProcess a, Handle b) => (HProcess)(a.HandleValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator |(HProcess a, Handle b) => (HProcess)(a.HandleValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator ^(HProcess a, Handle b) => (HProcess)(a.HandleValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator &(HProcess a, nuint b) => (HProcess)(a.UnsignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator |(HProcess a, nuint b) => (HProcess)(a.UnsignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator ^(HProcess a, nuint b) => (HProcess)(a.UnsignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator &(HProcess a, nint b) => (HProcess)(a.SignedValue & b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator |(HProcess a, nint b) => (HProcess)(a.SignedValue | b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator ^(HProcess a, nint b) => (HProcess)(a.SignedValue ^ b);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator &(HProcess a, void* b) => (HProcess)(a.UnsignedValue & (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator |(HProcess a, void* b) => (HProcess)(a.UnsignedValue | (nuint)b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess operator ^(HProcess a, void* b) => (HProcess)(a.UnsignedValue ^ (nuint)b);

    #endregion

	#region Equality and Comparability

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => obj is HProcess other ? this == other
                : obj is Handle h ? this == h
                    : obj is nuint unsig ? this == unsig
                        : obj is nint sig && this == sig;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(HProcess other) => this == other;

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
        => obj is HProcess other ? CompareTo(other)
                : obj is Handle h ? CompareTo(h)
                    : obj is nuint unsig ? CompareTo(unsig)
                        : obj is nint sig ? CompareTo(sig) : 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(HProcess other) => HandleValue.CompareTo(other.HandleValue);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HProcess a, HProcess b) => a.HandleValue == b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HProcess a, HProcess b) => a.HandleValue != b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HProcess a, HProcess b) => a.HandleValue < b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HProcess a, HProcess b) => a.HandleValue > b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HProcess a, HProcess b) => a.HandleValue <= b.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HProcess a, HProcess b) => a.HandleValue >= b.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(HProcess a, Handle b) => a.HandleValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(HProcess a, Handle b) => a.HandleValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(HProcess a, Handle b) => a.HandleValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(HProcess a, Handle b) => a.HandleValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(HProcess a, Handle b) => a.HandleValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(HProcess a, Handle b) => a.HandleValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HProcess a, nuint b) => a.UnsignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HProcess a, nuint b) => a.UnsignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HProcess a, nuint b) => a.UnsignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HProcess a, nuint b) => a.UnsignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HProcess a, nuint b) => a.UnsignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HProcess a, nuint b) => a.UnsignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HProcess a, nint b) => a.SignedValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HProcess a, nint b) => a.SignedValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HProcess a, nint b) => a.SignedValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HProcess a, nint b) => a.SignedValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HProcess a, nint b) => a.SignedValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HProcess a, nint b) => a.SignedValue >= b;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator ==(HProcess a, void* b) => a.PointerValue == b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator !=(HProcess a, void* b) => a.PointerValue != b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <(HProcess a, void* b) => a.PointerValue < b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >(HProcess a, void* b) => a.PointerValue > b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator <=(HProcess a, void* b) => a.PointerValue <= b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]public static bool operator >=(HProcess a, void* b) => a.PointerValue >= b;

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
    public static HProcess Parse(string s, IFormatProvider? provider = null) => (HProcess)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HProcess result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HProcess, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HProcess)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HProcess result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HProcess, Handle>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HProcess)Handle.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out HProcess result)
    {
        Unsafe.SkipInit(out result);
		return Handle.TryParse(s, provider, out Unsafe.As<HProcess, Handle>(ref result));
    }

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HProcess(Handle h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Handle(HProcess h) => h.HandleValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HProcess(nuint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HProcess h) => h.UnsignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HProcess(nint h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HProcess h) => h.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HProcess(void* h) => new(h);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HProcess h) => h.PointerValue;

    #endregion
}
