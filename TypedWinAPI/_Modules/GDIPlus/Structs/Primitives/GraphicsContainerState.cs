using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using TypedWinAPI.Contracts;

namespace TypedWinAPI.GDIPlus;

[StructLayout(LayoutKind.Explicit, Size = 4)]
public readonly record struct GraphicsContainerState(
    [field: FieldOffset(0)] uint Raw)
    : IEqualityOperators<GraphicsContainerState, GraphicsContainerState, bool>, IEquatable<GraphicsContainerState>, IExplicitCast<GraphicsContainerState, uint>
{
    public static GraphicsContainerState Invalid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator uint(GraphicsContainerState state) => state.Raw;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static explicit operator GraphicsContainerState(uint raw) => new(raw);
}