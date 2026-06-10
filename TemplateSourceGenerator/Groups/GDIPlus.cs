using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class GDIPlus
{
    public static void Generate(StringBuilder sb)
    {
        Program.Generate(sb, "_Modules/GDIPlus/Handles/RootHandles.g.cs", "GDI+ (Root)", static (sb) =>
        {
            HandleTemplate.Generate(sb, "GDIPlus",
                new("HSessionToken", "Handle to a GDI+ session token"),
                new("HPen", "Handle to a GDI+ pen"),
                new("HPath", "Handle to a GDI+ path"),
                new("HMatrix", "Handle to a GDI+ matrix"),
                new("HGraphics", "Handle to a GDI+ graphics"),
                new("HImage", "Handle to a GDI+ image"),
                new("HStringFormat", "Handle to a GDI+ string format"),
                new("HBrush", "Handle to a GDI+ brush"),
                new("HFontFamily", "Handle to a GDI+ font family"),
                new("HFontCollection", "Handle to a GDI+ font collection"),
                new("HFont", "Handle to a GDI+ font"));
        });

        Program.Generate(sb, "_Modules/GDIPlus/Handles/ImageHandles.g.cs", "GDI+ (HImage derived)", static (sb) =>
        {
            HandleTemplate.Generate(sb, "GDIPlus",
                new HandleTemplate.Handle("HBitmap", "Handle to a GDI+ bitmap"));
        });

        Program.Generate(sb, "_Modules/GDIPlus/Structs/Primitives/Generated.g.cs", "GDI+ (Primitive structs)", static (sb) =>
        {
            StructTemplate.Generate(sb, "GDIPlus",
                new(4, "GraphicsContainerState", true,
                null, null, null,
                ["IExplicitCast<GraphicsContainerState, uint>"],
                [
                    new(null, 0, "public readonly", "uint", "Raw", "0")
                ],
                null,
                [
                    new(null, "public static", "GraphicsContainerState",
                    "Invalid", null, "return new(0);",
                    null, null, false,
                    null, null, null,
                    [Const.InlinedTrim], null)
                ],
                [
                    // --- Constructors ---

                    new(null, "public", "GraphicsContainerState", string.Empty,
                        null, ["uint raw"], [": this()"],
                        """
                        Raw = raw;
                        """, [Const.InlinedTrim]),

                    // --- Operators ---

                    new(null, "public static explicit operator", "uint",
                    string.Empty, null, ["GraphicsContainerState state"], null,
                        """
                        return state.Raw;
                        """, [Const.InlinedTrim]),
                    new(null, "public static explicit operator", "GraphicsContainerState",
                    string.Empty, null, ["uint raw"], null,
                        """
                        return new(raw);
                        """, [Const.InlinedTrim]),
                ]),
                
                new(4, "Color", true,
                    null, ["System.Numerics"], null,
                    [
                        "IEqualityOperators<Color, uint, bool>", "IEquatable<uint>", "IExplicitCast<Color, uint>",
                        "IEqualityOperators<Color, GDI32.Color, bool>", "IEquatable<GDI32.Color>", "IExplicitCast<Color, GDI32.Color>"
                    ],
                    [
                        new(null, 0, "public readonly", "uint", "Argb", "0"),
                        new(null, 0, "public readonly", "byte", "B"),
                        new(null, 1, "public readonly", "byte", "G"),
                        new(null, 2, "public readonly", "byte", "R"),
                        new(null, 3, "public readonly", "byte", "A")
                    ],
                    null,
                    null,
                    [
                        // --- Constructors ---

                        new(null, "public", "Color", string.Empty,
                        null, ["uint argb"],
                        [": this()"], "Argb = argb;", [Const.InlinedTrim]),
                        new(null, "public", "Color", string.Empty,
                        null, ["byte r", "byte g", "byte b", "byte a = 255"],
                        [
                            """
                            : this (
                                b | ((uint)g << 8) | ((uint)r << 16) | ((uint)a << 24))
                            """
                            ], string.Empty, [Const.InlinedTrim]),

                        // --- Functions ---

                        new(null, "public static", "Color", "FromAbgr",
                            null, ["uint abgr"], null,
                            """
                            return new((abgr & 0xFF00FF00) | ((abgr & 0x00FF0000) >> 16) | ((abgr & 0x000000FF) << 16));
                            """, [Const.InlinedTrim]),
                        new(null, "public static", "Color", "FromRgba",
                            null, ["uint rgba"], null,
                            """
                            return new((rgba >> 8) | (rgba << 24));
                            """, [Const.InlinedTrim]),
                        new(null, "public static", "Color", "FromBgra",
                            null, ["uint bgra"], null,
                            """
                            return new((bgra << 24) | (bgra >> 8));
                            """, [Const.InlinedTrim]),

                        new(null, "public readonly", "uint", "ToAbgr",
                            null, null, null,
                            """
                            return (Argb & 0xFF00FF00) | ((Argb & 0x00FF0000) >> 16) | ((Argb & 0x000000FF) << 16);
                            """, [Const.InlinedTrim]),
                        new(null, "public readonly", "uint", "ToRgba",
                            null, null, null,
                            """
                            return (Argb << 8) | A;
                            """, [Const.InlinedTrim]),
                        new(null, "public readonly", "uint", "ToBgra",
                            null, null, null,
                            """
                            return ((uint)B << 24) | ((uint)G << 16) | ((uint)R << 8) | A;
                            """, [Const.InlinedTrim]),

                        new(null, "public readonly", "bool", "Equals",
                            null, ["uint other"], null,
                            """
                            return this == other;
                            """, [Const.InlinedTrim]),
                        new(null, "public readonly", "bool", "Equals",
                            null, ["GDI32.Color other"], null,
                            """
                            return this == other;
                            """, [Const.InlinedTrim]),

                        // --- Operators ---

                        new(null, "public static bool", "operator", "==",
                            null, ["Color left", "uint right"], null,
                            """
                            return left.Argb == right;
                            """, [Const.InlinedTrim]),
                        new(null, "public static bool", "operator", "!=",
                            null, ["Color left", "uint right"], null,
                            """
                            return left.Argb != right;
                            """, [Const.InlinedTrim]),

                        new(null, "public static bool", "operator", "==",
                            null, ["Color left", "GDI32.Color right"], null,
                            """
                            return left.Argb == right.ToArgb();
                            """, [Const.InlinedTrim]),
                        new(null, "public static bool", "operator", "!=",
                            null, ["Color left", "GDI32.Color right"], null,
                            """
                            return left.Argb != right.ToArgb();
                            """, [Const.InlinedTrim]),

                        new(null, "public static explicit operator", "uint", string.Empty,
                            null, ["Color color"], null,
                            """
                            return color.Argb;
                            """, [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "Color", string.Empty,
                            null, ["uint argb"], null,
                            """
                            return new(argb);
                            """, [Const.InlinedTrim]),

                        new(null, "public static explicit operator", "GDI32.Color", string.Empty,
                            null, ["Color c"], null,
                            """
                            return new(c.R, c.G, c.B, c.A);
                            """, [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "Color", string.Empty,
                            null, ["GDI32.Color c"], null,
                            """
                            return new(c.R, c.G, c.B, c.A);
                            """, [Const.InlinedTrim])
                    ]),
                
                new(8, "PointF", true,
                    """
                    Defines the x- and y-coordinates of a point.
                    <remarks>
                    Floating-point 32-bit coordinates
                    </remarks>
                    """, ["System.Numerics"], null,
                    [
                        "IEqualityOperators<PointF, User32.Point, bool>", "IEquatable<User32.Point>", "IImplicitCastFrom<PointF, User32.Point>", "IExplicitCastTo<PointF, User32.Point>",
                        "IEqualityOperators<PointF, (float X, float Y), bool>", "IEquatable<(float X, float Y)>", "IExplicitCast<PointF, (float X, float Y)>",
                        "IEqualityOperators<PointF, (int X, int Y), bool>", "IEquatable<(int X, int Y)>", "IExplicitCast<PointF, (int X, int Y)>"
                    ],
                    [
                        new(null, 0, "public readonly", "float", "X"),
                        new(null, 4, "public readonly", "float", "Y")
                    ],
                    null,
                    null,
                    [
                        // --- Constructors ---

                        new(null, "public", "PointF", string.Empty,
                            null, null, null,
                            """
                            X = 0;
                            Y = 0;
                            """, [Const.InlinedTrim]),
                        new(null, "public", "PointF", string.Empty,
                            null, ["float x", "float y"], null,
                            """
                            X = x;
                            Y = y;
                            """, [Const.InlinedTrim]),

                        // --- Functions ---

                        new(null, "public readonly", "void", "Deconstruct",
                            null, ["out float x", "out float y"], null,
                            """
                            x = X;
                            y = Y;
                            """, [Const.InlinedTrim]),

                        new(null, "public readonly", "bool", "Equals",
                            null, ["User32.Point other"], null,
                            """
                            return this == other;
                            """, [Const.InlinedTrim]),
                        new(null, "public readonly", "bool", "Equals",
                            null, ["(float X, float Y) other"], null,
                            """
                            return this == other;
                            """, [Const.InlinedTrim]),
                        new(null, "public readonly", "bool", "Equals",
                            null, ["(int X, int Y) other"], null,
                            """
                            return this == other;
                            """, [Const.InlinedTrim]),

                        // --- Operators ---

                        new(null, "public static bool operator", string.Empty, "==",
                            null, ["PointF a", "User32.Point b"], null,
                            """
                            return a.X == b.X && a.Y == b.Y;
                            """, [Const.InlinedTrim]),
                        new(null, "public static bool operator", string.Empty, "!=",
                            null, ["PointF a", "User32.Point b"], null,
                            """
                            return a.X != b.X || a.Y != b.Y;
                            """, [Const.InlinedTrim]),

                        new(null, "public static bool operator", string.Empty, "==",
                            null, ["PointF a", "(float X, float Y) b"], null,
                            """
                            return a.X == b.X && a.Y == b.Y;
                            """, [Const.InlinedTrim]),
                        new(null, "public static bool operator", string.Empty, "!=",
                            null, ["PointF a", "(float X, float Y) b"], null,
                            """
                            return a.X != b.X || a.Y != b.Y;
                            """, [Const.InlinedTrim]),

                        new(null, "public static bool operator", string.Empty, "==",
                            null, ["PointF a", "(int X, int Y) b"], null,
                            """
                            return a.X == b.X && a.Y == b.Y;
                            """, [Const.InlinedTrim]),
                        new(null, "public static bool operator", string.Empty, "!=",
                            null, ["PointF a", "(int X, int Y) b"], null,
                            """
                            return a.X != b.X || a.Y != b.Y;
                            """, [Const.InlinedTrim]),

                        new(null, "public static implicit operator", "PointF", string.Empty,
                            null, ["User32.Point other"], null,
                            """
                            return new(other.X, other.Y);
                            """, [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "User32.Point", string.Empty,
                            null, ["PointF other"], null,
                            """
                            return new((int)other.X, (int)other.Y);
                            """, [Const.InlinedTrim]),

                        new(null, "public static explicit operator", "PointF", string.Empty,
                            null, ["(float X, float Y) other"], null,
                            """
                            return new(other.X, other.Y);
                            """, [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "(float X, float Y)", string.Empty,
                            null, ["PointF other"], null,
                            """
                            return (other.X, other.Y);
                            """, [Const.InlinedTrim]),

                        new(null, "public static explicit operator", "PointF", string.Empty,
                            null, ["(int X, int Y) other"], null,
                            """
                            return new(other.X, other.Y);
                            """, [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "(int X, int Y)", string.Empty,
                            null, ["PointF other"], null,
                            """
                            return ((int)other.X, (int)other.Y);
                            """, [Const.InlinedTrim])
                    ]));
        });

        Program.Generate(sb, "_Modules/GDIPlus/Structs/Small/Generated.g.cs", "GD+ (Small structs)", static (sb) =>
        {
            StructTemplate.Generate(sb, "GDIPlus",
                new(32, "RectF", true,
                    null, ["System.Numerics"], null,
                    [
                        "IEqualityOperators<RectF, User32.Rect, bool>", "IEquatable<User32.Rect>", "IImplicitCastFrom<RectF, User32.Rect>", "IExplicitCastTo<RectF, User32.Rect>",
                        "IEqualityOperators<RectF, (float X, float Y, float Width, float Height), bool>", "IEquatable<(float X, float Y, float Width, float Height)>", "IExplicitCast<RectF, (float X, float Y, float Width, float Height)>",
                        "IEqualityOperators<RectF, (int X, int Y, int Width, int Height), bool>", "IEquatable<(int X, int Y, int Width, int Height)>", "IExplicitCast<RectF, (int X, int Y, int Width, int Height)>"
                    ],
                    [
                        new(null, 0, "public readonly", "float", "X"),
                        new(null, 4, "public readonly", "float", "Y"),
                        new(null, 0, "public readonly", "PointF", "Location"),
                        new(null, 8, "public readonly", "float", "Width"),
                        new(null, 12, "public readonly", "float", "Height")
                    ],
                    null,
                    null,
                    [
                        // --- Constructors ---

                        new(null, "public", "RectF", string.Empty,
                            null, null, null,
                            """
                            X = 0;
                            Y = 0;
                            Width = 0;
                            Height = 0;
                            """, [Const.InlinedTrim]),
                        new(null, "public", "RectF", string.Empty,
                            null, ["float x", "float y", "float width", "float height"], null,
                            """
                            X = x;
                            Y = y;
                            Width = width;
                            Height = height;
                            """, [Const.InlinedTrim]),

                        // --- Functions ---

                        new(null, "public readonly", "void", "Deconstruct",
                            null, ["out float x", "out float y", "out float width", "out float height"], null,
                            """
                            x = X;
                            y = Y;
                            width = Width;
                            height = Height;
                            """, [Const.InlinedTrim]),
                        new(null, "public readonly", "void", "Deconstruct",
                            null, ["out PointF location", "out float width", "out float height"], null,
                            """
                            location = Location;
                            width = Width;
                            height = Height;
                            """, [Const.InlinedTrim]),

                        new(null, "public readonly", "void", "ToLBTR",
                            null, ["out float left", "out float bottom", "out float top", "out float right"], null,
                            """
                            left = X;
                            top = Y;
                            bottom = Y + Height;
                            right = X + Width;
                            """, [Const.InlinedTrim]),
                        new(null, "public static", "RectF", "FromLTBR",
                            null, ["float left", "float top", "float bottom", "float right"], null,
                            """
                            return new(left, top, bottom - top, right - left);
                            """, [Const.InlinedTrim]),

                        new(null, "public readonly", "bool", "Equals",
                            null, ["User32.Rect other"], null,
                            """
                            return this == other;
                            """, [Const.InlinedTrim]),
                        new(null, "public readonly", "bool", "Equals",
                            null, ["(float X, float Y, float Width, float Height) other"], null,
                            """
                            return this == other;
                            """, [Const.InlinedTrim]),
                        new(null, "public readonly", "bool", "Equals",
                            null, ["(int X, int Y, int Width, int Height) other"], null,
                            """
                            return this == other;
                            """, [Const.InlinedTrim]),

                        // --- Operators ---

                        new(null, "public static bool operator", string.Empty, "==",
                            null, ["RectF a", "User32.Rect b"], null,
                            """
                            return a.Location == b.Location && a.Width == b.Width && a.Height == b.Height;
                            """, [Const.InlinedTrim]),
                        new(null, "public static bool operator", string.Empty, "!=",
                            null, ["RectF a", "User32.Rect b"], null,
                            """
                            return a.Location != b.Location || a.Width != b.Width || a.Height != b.Height;
                            """, [Const.InlinedTrim]),

                        new(null, "public static bool operator", string.Empty, "==",
                            null, ["RectF a", "(float X, float Y, float Width, float Height) b"], null,
                            """
                            return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
                            """, [Const.InlinedTrim]),
                        new(null, "public static bool operator", string.Empty, "!=",
                            null, ["RectF a", "(float X, float Y, float Width, float Height) b"], null,
                            """
                            return a.X != b.X || a.Y != b.Y || a.Width != b.Width || a.Height != b.Height;
                            """, [Const.InlinedTrim]),

                        new(null, "public static bool operator", string.Empty, "==",
                            null, ["RectF a", "(int X, int Y, int Width, int Height) b"], null,
                            """
                            return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
                            """, [Const.InlinedTrim]),
                        new(null, "public static bool operator", string.Empty, "!=",
                            null, ["RectF a", "(int X, int Y, int Width, int Height) b"], null,
                            """
                            return a.X != b.X || a.Y != b.Y || a.Width != b.Width || a.Height != b.Height;
                            """, [Const.InlinedTrim]),

                        new(null, "public static implicit operator", "RectF", string.Empty,
                            null, ["User32.Rect other"], null,
                            """
                            return new(other.X, other.Y, other.Width, other.Height);
                            """, [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "User32.Rect", string.Empty,
                            null, ["RectF other"], null,
                            """
                            return new((int)other.X, (int)other.Y, (int)other.Width, (int)other.Height);
                            """, [Const.InlinedTrim]),

                        new(null, "public static explicit operator", "RectF", string.Empty,
                            null, ["(float X, float Y, float Width, float Height) other"], null,
                            """
                            return new(other.X, other.Y, other.Width, other.Height);
                            """, [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "(float X, float Y, float Width, float Height)", string.Empty,
                            null, ["RectF other"], null,
                            """
                            return (other.X, other.Y, other.Width, other.Height);
                            """, [Const.InlinedTrim]),

                        new(null, "public static explicit operator", "RectF", string.Empty,
                            null, ["(int X, int Y, int Width, int Height) other"], null,
                            """
                            return new(other.X, other.Y, other.Width, other.Height);
                            """, [Const.InlinedTrim]),
                        new(null, "public static explicit operator", "(int X, int Y, int Width, int Height)", string.Empty,
                            null, ["RectF other"], null,
                            """
                            return ((int)other.X, (int)other.Y, (int)other.Width, (int)other.Height);
                            """, [Const.InlinedTrim])
                    ],
                    new(null,
                    """
                    return a.Location == b.Location && a.Width == b.Width && a.Height == b.Height;
                    """,
                    """
                    return a.Location != b.Location && a.Width == b.Width && a.Height == b.Height;
                    """,
                    null, null,
                    """
                    Location = default;
                    Width = default;
                    Height = default;
                    """)),

                new(24, "StartupInput", false, null,
                    null, null, null,
                    [
                        new(null, 0, "public", "uint", "GdiplusVersion", "1"),
                        new(null, 8, "public", "delegate* unmanaged<DebugEventLevel, nint, void>", "DebugEventCallback", "null"),
                        new(null, 16, "public", "Bool4", "SuppressBackgroundThread", "false"),
                        new(null, 20, "public", "Bool4", "SuppressExternalCodecs", "false")
                    ],
                    null,
                    null,
                    null),

                new(16, "StartupOutput", false, null,
                    null, null, null,
                    [
                        new(null, 0, "public", "delegate* unmanaged<out nint, delegate* unmanaged<void>, Status>", "NotificationHook", "null"),
                        new(null, 8, "public", "delegate* unmanaged<nint, void>", "NotificationUnhook", "null"),
                    ],
                    null,
                    null,
                    null));
        });
    }
}