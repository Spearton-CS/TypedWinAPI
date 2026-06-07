using System.Runtime.InteropServices;

namespace TypedWinAPI.Kernel32;

[StructLayout(LayoutKind.Explicit, Size = 12)]
public struct StoragePropertyQuery
{
    [FieldOffset(0)] public StoragePropertyId PropertyId; // Usually enum STORAGE_PROPERTY_ID
    [FieldOffset(4)] public StorageQueryType QueryType;  // Usually enum STORAGE_QUERY_TYPE
    [FieldOffset(8)] public byte AdditionalParameters; // Start of VRA if needed

    public readonly override string ToString() =>
    $"""
    PropertyId: {PropertyId},
    QueryType: {QueryType}
    """;
}