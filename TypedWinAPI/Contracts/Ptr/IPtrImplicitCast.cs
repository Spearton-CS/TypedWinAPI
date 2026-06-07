namespace TypedWinAPI.Contracts.Ptr;

public unsafe interface IPtrImplicitCastTo<TSelf>
    where TSelf : IPtrImplicitCastTo<TSelf>?
{
    public abstract static implicit operator void*(TSelf a);
}
public unsafe interface IPtrImplicitCastFrom<TSelf>
    where TSelf : IPtrImplicitCastFrom<TSelf>?
{
    public abstract static implicit operator TSelf(void* a);
}
public interface IPtrImplicitCast<TSelf>
    : IPtrImplicitCastTo<TSelf>, IPtrImplicitCastFrom<TSelf>
    where TSelf : IPtrImplicitCast<TSelf>?;