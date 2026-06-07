namespace TypedWinAPI.Contracts.Ptr;

public unsafe interface IPtrComparisonOperators<TSelf, TReturn>
    : IPtrEqualityOperators<TSelf, TReturn>
    where TSelf : IPtrComparisonOperators<TSelf, TReturn>?
    where TReturn : allows ref struct
{
    public abstract static TReturn operator <(TSelf a, void* b);
    public abstract static TReturn operator >(TSelf a, void* b);
    public abstract static TReturn operator <=(TSelf a, void* b);
    public abstract static TReturn operator >=(TSelf a, void* b);
}