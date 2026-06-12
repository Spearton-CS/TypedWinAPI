using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class Kernel32
{
    public static void Generate(StringBuilder sb)
    {
        Program.Generate(sb, "_Modules/Kernel32/Handles/RootHandles.g.cs", "Kernel32 (Root)", static sb =>
        {
            HandleTemplate.Generate(sb, "Kernel32",
                new("HInstance", "Handle to a Kernel32 module instance (base virtual address where it loaded)"),
                new("HDevice", "Handle to a Kernel32 device"),
                new("HFile", "Handle to a Kernel32 file"));
        });

        Program.Generate(sb, "_Modules/Kernel32/Structs/Large/Generated.g.cs", "Kernel32 (Large structs)", static sb =>
        {
            StructTemplate.Generate(sb, "Kernel32",
                new(48, "VideoModeInformation", false,
                    """
                    Mapped from VIDEO_MODE_INFORMATION (WDK).
                    This is the standard return structure for video query IOCTLs.
                    """, null, null, null,
                    [
                        new(null, 0, "public", "uint", "Length", "48"),
                        new(null, 4, "public", "VideoDisplayMode", "ModeIndex"),
                        new(null, 8, "public", "uint", "VisScreenWidth"),
                        new(null, 12, "public", "uint", "VisScreenHeight"),
                        new(null, 16, "public", "uint", "BitsPerPlane"),
                        new(null, 20, "public", "uint", "NumberOfPlanes"),
                        new(null, 24, "public", "uint", "Frequency"),
                        new(null, 28, "public", "uint", "XMillimeter"),
                        new(null, 32, "public", "uint", "YMillimeter"),
                        new(null, 36, "public", "uint", "NumberOfButtons"),
                        new(null, 40, "public", "uint", "NumberOfPointerButtons"),
                        new(null, 44, "public", "Bool4", "Interlaced")
                    ],
                    null, null, null,
                    new(
                        """
                        return $"Res: {VisScreenWidth}x{VisScreenHeight} @ {Frequency}Hz";
                        """,
                        null,
                        null, null,
                        null, null)),

                new(40, "DriveLayoutGpt", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "Guid", "DiskId"),
                        new(null, 16, "public", "long", "StartingUsableOffset"),
                        new(null, 24, "public", "long", "UsableLength"),
                        new(null, 32, "public", "uint", "MaxPartitionCount")
                    ],
                    null, null, null),

                new(192, "DriveLayoutInformationEx", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "PartitionStyle", "PartitionStyle"),
                        new(null, 4, "public", "uint", "PartitionCount"),

                        new(null, 8, "public", "DriveLayoutMbr", "Mbr"),
                        new(null, 8, "public", "DriveLayoutGpt", "Gpt"),

                        new(null, 48, "public", "PartitionInformationEx", "FirstEntry")
                    ],
                    null, null, null),

                new(40, "DriveLayoutMbr", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "uint", "Signature"),
                        new(null, 4, "public", "uint", "CheckSum")
                    ],
                    [
                        new(null, "public", "uint", "SignatureConst", "0xAA55")
                    ], null, null),

                new(144, "PartitionInformationEx", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "PartitionStyle", "PartitionStyle"),
                        new(null, 8, "public", "long", "StartingOffset"),
                        new(null, 16, "public", "long", "PartitionLength"),
                        new(null, 24, "public", "uint", "PartitionNumber"),
                        new(null, 28, "public", "Bool1", "RewritePartition"),

                        new(null, 32, "public", "PartitionInformationMbr", "Mbr"),
                        new(null, 32, "public", "PartitionInformationGpt", "Gpt")
                    ],
                    null, null, null),

                new(112, "PartitionInformationGpt", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "Guid", "PartitionType"),
                        new(null, 16, "public", "Guid", "PartitionId"),
                        new(null, 32, "public", "PartitionAttributes", "Attributes"),
                        new(null, 40, "public", "fixed char", "Name[36]")
                    ],
                    null, null, null),

                new(112, "PartitionInformationMbr", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "PartitionType", "PartitionType"),
                        new(null, 1, "public", "Bool1", "BootIndicator"),
                        new(null, 2, "public", "Bool1", "RecognizedPartition"),
                        new(null, 4, "public", "uint", "HiddenSectors"),
                        new(null, 8, "public", "Guid", "PartitionId")
                    ],
                    null, null, null));
        });

        Program.Generate(sb, "_Modules/Kernel32/Structs/Primitives/Generated.g.cs", "Kernel32 (Primitive structs)", static sb =>
        {
            StructTemplate.Generate(sb, "Kernel32",
                new StructTemplate.Struct(4, "DeviceIoControlCode", true,
                    null, ["System.Numerics"], null,
                    [
                        "IEqualityOperators<DeviceIoControlCode, uint, bool>",
                        "IEquatable<uint>",
                        "IExplicitCast<DeviceIoControlCode, uint>"
                    ],
                    [
                        new(null, 0, "public readonly", "uint", "Raw", "0"),
                        new(null, 2, "public readonly", "DeviceType", "DeviceType")
                    ],
                    null,
                    [
                        new("Function code (12 bits: bits 2-13)",
                            "public readonly", "uint", "Function",
                            null,
                            """
                            return (Raw >> 2) & 0x0FFF;
                            """,
                            null, null, false,
                            null, null, null,
                            [Const.InlinedTrim],
                            null),
                        new("Access check flags (2 bits: bits 14-15)",
                            "public readonly", "DeviceAccess", "Access",
                            null,
                            """
                            return (DeviceAccess)((Raw >> 14) & 0x03);
                            """,
                            null, null, false,
                            null, null, null,
                            [Const.InlinedTrim],
                            null),
                        new("Buffering method (2 bits: bits 0-1)",
                            "public readonly", "Method", "Method",
                            null,
                            """
                            return (Method)(Raw & 0x03);
                            """,
                            null, null, false,
                            null, null, null,
                            [Const.InlinedTrim],
                            null)
                    ],
                    [
                        // --- Constructors ---

                        new(null, "public", "DeviceIoControlCode", string.Empty,
                            null, ["uint raw"], [": this()"],
                            """
                            Raw = raw;
                            """,
                            [Const.InlinedTrim]),
                        new(
                            """
                            Manually construct a control code (equivalent to CTL_CODE macro).
                            """, "public", "DeviceIoControlCode", string.Empty,
                            null, ["DeviceType deviceType", "uint function", "Method method", "DeviceAccess access"], [
                                """
                                : this(((uint)deviceType << 16)
                                    | ((uint)access << 14)
                                    | (function << 2)
                                    | (uint)method)
                                """],
                            string.Empty,
                            [Const.InlinedTrim]),

                        // --- Functions ---

                        new(null, "public readonly", "bool", "Equals",
                            null, ["uint other"], null,
                            """
                            return this == other;
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public static", "bool operator", "==",
                            null, ["DeviceIoControlCode a", "uint b"], null,
                            """
                            return a.Raw == b;
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public static", "bool operator", "!=",
                            null, ["DeviceIoControlCode a", "uint b"], null,
                            """
                            return a.Raw != b;
                            """,
                            [Const.InlinedTrim]),

                        new(null, "public readonly override",
                            "int", "GetHashCode",
                            null, null, null,
                            """
                            return Raw.GetHashCode();
                            """,
                            [Const.InlinedTrim]),

                        // --- Operators ---

                        new(null, "public static explicit operator", "uint", string.Empty,
                            null, ["DeviceIoControlCode code"], null,
                            """
                            return code.Raw;
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "DeviceIoControlCode", string.Empty,
                            null, ["uint raw"], null,
                            """
                            return new(raw);
                            """,
                            [Const.InlinedTrim]),
                    ],
                    new(
                        """
                        return $"0x{Raw:X8} [Device: {DeviceType}, Function: {Function}, Access: {Access}, Method: {Method}]";
                        """,
                        null, null,
                        null, null,
                        null)));
        });

        Program.Generate(sb, "_Modules/Kernel32/Structs/Small/Generated.g.cs", "Kernel32 (Small structs)", static sb =>
        {
            StructTemplate.Generate(sb, "Kernel32",
                new(20, "DiskFormatParameters", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "MediaType", "MediaType"),
                        new(null, 4, "public", "uint", "StartCylinderNumber"),
                        new(null, 8, "public", "uint", "EndCylinderNumber"),
                        new(null, 12, "public", "uint", "StartHeadNumber"),
                        new(null, 16, "public", "uint", "EndHeadNumber")
                    ],
                    null, null, null),

                new(24, "DiskGeometry", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "long", "Cylinders"),
                        new(null, 8, "public", "MediaType", "MediaType"),
                        new(null, 12, "public", "uint", "TracksPerCylinder"),
                        new(null, 16, "public", "uint", "SectorsPerTrack"),
                        new(null, 20, "public", "uint", "BytesPerSector")
                    ],
                    null, null, null),

                new(32, "DiskGeometryEx", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "DiskGeometry", "Geometry"),
                        new(null, 24, "public", "long", "DiskSize")
                    ],
                    null, null, null),

                new(16, "FsFileZeroDataInformation", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "long", "FileOffset"),
                        new(null, 8, "public", "long", "BeyondFinalZero")
                    ],
                    null, null, null),

                new(32, "FsMoveFileParams", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "void*", "FileHandle"),
                        new(null, 8, "public", "long", "StartingVcn"),
                        new(null, 16, "public", "long", "StartingLcn"),
                        new(null, 24, "public", "uint", "ClusterCount")
                    ],
                    null, null, null),

                new(16, "FsReparseDataBuffer", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "FsReparseDataBufferHeader", "Header"),

                        // --- UNION 1: Symbolic Link Buffer ---
                        new(null, 8, "public", "ushort", "SymlinkSubstituteNameOffset"),
                        new(null, 10, "public", "ushort", "SymlinkSubstituteNameLength"),
                        new(null, 12, "public", "ushort", "SymlinkPrintNameOffset"),
                        new(null, 14, "public", "ushort", "SymlinkPrintNameLength"),
                        new(null, 16, "public", "uint", "SymlinkFlags"),
                        // (Path buffer physically starts at offset 20)

                        // --- UNION 2: Mount Point (Junction) Buffer ---
                        new(null, 8, "public", "ushort", "MountPointSubstituteNameOffset"),
                        new(null, 10, "public", "ushort", "MountPointSubstituteNameLength"),
                        new(null, 12, "public", "ushort", "MountPointPrintNameOffset"),
                        new(null, 14, "public", "ushort", "MountPointPrintNameLength")
                        // (Path buffer physiccaly starts at offset 16)
                    ],
                    null, null, null,
                    new(
                        """
                        return Header.ToString();
                        """,
                        null, null,
                        null, null,
                        null)),

                new(8, "FsReparseDataBufferHeader", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "FsReparseTag", "ReparseTag"),
                        new(null, 4, "public", "ushort", "ReparseDataLength"),
                    ],
                    null, null, null,
                    new(
                        """
                        return $"ReparseTag: 0x{ReparseTag:X8}\r\nReparseDataLength: {ReparseDataLength}";
                        """,
                        null, null,
                        null, null,
                        null)),

                //NOTE: The strings are located dynamically based on these offsets inside the VRA
                new(24, "MountMgrMountPoint", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "uint", "SymbolicLinkNameOffset"),
                        new(null, 4, "public", "ushort", "SymbolicLinkNameLength"),
                        new(null, 8, "public", "uint", "UniqueIdOffset"),
                        new(null, 12, "public", "ushort", "UniqueIdLength"),
                        new(null, 16, "public", "uint", "DeviceNameOffset"),
                        new(null, 20, "public", "ushort", "DeviceNameLength"),
                    ],
                    null, null, null,
                    new(
                        $$"""
                        return
                            ${{"\"\"\""}}
                            SymbolicLinkName: {SymbolicLinkNameLength} at {SymbolicLinkNameOffset}
                            UniqueId: {UniqueIdLength} at {UniqueIdOffset}
                            DeviceName: {DeviceNameLength} at {DeviceNameOffset}
                            {{"\"\"\""}};
                        """,
                        null, null,
                        null, null,
                        null)),

                new(32, "PartitionInformation", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "long", "StartingOffset"),
                        new(null, 8, "public", "long", "PartitionLength"),
                        new(null, 16, "public", "uint", "HiddenSectors"),
                        new(null, 20, "public", "uint", "PartitionNumber"),
                        new(null, 24, "public", "PartitionType", "PartitionType"),
                        new(null, 25, "public", "Bool1", "BootIndicator"),
                        new(null, 26, "public", "Bool1", "RecognizedPartition"),
                        new(null, 27, "public", "Bool1", "RewritePartition")
                    ],
                    null, null, null),

                new(12, "StorageDeviceNumber", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "DeviceType", "DeviceType"),
                        new(null, 4, "public", "uint", "DeviceNumber"),
                        new(null, 8, "public", "uint", "PartitionNumber")
                    ],
                    null, null, null),

                new(8, "StorageHotplugInfo", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "uint", "Size", "8"),
                        new(null, 4, "public", "Bool1", "MediaRemovable"),
                        new(null, 5, "public", "Bool1", "MediaHotplug"),
                        new(null, 6, "public", "Bool1", "DeviceHotplug"),
                        new(null, 7, "public", "Bool1", "WriteCacheEnableOverride")
                    ],
                    null, null, null),

                new(12, "StoragePropertyQuery", false,
                    null, null, null, null,
                    [
                        new(null, 0, "public", "StoragePropertyId", "PropertyId"),
                        new(null, 4, "public", "StorageQueryType", "QueryType"),
                        new(null, 8, "public", "byte", "AdditionalParameters")
                    ],
                    null, null, null));
        });
    }
}