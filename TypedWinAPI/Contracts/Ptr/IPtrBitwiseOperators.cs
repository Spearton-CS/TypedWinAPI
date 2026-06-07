namespace TypedWinAPI.Contracts.Ptr;

public unsafe interface IPtrBitwiseOperators<TSelf, TReturn>
    where TSelf : IPtrBitwiseOperators<TSelf, TReturn>?
    where TReturn : allows ref struct
{
    public abstract static TReturn operator &(TSelf a, void* b);
    public abstract static TReturn operator |(TSelf a, void* b);
    public abstract static TReturn operator ^(TSelf a, void* b);
    public abstract static TReturn operator ~(TSelf a);
}