using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class GDI32
{
    public static void Generate(StringBuilder sb)
    {
        Console.WriteLineInfo("Starting generation for GDI32...");


        Program.Generate(sb, "_Modules/GDI32/Handles/RootHandles.g.cs", "GDI32 (Root)", static (sb) =>
        {
            HandleTemplate.Generate(sb, "GDI32",
                new("HDC", "Handle to a GDI32 Device Context"),
                new("HObj", "Handle to a GDI32 Object"));
        });
        
        Program.Generate(sb, "_Modules/GDI32/Handles/GdiObjectHandles.g.cs", "GDI32 (HObj derived)", static (sb) =>
        {
            HandleTemplate.Generate(sb, "GDI32",
                    new("HRegion", ["HObj"], "Handle to a GDI32 region object"),
                    new("HPen", ["HObj"], "Handle to a GDI32 pen object"),
                    new("HPalette", ["HObj"], "Handle to a GDI32 palette object"),
                    new("HFont", ["HObj"], "Handle to a GDI32 font object"),
                    new("HBrush", ["HObj"], "Handle to a GDI32 brush object"),
                    new("HBitmap", ["HObj"], "Handle to a GDI32 bitmap object"));
        });
        
        Program.Generate(sb, "_Modules/GDI32/Structs/Large/Generated.g.cs", "GDI32 (Large structs)", static (sb) =>
        {
            StructTemplate.Generate(sb, "GDI32",
                new StructTemplate.Struct(
                40, "BitmapInfo", false,
                [
                        new(null, 0, "public", "int", "biSize", "40"),
                        new(null, 4, "public", "int", "biWidth"),
                        new(null, 8, "public", "int", "biHeight"),
                        new(null, 12, "public", "short", "biPlanes"),
                        new(null, 14, "public", "BitCount", "biBitCount"),
                        new(null, 16, "public", "Compression", "biCompression"),
                        new(null, 20, "public", "int", "biSizeImage"),
                        new(null, 24, "public", "int", "biXPelsPerMeter"),
                        new(null, 28, "public", "int", "biYPelsPerMeter"),
                        new(null, 32, "public", "int", "biClrUsed"),
                        new(null, 36, "public", "int", "biClrImportant")
                    ]));
        });
        
        Program.Generate(sb, "_Modules/GDI32/Structs/Primitives/Generated.g.cs", "GDI32 (Primitive structs)", static (sb) =>
        {
            StructTemplate.Generate(sb, "GDI32",
                new StructTemplate.Struct(
                    4, "Color", true,
                    null,
                    null,
                    null,
                    ["IExplicitCast<Color, uint>"],
                    [
                        new("Raw 32-bit unsigned number underlying this Color",
                            0,
                            "public readonly", "uint", "Value", "0"),

                        new("Raw 8-bit unsigned number as Red-channel of this Color",
                            0,
                            "public readonly", "byte", "R"),
                        new("Raw 8-bit unsigned number as Green-channel of this Color",
                            1,
                            "public readonly", "byte", "G"),
                        new("Raw 8-bit unsigned number as Blue-channel of this Color",
                            2,
                            "public readonly", "byte", "B"),
                        new("Raw 8-bit unsigned number as Alpha-channel of this Color",
                            3,
                            "public readonly", "byte", "A")
            ],
        null,
        null,
        [
            // --- Constructors ---
            new(null, "public", string.Empty, "Color",
                            null, ["uint value"],
                            [
                                ": this()"
                                ],
                            "Value = value;", [Const.InlinedTrim]),
                        new(null, "public", string.Empty, "Color",
                            null, ["byte r", "byte g", "byte b"],
                            [
                                ": this(r | ((uint)g << 8) | ((uint)b << 16))"
                                ],
                            string.Empty, [Const.InlinedTrim]),
                        new(null, "public", string.Empty, "Color",
                            null, ["byte r", "byte g", "byte b", "byte a"],
                            [
                                ": this(r | ((uint)g << 8) | ((uint)b << 16) | ((uint)a << 24))"
                                ],
                            string.Empty, [Const.InlinedTrim]),
                        // --- Functions ---
                        new(null, "public static", "Color", "FromBgr",
                            null, ["uint value"], null,
                            """
                            return new(value);
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public static", "Color", "FromRgb",
                            null, ["uint value"], null,
                            """
                            return new(
                                ((value >> 16) & 0xFF)
                                | (value & 0x00FF00)
                                | ((value & 0xFF) << 16)
                                | 0xFF000000);
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public static", "Color", "FromRgba",
                            null, ["uint value"], null,
                            """
                            return new(
                                (value >> 24)
                                | ((value >> 8) & 0xFF00)
                                | ((value << 8) & 0xFF0000)
                                | (value << 24));
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public static", "Color", "FromArgb",
                            null, ["uint value"], null,
                            """
                            return new(
                                ((value >> 16) & 0xFF)
                                | (value & 0xFF00)
                                | ((value & 0xFF) << 16)
                                | (value & 0xFF000000));
                            """,
                            [Const.InlinedTrim]),

                        new(null, "public readonly", "uint", "ToBgr",
                            null, null, null,
                            """
                            return Value;
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public readonly", "uint", "ToRgb",
                            null, null, null,
                            """
                            return (uint)R << 24 | (uint)G << 16 | (uint)B << 8;
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public readonly", "uint", "ToRgba",
                            null, null, null,
                            """
                            return (uint)R << 24 | (uint)G << 16 | (uint)B | A;
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public readonly", "uint", "ToArgb",
                            null, null, null,
                            """
                            return (uint)A << 24 | (uint)R << 16 | (uint)G << 8 | B;
                            """,
                            [Const.InlinedTrim]),

                        // --- Operators ---
                        new(null, "public static explicit operator", "uint", string.Empty,
                            null, ["Color gdic"], null,
                            """
                            return gdic.Value;
                            """,
                            [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "Color", string.Empty,
                            null, ["uint raw"], null,
                            """
                            return new(raw);
                            """,
                            [Const.InlinedTrim])
            ]));
        });
        
        Program.Generate(sb, "_Modules/GDI32/Structs/Small/Generated.g.cs", "GDI32 (Small structs)", static (sb) =>
        {
            StructTemplate.Generate(sb, "GDI32",
                new StructTemplate.Struct(
                    32, "Bitmap", false,
                    [
                        new(null, 0, "public", "int", "bmType"),
                        new(null, 4, "public", "int", "bmWidth"),
                        new(null, 8, "public", "int", "bmHeight"),
                        new(null, 12, "public", "int", "bmWidthBytes"),
                        new(null, 16, "public", "ushort", "bmPlanes"),
                        new(null, 18, "public", "BitDepth", "bmBitsPixel"),
                        new(null, 24, "public", "void*", "bmBits")
                ],
        null,
        null,
        [
                    new StructTemplate.Function(
                            "Returns a Span of the actual pixel data, not the struct metadata.",
                            "public readonly", "Span<byte>", "GetPixelData",
                            null, null, null,
                            "return bmBits is null ? [] : new Span<byte>(bmBits, bmHeight * bmWidthBytes);",
                            [Const.InlinedTrim])
                ]));
            });


        Console.WriteLineSuccess("Generation done and saved for GDI32");
    }
}