namespace TypedWinAPI.GDIPlus;

public enum CombineMode : int
{
    Replace = 0, // default, overwrite clip
    Intersect = 1,
    Union = 2,
    Xor = 3,
    Exclude = 4,
    Complement = 5
}