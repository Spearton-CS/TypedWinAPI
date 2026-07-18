using System.Numerics;
using System.Runtime.CompilerServices;

namespace TypedWinAPI.User32;

unsafe partial struct LParam :
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
    public readonly bool Equals(void* other) => this == other;
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool1(LParam LParam) => LParam.SignedValue != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(Bool1 b) => (LParam)(b ? 1 : 0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator bool(LParam LParam) => LParam.SignedValue != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LParam(bool b) => (LParam)(b ? 1 : 0);

    #endregion
}