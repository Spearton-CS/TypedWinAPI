using System.Numerics;

using TypedWinAPI.Contracts.Ptr;

namespace TypedWinAPI.Contracts;

/*
 * Handle16:
 * 
 * IEquatable<Handle16>, IComparable<Handle16>, IComparisonOperators<Handle16, Handle16, bool>, IBitwiseOperators<Handle16, Handle16, Handle16>,
 * IEquatable<ushort>, IComparable<ushort>, IComparisonOperators<Handle16, ushort, bool>, IBitwiseOperators<Handle16, ushort, Handle16>, IExplicitCast<Handle16, ushort>,
 * IEquatable<short>, IComparable<short>, IComparisonOperators<Handle16, short, bool>, IBitwiseOperators<Handle16, short, Handle16>, IExplicitCast<Handle16, short>,
 * IPtrEquatable, IPtrComparable, IPtrComparisonOperators<Handle16, bool>, IPtrBitwiseOperators<Handle16, Handle16>, IPtrExplicitCastFrom<Handle16>, IPtrImplicitCastTo<Handle16>,
 * IComparable, IMinMaxValue<Handle16>,
 * IFormattable, ISpanFormattable, IUtf8SpanFormattable,
 * ISpanParsable<Handle16>, IUtf8SpanParsable<Handle16>
 *
 * Derived handle:
 * 
 * IEquatable<TSelf>, IComparable<TSelf>, IComparisonOperators<TSelf, TSelf, bool>, IBitwiseOperators<TSelf, TSelf, TSelf>, IShiftOperators<TSelf, int, TSelf>,
 * IEquatable<TBaseHandle16>, IComparable<TBaseHandle16>, IComparisonOperators<TSelf, TBaseHandle16, bool>, IBitwiseOperators<TSelf, TBaseHandle16, TSelf>, IImplicitCastTo<TSelf, TBaseHandle16>, IExplicitCastFrom<TSelf, TBaseHandle16>
 * IEquatable<ushort>, IComparable<ushort>, IComparisonOperators<TSelf, ushort, bool>, IBitwiseOperators<TSelf, ushort, TSelf>, IExplicitCast<TSelf, ushort>,
 * IEquatable<short>, IComparable<short>, IComparisonOperators<TSelf, short, bool>, IBitwiseOperators<TSelf, short, TSelf>, IExplicitCast<TSelf, short>,
 * IPtrEquatable, IPtrComparable, IPtrComparisonOperators<TSelf, bool>, IPtrBitwiseOperators<TSelf, TSelf>, IPtrExplicitCastFrom<TSelf>, IPtrImplicitCastTo<TSelf>,
 * IComparable, IMinMaxValue<Handle16>,
 * IFormattable, ISpanFormattable, IUtf8SpanFormattable,
 * ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>
*/

/// <summary>
/// <see cref="IHandle16Contracts{TSelf}"/> that conflict with <see cref="ushort"/> and <see cref="short"/> contracts when define inside one contract
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface IHandle16TSelfContracts<TSelf> :
    IEquatable<TSelf>, IComparable<TSelf>, IComparisonOperators<TSelf, TSelf, bool>, IBitwiseOperators<TSelf, TSelf, TSelf>
    
    where TSelf : unmanaged, IHandle16TSelfContracts<TSelf>;
/// <summary>
/// <see cref="IHandle16Contracts{TSelf}"/> that conflict with <see cref="ushort"/> and <see cref="short"/> or <see cref="IHandle16TSelfContracts{TSelf}"/> contracts when define inside one contract
/// </summary>
/// <typeparam name="TSelf"></typeparam>
/// <typeparam name="TBaseHandle16"></typeparam>
public interface IHandle16TBaseHandle16Contracts<TSelf, TBaseHandle16> :
    IEquatable<TBaseHandle16>, IComparable<TBaseHandle16>, IComparisonOperators<TSelf, TBaseHandle16, bool>, IBitwiseOperators<TSelf, TBaseHandle16, TSelf>, IImplicitCastTo<TSelf, TBaseHandle16>, IExplicitCastFrom<TSelf, TBaseHandle16>

    where TSelf : unmanaged, IHandle16TBaseHandle16Contracts<TSelf, TBaseHandle16>
    where TBaseHandle16 : unmanaged, IHandle16TSelfContracts<TBaseHandle16>, IHandle16Contracts<TBaseHandle16>;
/// <summary>
/// Common contracts for <see cref="Handle16"/> and it's derived <see cref="Handle16"/>s
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface IHandle16Contracts<TSelf> :
    IShiftOperators<TSelf, int, TSelf>,
    IEquatable<ushort>, IComparable<ushort>, IComparisonOperators<TSelf, ushort, bool>, IBitwiseOperators<TSelf, ushort, TSelf>, IExplicitCast<TSelf, ushort>,
    IEquatable<short>, IComparable<short>, IComparisonOperators<TSelf, short, bool>, IBitwiseOperators<TSelf, short, TSelf>, IExplicitCast<TSelf, short>,
    IPtrEquatable, IPtrComparable, IPtrComparisonOperators<TSelf, bool>, IPtrBitwiseOperators<TSelf, TSelf>, IPtrExplicitCastFrom<TSelf>, IPtrExplicitCastTo<TSelf>,
    IComparable,
    IMinMaxValue<TSelf>,
    IFormattable, ISpanFormattable, IUtf8SpanFormattable,
    ISpanParsable<TSelf>, IUtf8SpanParsable<TSelf>
    
    where TSelf : unmanaged, IHandle16Contracts<TSelf>;