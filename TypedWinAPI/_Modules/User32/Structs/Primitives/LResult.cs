using System.Numerics;
using System.Runtime.CompilerServices;

namespace TypedWinAPI.User32;

unsafe partial struct LResult :
    IEqualityOperators<LResult, Handle16, bool>, IEquatable<Handle16>,
    IEqualityOperators<LResult, nint, bool>, IEquatable<nint>,
    IEqualityOperators<LResult, nuint, bool>, IEquatable<nuint>
{
    public static LResult Zero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(nuint.Zero);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LResult(Handle h) => HandleValue = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LResult(Handle16 h) => Handle16Value = h;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LResult(void* ptr) => PointerValue = ptr;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LResult(nint signed) => SignedValue = signed;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LResult(nuint unsigned) => UnsignedValue = unsigned;

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
    public static bool operator ==(LResult left, Handle right) => left.HandleValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LResult left, Handle right) => left.HandleValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(Handle16 other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LResult left, Handle16 right) => left.Handle16Value == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LResult left, Handle16 right) => left.Handle16Value != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(void* other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LResult left, void* right) => left.PointerValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LResult left, void* right) => left.PointerValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LResult left, nint right) => left.SignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LResult left, nint right) => left.SignedValue != right;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(nuint other) => this == other;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(LResult left, nuint right) => left.UnsignedValue == right;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(LResult left, nuint right) => left.UnsignedValue != right;

    #endregion

    #region ValueType override

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override int GetHashCode() => SignedValue.GetHashCode();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly override string ToString() => SignedValue.ToString("X16");

    #endregion

    #region Cast

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle(LResult LResult) => LResult.HandleValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(Handle ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Handle16(LResult LResult) => LResult.Handle16Value;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(Handle16 ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator void*(LResult LResult) => LResult.PointerValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(void* ptr) => new(ptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nuint(LResult LResult) => LResult.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(nuint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator nint(LResult LResult) => LResult.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(nint signed) => new(signed);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(LResult LResult) => (uint)LResult.UnsignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(uint unsigned) => new(unsigned);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator int(LResult LResult) => (int)LResult.SignedValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(int signed) => new(signed);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool4(LResult LResult) => LResult.SignedValue != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(Bool4 b) => (LResult)(b ? 1 : 0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator Bool1(LResult LResult) => LResult.SignedValue != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(Bool1 b) => (LResult)(b ? 1 : 0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator bool(LResult LResult) => LResult.SignedValue != 0;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator LResult(bool b) => (LResult)(b ? 1 : 0);

    #endregion
}