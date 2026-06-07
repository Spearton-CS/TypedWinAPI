using System.Numerics;

using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.Contracts;

/*
 * Handle:
 * 
 * IEquatable<Handle>, IComparable<Handle>, IComparisonOperators<Handle, Handle, bool>, IBitwiseOperators<Handle, Handle, Handle>,
 * IEquatable<nuint>, IComparable<nuint>, IComparisonOperators<Handle, nuint, bool>, IBitwiseOperators<Handle, nuint, Handle>, IExplicitCast<Handle, nuint>,
 * IEquatable<nint>, IComparable<nint>, IComparisonOperators<Handle, nint, bool>, IBitwiseOperators<Handle, nint, Handle>, IExplicitCast<Handle, nint>,
 * IPtrEquatable, IPtrComparable, IPtrComparisonOperators<Handle, bool>, IPtrBitwiseOperators<Handle, Handle>, IPtrExplicitCastFrom<Handle>, IPtrImplicitCastTo<Handle>,
 * IComparable, IMinMaxValue<Handle>,
 * IFormattable, ISpanFormattable, IUtf8SpanFormattable,
 * ISpanParsable<Handle>, IUtf8SpanParsable<Handle>
 *
 * Derived handle:
 * 
 * IEquatable<TSelf>, IComparable<TSelf>, IComparisonOperators<TSelf, TSelf, bool>, IBitwiseOperators<TSelf, TSelf, TSelf>, IShiftOperators<TSelf, int, TSelf>,
 * IEquatable<TBaseHandle>, IComparable<TBaseHandle>, IComparisonOperators<TSelf, TBaseHandle, bool>, IBitwiseOperators<TSelf, TBaseHandle, TSelf>, IImplicitCastTo<TSelf, TBaseHandle>, IExplicitCastFrom<TSelf, TBaseHandle>
 * IEquatable<nuint>, IComparable<nuint>, IComparisonOperators<TSelf, nuint, bool>, IBitwiseOperators<TSelf, nuint, TSelf>, IExplicitCast<TSelf, nuint>,
 * IEquatable<nint>, IComparable<nint>, IComparisonOperators<TSelf, nint, bool>, IBitwiseOperators<TSelf, nint, TSelf>, IExplicitCast<TSelf, nint>,
 * IPtrEquatable, IPtrComparable, IPtrComparisonOperators<TSelf, bool>, IPtrBitwiseOperators<TSelf, TSelf>, IPtrExplicitCastFrom<TSelf>, IPtrImplicitCastTo<TSelf>,
 * IComparable, IMinMaxValue<Handle>,
 * IFormattable, ISpanFormattable, IUtf8SpanFormattable,
 * ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>
*/

/// <summary>
/// <see cref="IHandleContracts{TSelf}"/> that conflict with <see cref="nuint"/> and <see cref="nint"/> contracts when define inside one contract
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface IHandleTSelfContracts<TSelf> :
    IEquatable<TSelf>, IComparable<TSelf>, IComparisonOperators<TSelf, TSelf, bool>, IBitwiseOperators<TSelf, TSelf, TSelf>
    
    where TSelf : unmanaged, IHandleTSelfContracts<TSelf>;
/// <summary>
/// <see cref="IHandleContracts{TSelf}"/> that conflict with <see cref="nuint"/> and <see cref="nint"/> or <see cref="IHandleTSelfContracts{TSelf}"/> contracts when define inside one contract
/// </summary>
/// <typeparam name="TSelf"></typeparam>
/// <typeparam name="TBaseHandle"></typeparam>
public interface IHandleTBaseHandleContracts<TSelf, TBaseHandle> :
    IEquatable<TBaseHandle>, IComparable<TBaseHandle>, IComparisonOperators<TSelf, TBaseHandle, bool>, IBitwiseOperators<TSelf, TBaseHandle, TSelf>, IImplicitCastTo<TSelf, TBaseHandle>, IExplicitCastFrom<TSelf, TBaseHandle>

    where TSelf : unmanaged, IHandleTBaseHandleContracts<TSelf, TBaseHandle>
    where TBaseHandle : unmanaged, IHandleTSelfContracts<TBaseHandle>, IHandleContracts<TBaseHandle>;
/// <summary>
/// Common contracts for <see cref="Handle"/> and it's derived <see cref="Handle"/>s
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface IHandleContracts<TSelf> :
    IShiftOperators<TSelf, int, TSelf>,
    IEquatable<nuint>, IComparable<nuint>, IComparisonOperators<TSelf, nuint, bool>, IBitwiseOperators<TSelf, nuint, TSelf>, IExplicitCast<TSelf, nuint>,
    IEquatable<nint>, IComparable<nint>, IComparisonOperators<TSelf, nint, bool>, IBitwiseOperators<TSelf, nint, TSelf>, IExplicitCast<TSelf, nint>,
    IPtrEquatable, IPtrComparable, IPtrComparisonOperators<TSelf, bool>, IPtrBitwiseOperators<TSelf, TSelf>, IPtrExplicitCastFrom<TSelf>, IPtrExplicitCastTo<TSelf>,
    IComparable,
    IMinMaxValue<TSelf>,
    IFormattable, ISpanFormattable, IUtf8SpanFormattable,
    ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>
    
    where TSelf : unmanaged, IHandleContracts<TSelf>;