namespace TypedWinAPI.Contracts.Ptr;

public unsafe interface IPtrEqualityOperators<TSelf, TReturn>
    where TSelf : IPtrEqualityOperators<TSelf, TReturn>?
    where TReturn : allows ref struct
{
    public abstract static TReturn operator ==(TSelf a, void* b);
    public abstract static TReturn operator !=(TSelf a, void* b);
}