namespace TypedWinAPI.Contracts;

public interface IImplicitCastFrom<TSelf, TFrom>
    where TSelf : IImplicitCastFrom<TSelf, TFrom>?
    where TFrom : allows ref struct
{
    public abstract static implicit operator TSelf(TFrom a);
}
public interface IImplicitCastTo<TSelf, TTo>
    where TSelf : IImplicitCastTo<TSelf, TTo>?
    where TTo : allows ref struct
{
    public abstract static implicit operator TTo(TSelf a);
}
public interface IImplicitCast<TSelf, TOther>
    : IImplicitCastFrom<TSelf, TOther>, IImplicitCastTo<TSelf, TOther>
    where TSelf : IImplicitCast<TSelf, TOther>?
    where TOther : allows ref struct;