using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace TypedWinAPI.Contracts;

public interface IAsSpanCast : IAsReadOnlySpanCast
{
    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<byte> AsSpan();
}
public interface IAsReadOnlySpanCast
{
    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<byte> AsReadOnlySpan();
}

public interface IAsSpanCast<T> : IAsReadOnlySpanCast<T>
    where T : unmanaged
{
    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<T> AsSpan();
}
public interface IAsReadOnlySpanCast<T>
    where T : unmanaged
{
    [UnscopedRef]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> AsReadOnlySpan();
}