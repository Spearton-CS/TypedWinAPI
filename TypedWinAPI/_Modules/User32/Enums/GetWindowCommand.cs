namespace TypedWinAPI.User32;

public enum GetWindowCommand : uint
{
    First = 0,
    Last = 1,
    Next = 2,
    Prev = 3,
    Owner = 4,
    Child = 5,
    EnabledPopup = 6
}