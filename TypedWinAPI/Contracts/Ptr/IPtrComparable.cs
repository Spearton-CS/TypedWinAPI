namespace TypedWinAPI.Contracts.Ptr;

public unsafe interface IPtrComparable
{
    public int CompareTo(void* other);
}