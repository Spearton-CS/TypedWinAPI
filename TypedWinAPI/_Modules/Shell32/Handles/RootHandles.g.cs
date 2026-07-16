#nullable enable
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Numerics;

namespace TypedWinAPI.Shell32;

/// <summary>
/// Struct over <see cref="nuint"/>, or <see cref="nuint"/> or <see langword="void"/>*. Abstraction over Win32 HProcess
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 8),
	DebuggerDisplay("{UnsignedValue.ToString(\"X16\"),nq}"),
	DebuggerStepThrough,
	SkipLocalsInit]
public unsafe readonly struct HProcess :
	IEqualityOperators<HProcess, HProcess, bool>, IEquatable<HProcess>,
	IEqualityOperators<HProcess, Handle, bool>, IEquatable<Handle>,
    IEqualityOperators<HProcess, nuint, bool>, IEquatable<nuint>,
    IEqualityOperators<HProcess, nint, bool>, IEquatable<nint>,

#if ManagedObjects
	IComparable,
#endif

#if ManagedStrings
	IParsable<HProcess>, ISpanParsable<HProcess>, IUtf8SpanParsable<HProcess>,
	IFormattable, ISpanFormattable, IUtf8SpanFormattable,
#endif

	IComparisonOperators<HProcess, HProcess, bool>, IComparable<HProcess>,
	IComparisonOperators<HProcess, Handle, bool>, IComparable<Handle>,
    IComparisonOperators<HProcess, nuint, bool>, IComparable<nuint>,
    IComparisonOperators<HProcess, nint, bool>, IComparable<nint>
{
	#region Construct

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HProcess() => PointerValue = null;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HProcess(void* ptr) => PointerValue = ptr;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HProcess(nuint unsig) => UnsignedValue = unsig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HProcess(nint sig) => SignedValue = sig;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HProcess(Handle @base) => PointerValue = @base.PointerValue;

	#endregion

	#region Fields

	[FieldOffset(0)] public readonly void* PointerValue;

	[FieldOffset(0)] public readonly nuint UnsignedValue;

	[FieldOffset(0)] public readonly nint SignedValue;

	#endregion

	#region Equality

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is HProcess other)
			return this == other;
		else if (obj is Handle @Handle)
			return this == @Handle;
		else if (obj is nuint unsig)
			return this == unsig;
		else if (obj is nint sig)
			return this == sig;
		else
			return false;
	}
#endif
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
	public static bool operator ==(HProcess a, HProcess b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HProcess a, HProcess b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HProcess a, Handle b) => a.PointerValue == b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HProcess a, Handle b) => a.PointerValue != b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HProcess a, void* b) => a.PointerValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HProcess a, void* b) => a.PointerValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HProcess a, nuint b) => a.UnsignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HProcess a, nuint b) => a.UnsignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HProcess a, nint b) => a.SignedValue == b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HProcess a, nint b) => a.SignedValue != b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly override int GetHashCode() => UnsignedValue.GetHashCode();

	#endregion

	#region Comparability

#if ManagedObjects
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(object? obj)
	{
		if (obj is HProcess other)
			return CompareTo(other);
		else if (obj is Handle @Handle)
			return CompareTo(@Handle);
		else if (obj is nuint unsig)
			return CompareTo(unsig);
		else if (obj is nint sig)
			return CompareTo(sig);
		else
			return 0;
	}
#endif
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(HProcess other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(Handle other) => UnsignedValue.CompareTo(other.UnsignedValue);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HProcess a, HProcess b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HProcess a, HProcess b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HProcess a, HProcess b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HProcess a, HProcess b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HProcess a, Handle b) => a.PointerValue < b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HProcess a, Handle b) => a.PointerValue > b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HProcess a, Handle b) => a.PointerValue <= b.PointerValue;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HProcess a, Handle b) => a.PointerValue >= b.PointerValue;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HProcess a, void* b) => a.PointerValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HProcess a, void* b) => a.PointerValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HProcess a, void* b) => a.PointerValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HProcess a, void* b) => a.PointerValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HProcess a, nuint b) => a.UnsignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HProcess a, nuint b) => a.UnsignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HProcess a, nuint b) => a.UnsignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HProcess a, nuint b) => a.UnsignedValue >= b;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <(HProcess a, nint b) => a.SignedValue < b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >(HProcess a, nint b) => a.SignedValue > b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator <=(HProcess a, nint b) => a.SignedValue <= b;
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator >=(HProcess a, nint b) => a.SignedValue >= b;

	#endregion

#if ManagedStrings
	#region Format and Parse

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => UnsignedValue.ToString("X16");
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string ToString(string? format, IFormatProvider? provider = null) => UnsignedValue.ToString(format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => UnsignedValue.TryFormat(destination, out written, format, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        => UnsignedValue.TryFormat(destination, out written, format, provider);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess Parse(string s, IFormatProvider? provider = null) => (HProcess)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider? provider, scoped out HProcess result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HProcess, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => (HProcess)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out HProcess result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HProcess, nuint>(ref result));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static HProcess Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => (HProcess)nuint.Parse(s, provider);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, scoped out HProcess result)
    {
        Unsafe.SkipInit(out result);
        return nuint.TryParse(s, provider, out Unsafe.As<HProcess, nuint>(ref result));
    }

	#endregion
#endif

	#region Cast

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator HProcess(Handle @base) => new(@base);
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HProcess(void* ptr) => new(ptr);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HProcess(nuint unsig) => new(unsig);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator HProcess(nint sig) => new(sig);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Handle(HProcess self) => new(self.PointerValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(HProcess h) => h.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(HProcess h) => h.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(HProcess h) => h.SignedValue;

	#endregion
}

#nullable restore
