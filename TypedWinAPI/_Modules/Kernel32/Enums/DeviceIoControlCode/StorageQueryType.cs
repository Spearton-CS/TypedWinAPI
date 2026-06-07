namespace TypedWinAPI.Kernel32;

public enum StorageQueryType : uint
{
    PropertyStandardQuery = 0,
    PropertyExistsQuery = 1,
    PropertyMaskQuery = 2,
    PropertyQueryMaxDefined = 3
}