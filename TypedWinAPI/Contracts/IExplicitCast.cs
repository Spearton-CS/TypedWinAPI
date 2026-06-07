namespace TypedWinAPI.Contracts;

public interface IExplicitCastFrom<TSelf, TFrom>
    where TSelf : IExplicitCastFrom<TSelf, TFrom>?
    where TFrom : allows ref struct
{
    public abstract static explicit operator TSelf(TFrom a);
}
public interface IExplicitCastTo<TSelf, TTo>
    where TSelf : IExplicitCastTo<TSelf, TTo>?
    where TTo : allows ref struct
{
    public abstract static explicit operator TTo(TSelf a);
}
public interface IExplicitCast<TSelf, TOther>
    : IExplicitCastFrom<TSelf, TOther>, IExplicitCastTo<TSelf, TOther>
    where TSelf : IExplicitCast<TSelf, TOther>?
    where TOther : allows ref struct;