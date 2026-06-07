using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypedWinAPI.User32;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe readonly struct LParam :
    IEqualityOperators<LParam, LParam, bool>, IEquatable<LParam>,
    IEqualityOperators<LParam, Handle, bool>, IEquatable<Handle>,
    IEqualityOperators<LParam, Handle16, bool>, IEquatable<Handle16>,
    IEqualityOperators<LParam, nint, bool>, IEquatable<nint>,
    IEqualityOperators<LParam, nuint, bool>, IEquatable<nuint>
{
    public static LParam Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(nuint.Zero);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LParam(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LParam(Handle16 h) => Handle16Value = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LParam(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LParam(nint signed) => SignedValue = signed;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LParam(nuint unsigned) => UnsignedValue = unsigned;

    [FieldOffset(0)] public readonly Handle HandleValue;
    [FieldOffset(0)] public readonly Handle16 Handle16Value;
    [FieldOffset(0)] public readonly void* PointerValue;
    [FieldOffset(0)] public readonly nint SignedValue;
    [FieldOffset(0)] public readonly nuint UnsignedValue;

    #region Decomposition

    /// <summary>
    /// Extracts the mouse wheel delta or other high-word values from a window message's WPARAM.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly short GetDelta() => (short)((SignedValue >> 16) & 0xFFFF);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly SysCommandType GetSysCommandType() => (SysCommandType)(SignedValue & 0xFFF0);

    #endregion

    #region Equality

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override bool Equals([NotNullWhen(true)] object? obj)
        => (obj is LParam other && this == other)
        || (obj is nint signed && this == signed)
        || (obj is nuint unsigned && this == unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(LParam other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, LParam right) => left.SignedValue == right.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, LParam right) => left.SignedValue != right.SignedValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, Handle right) => left.HandleValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, Handle right) => left.HandleValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle16 other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, Handle16 right) => left.Handle16Value == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, Handle16 right) => left.Handle16Value != right;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, void* right) => left.PointerValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, void* right) => left.PointerValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, nint right) => left.SignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, nint right) => left.SignedValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LParam left, nuint right) => left.UnsignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LParam left, nuint right) => left.UnsignedValue != right;

    #endregion

    #region ValueType override

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => SignedValue.GetHashCode();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => SignedValue.ToString("X16");

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(LParam LParam) => LParam.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(Handle ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle16(LParam LParam) => LParam.Handle16Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(Handle16 ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(LParam LParam) => LParam.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(void* ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(LParam LParam) => LParam.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(nuint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(LParam LParam) => LParam.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(nint signed) => new(signed);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(LParam LParam) => (uint)LParam.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(uint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(LParam LParam) => (int)LParam.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(int signed) => new(signed);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool4(LParam LParam) => LParam.SignedValue != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(Bool4 b) => (LParam)(b ? 1 : 0);

    #endregion
}