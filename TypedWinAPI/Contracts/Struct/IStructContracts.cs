using System.Numerics;
using System.Runtime.CompilerServices;

namespace TypedWinAPI.Contracts.Struct;

public interface IStructContracts<TSelf> : IReadOnlyStructContracts<TSelf>,
    IAsSpanCast

    where TSelf : unmanaged, IStructContracts<TSelf>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear();
}

public interface IReadOnlyStructContracts<TSelf> :
    IAsReadOnlySpanCast,
    IEqualityOperators<TSelf, TSelf, bool>, IEquatable<TSelf>

    where TSelf : unmanaged, IReadOnlyStructContracts<TSelf>
{

}