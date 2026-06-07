namespace TypedWinAPI.Contracts.Ptr;

public unsafe interface IPtrExplicitCastTo<TSelf>
    where TSelf : IPtrExplicitCastTo<TSelf>?
{
    public abstract static explicit operator void*(TSelf a);
}
public unsafe interface IPtrExplicitCastFrom<TSelf>
    where TSelf : IPtrExplicitCastFrom<TSelf>?
{
    public abstract static explicit operator TSelf(void* a);
}
public interface IPtrExplicitCast<TSelf>
    : IPtrExplicitCastFrom<TSelf>, IPtrExplicitCastTo<TSelf>
    where TSelf : IPtrExplicitCast<TSelf>?;