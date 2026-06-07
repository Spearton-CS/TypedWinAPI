namespace TypedWinAPI.Contracts.Ptr;

public unsafe interface IPtrEquatable
{
    public bool Equals(void* other);
}