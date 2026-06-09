using System.Text;

namespace TemplateSourceGenerator.Templates;

internal static class Handle16Template
{
    public static readonly string[]
        DefaultUsings =
        [
            "System.Diagnostics",
            "System.Diagnostics.CodeAnalysis",
            "System.Runtime.CompilerServices",
            "System.Runtime.InteropServices",
            "TypedWinAPI.Contracts",
            "TypedWinAPI.Contracts.Ptr"
        ],
        DefaultAttributes =
        [
            "StructLayout(LayoutKind.Explicit, Size = 2)",
            "DebuggerDisplay(\"{ToString(),nq}\")",
            "DebuggerStepThrough",
            "SkipLocalsInit"
        ];

    private static void GenerateDefinition(StringBuilder sb, in Handle16 h)
    {
        static void Attributes(StringBuilder sb, in Handle16 h)
        {
            sb.AppendLine("[");
            sb.AppendLine("\t// --- Default attributes ---");
            for (int i = 0, last = DefaultAttributes.Length - 1; i < DefaultAttributes.Length; i++)
            {
                sb.Append($"\t{DefaultAttributes[i]}");
                if (i != last)
                    sb.AppendLine(",");
            }
            if (h.Attributes is not null)
            {
                sb.AppendLine(",");
                sb.AppendLine("// --- Custom attributes ---");
                for (int i = 0, last = h.Attributes.Length - 1; i < h.Attributes.Length; i++)
                {
                    sb.Append($"\t{h.Attributes[i]}");
                    if (i != last)
                        sb.AppendLine(",");
                }
            }
            sb.AppendLine();
            sb.AppendLine("]");
        }
        static void Contracts(StringBuilder sb, in Handle16 h)
        {
            sb.AppendLine(
            $"""
                // --- Default contracts ---
                IHandle16TSelfContracts<{h.ClassName}>,
            """);
            if (h.BaseClassNames is not null)
                foreach (var baseName in h.BaseClassNames)
                    sb.AppendLine($"\tIHandle16TBaseHandle16Contracts<{h.ClassName}, {baseName}>,");
            if (h.Contracts is not null)
                sb.AppendLine(
                $"""
                    // --- Custom contracts ---
                    {string.Join(",\r\n\t", h.Contracts)},
                    // --- Default contracts ---
                 """);
            sb.AppendLine(
            $"""
                IHandle16TBaseHandle16Contracts<{h.ClassName}, Handle16>,
                IHandle16Contracts<{h.ClassName}>
            """);
        }

        if (h.Comment is not null)
        {
            sb.AppendLine(
            $"""
            /// <summary>
            /// {h.Comment.Replace("\r\n", "\r\n/// ")}
            /// </summary>
            """);
        }
        Attributes(sb, in h);
        sb.AppendLine($"public unsafe readonly struct {h.ClassName} :");
        Contracts(sb, in h);
        sb.AppendLine("{");
    }
    private static void GenerateBody(StringBuilder sb, in Handle16 h)
    {
        static void Construct(StringBuilder sb, in Handle16 h)
        {
            sb.AppendLine(
            """
                #region Construct

            """);
            {
                if (h.BaseClassNames is not null)
                {
                    sb.AppendLine(
                    $"""
                        {Const.Inlined}
                        public {h.ClassName}() => {h.BaseClassNames[0]}Value = default;

                    """);
                    foreach (var baseName in h.BaseClassNames)
                        sb.AppendLine(
                        $"""
                            {Const.Inlined}
                            public {h.ClassName}({baseName} h) => {baseName}Value = h;
                        """);
                    sb.AppendLine();
                }
                else
                    sb.AppendLine(
                    $"""
                        {Const.Inlined}
                        public {h.ClassName}() => Handle16Value = default;
                    """);

                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public {h.ClassName}(Handle16 h) => Handle16Value = h;
                    {Const.Inlined}
                    public {h.ClassName}(void* ptr) => PointerValue = ptr;
                    {Const.Inlined}
                    public {h.ClassName}(ushort unsig) => UnsignedValue = unsig;
                    {Const.Inlined}
                    public {h.ClassName}(short sig) => SignedValue = sig;
                """);
            }
            sb.AppendLine(
            """

                #endregion
            """);
        }
        static void Fields(StringBuilder sb, in Handle16 h)
        {
            sb.AppendLine(
            """
                #region Fields

            """);
            {
                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                        sb.AppendLine($"\t[FieldOffset(0)] public readonly {baseName} {baseName}Value;");

                sb.AppendLine(
                """
                    [FieldOffset(0)] public readonly Handle16 Handle16Value;
                    [FieldOffset(0)] public readonly void* PointerValue;
                    [FieldOffset(0)] public readonly ushort UnsignedValue;
                    [FieldOffset(0)] public readonly short SignedValue;
                """);
            }
            sb.AppendLine(
            """

                #endregion
            """);
        }
        static void Math(StringBuilder sb, in Handle16 h)
        {
            static void _BitOps(StringBuilder sb, in Handle16 h)
            {
                static void __Handle16s(StringBuilder sb, in Handle16 h)
                {
                    if (h.BaseClassNames is not null)
                    {
                        sb.AppendLine(
                        $"""
                            {Const.Inlined}
                            public static {h.ClassName} operator <<({h.ClassName} a, int shift) => ({h.ClassName})(a.{h.BaseClassNames[0]}Value << shift);
                            {Const.Inlined}
                            public static {h.ClassName} operator >>({h.ClassName} a, int shift) => ({h.ClassName})(a.{h.BaseClassNames[0]}Value >> shift);
                            {Const.Inlined}
                            public static {h.ClassName} operator >>>({h.ClassName} a, int shift) => ({h.ClassName})(a.{h.BaseClassNames[0]}Value >>> shift);
                        """);

                        foreach (var baseName in h.BaseClassNames)
                            sb.AppendLine(
                            $"""

                                {Const.Inlined}
                                public static {h.ClassName} operator &({h.ClassName} a, {baseName} b) => ({h.ClassName})(a.{baseName}Value & b);
                                {Const.Inlined}
                                public static {h.ClassName} operator |({h.ClassName} a, {baseName} b) => ({h.ClassName})(a.{baseName}Value | b);
                                {Const.Inlined}
                                public static {h.ClassName} operator ^({h.ClassName} a, {baseName} b) => ({h.ClassName})(a.{baseName}Value ^ b);
                            """);
                    }
                    else
                        sb.AppendLine(
                        $"""
                            {Const.Inlined}
                            public static {h.ClassName} operator <<({h.ClassName} a, int shift) => ({h.ClassName})(ushort)(a.Handle16Value << shift);
                            {Const.Inlined}
                            public static {h.ClassName} operator >>({h.ClassName} a, int shift) => ({h.ClassName})(ushort)(a.Handle16Value >> shift);
                            {Const.Inlined}
                            public static {h.ClassName} operator >>>({h.ClassName} a, int shift) => ({h.ClassName})(ushort)(a.Handle16Value >>> shift);
                        """);

                    sb.AppendLine(
                    $"""

                        {Const.Inlined}
                        public static {h.ClassName} operator &({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(ushort)(a.UnsignedValue & b.UnsignedValue);
                        {Const.Inlined}
                        public static {h.ClassName} operator |({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(ushort)(a.UnsignedValue | b.UnsignedValue);
                        {Const.Inlined}
                        public static {h.ClassName} operator ^({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(ushort)(a.UnsignedValue ^ b.UnsignedValue);
                        {Const.Inlined}
                        public static {h.ClassName} operator ~({h.ClassName} a) => ({h.ClassName})(ushort)~a.UnsignedValue;
                    """);
                }

                __Handle16s(sb, in h);
                sb.AppendLine();
                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public static {h.ClassName} operator &({h.ClassName} a, Handle16 b) => ({h.ClassName})(a.Handle16Value & b);
                    {Const.Inlined}
                    public static {h.ClassName} operator |({h.ClassName} a, Handle16 b) => ({h.ClassName})(a.Handle16Value | b);
                    {Const.Inlined}
                    public static {h.ClassName} operator ^({h.ClassName} a, Handle16 b) => ({h.ClassName})(a.Handle16Value ^ b);

                    {Const.Inlined}
                    public static {h.ClassName} operator &({h.ClassName} a, ushort b) => ({h.ClassName})(ushort)(a.UnsignedValue & b);
                    {Const.Inlined}
                    public static {h.ClassName} operator |({h.ClassName} a, ushort b) => ({h.ClassName})(ushort)(a.UnsignedValue | b);
                    {Const.Inlined}
                    public static {h.ClassName} operator ^({h.ClassName} a, ushort b) => ({h.ClassName})(ushort)(a.UnsignedValue ^ b);

                    {Const.Inlined}
                    public static {h.ClassName} operator &({h.ClassName} a, short b) => ({h.ClassName})(short)(a.SignedValue & b);
                    {Const.Inlined}
                    public static {h.ClassName} operator |({h.ClassName} a, short b) => ({h.ClassName})(short)(a.SignedValue | b);
                    {Const.Inlined}
                    public static {h.ClassName} operator ^({h.ClassName} a, short b) => ({h.ClassName})(short)(a.SignedValue ^ b);

                    {Const.Inlined}
                    public static {h.ClassName} operator &({h.ClassName} a, void* b) => ({h.ClassName})(ushort)(a.UnsignedValue & (ushort)b);
                    {Const.Inlined}
                    public static {h.ClassName} operator |({h.ClassName} a, void* b) => ({h.ClassName})(ushort)(a.UnsignedValue | (ushort)b);
                    {Const.Inlined}
                    public static {h.ClassName} operator ^({h.ClassName} a, void* b) => ({h.ClassName})(ushort)(a.UnsignedValue ^ (ushort)b);
                """);
            }

            sb.AppendLine(
            """
                #region Math
            
            """);
            sb.AppendLine(
            $$"""
                public static {{h.ClassName}} MinValue
                {
                    {{Const.Inlined}}
                    get => {{h.MathConsts.MinValue}};
                }

                public static {{h.ClassName}} MaxValue
                {
                    {{Const.Inlined}}
                    get => {{h.MathConsts.MaxValue}};
                }

                public static {{h.ClassName}} Zero
                {
                    {{Const.Inlined}}
                    get => {{h.MathConsts.Zero}};
                }
            """);
            sb.AppendLine();
            _BitOps(sb, in h);
            sb.AppendLine(
            """

                #endregion
            """);
        }
        static void EqualityAndComparability(StringBuilder sb, in Handle16 h)
        {
            static void _Equals(StringBuilder sb, in Handle16 h)
            {
                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public readonly override bool Equals([NotNullWhen(true)] object? obj)
                        => obj is {h.ClassName} other ? this == other
                """);
                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                        sb.AppendLine($"\t\t\t: obj is {baseName} @{baseName} ? this == @{baseName}");
                sb.AppendLine(
                $"""
                                : obj is Handle16 h ? this == h
                                    : obj is ushort unsig ? this == unsig
                                        : obj is short sig && this == sig;


                """);

                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                    {
                        sb.AppendLine(
                        $"""
                            {Const.Inlined}
                            public readonly bool Equals({baseName} other) => this == other;

                        """);
                    }

                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public readonly bool Equals({h.ClassName} other) => this == other;

                    {Const.Inlined}
                    public readonly bool Equals(Handle16 other) => this == other;
                    {Const.Inlined}
                    public readonly bool Equals(ushort other) => this == other;
                    {Const.Inlined}
                    public readonly bool Equals(short other) => this == other;
                    {Const.Inlined}
                    public readonly bool Equals(void* other) => this == other;
                """);
            }
            static void _CompareTo(StringBuilder sb, in Handle16 h)
            {
                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public readonly int CompareTo([NotNullWhen(true)] object? obj)
                        => obj is {h.ClassName} other ? CompareTo(other)
                """);
                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                        sb.AppendLine($"\t\t\t: obj is {baseName} @{baseName} ? CompareTo(@{baseName})");
                sb.AppendLine(
                $"""
                                : obj is Handle16 h ? CompareTo(h)
                                    : obj is ushort unsig ? CompareTo(unsig)
                                        : obj is short sig ? CompareTo(sig) : 0;

                """);

                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                        sb.AppendLine(
                        $"""
                            {Const.Inlined}
                            public readonly int CompareTo({baseName} other) => {baseName}Value.CompareTo(other);

                        """);

                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public readonly int CompareTo({h.ClassName} other) => {h.EqualityLogic._CompareTo};

                    {Const.Inlined}
                    public readonly int CompareTo(Handle16 other) => Handle16Value.CompareTo(other);
                    {Const.Inlined}
                    public readonly int CompareTo(ushort other) => UnsignedValue.CompareTo(other);
                    {Const.Inlined}
                    public readonly int CompareTo(short other) => SignedValue.CompareTo(other);
                    {Const.Inlined}
                    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((ushort)other);
                """);
            }
            static void _Operators(StringBuilder sb, in Handle16 h)
            {
                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public static bool operator ==({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.Equal};
                    {Const.Inlined}
                    public static bool operator !=({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.NonEqual};

                    {Const.Inlined}
                    public static bool operator <({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.Less};
                    {Const.Inlined}
                    public static bool operator >({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.More};

                    {Const.Inlined}
                    public static bool operator <=({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.LessOrEqual};
                    {Const.Inlined}
                    public static bool operator >=({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.MoreOrEqual};

                """);
                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                        sb.AppendLine(
                        $"""
                            {Const.Inlined}
                            public static bool operator ==({h.ClassName} a, {baseName} b) => a.{baseName}Value == b;
                            {Const.Inlined}
                            public static bool operator !=({h.ClassName} a, {baseName} b) => a.{baseName}Value != b;

                            {Const.Inlined}
                            public static bool operator <({h.ClassName} a, {baseName} b) => a.{baseName}Value < b;
                            {Const.Inlined}
                            public static bool operator >({h.ClassName} a, {baseName} b) => a.{baseName}Value > b;

                            {Const.Inlined}
                            public static bool operator <=({h.ClassName} a, {baseName} b) => a.{baseName}Value <= b;
                            {Const.Inlined}
                            public static bool operator >=({h.ClassName} a, {baseName} b) => a.{baseName}Value >= b;

                        """);
                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public static bool operator ==({h.ClassName} a, Handle16 b) => a.Handle16Value == b;
                    {Const.Inlined}
                    public static bool operator !=({h.ClassName} a, Handle16 b) => a.Handle16Value != b;

                    {Const.Inlined}
                    public static bool operator <({h.ClassName} a, Handle16 b) => a.Handle16Value < b;
                    {Const.Inlined}
                    public static bool operator >({h.ClassName} a, Handle16 b) => a.Handle16Value > b;

                    {Const.Inlined}
                    public static bool operator <=({h.ClassName} a, Handle16 b) => a.Handle16Value <= b;
                    {Const.Inlined}
                    public static bool operator >=({h.ClassName} a, Handle16 b) => a.Handle16Value >= b;


                    {Const.Inlined}public static bool operator ==({h.ClassName} a, ushort b) => a.UnsignedValue == b;
                    {Const.Inlined}public static bool operator !=({h.ClassName} a, ushort b) => a.UnsignedValue != b;

                    {Const.Inlined}public static bool operator <({h.ClassName} a, ushort b) => a.UnsignedValue < b;
                    {Const.Inlined}public static bool operator >({h.ClassName} a, ushort b) => a.UnsignedValue > b;

                    {Const.Inlined}public static bool operator <=({h.ClassName} a, ushort b) => a.UnsignedValue <= b;
                    {Const.Inlined}public static bool operator >=({h.ClassName} a, ushort b) => a.UnsignedValue >= b;


                    {Const.Inlined}public static bool operator ==({h.ClassName} a, short b) => a.SignedValue == b;
                    {Const.Inlined}public static bool operator !=({h.ClassName} a, short b) => a.SignedValue != b;
                
                    {Const.Inlined}public static bool operator <({h.ClassName} a, short b) => a.SignedValue < b;
                    {Const.Inlined}public static bool operator >({h.ClassName} a, short b) => a.SignedValue > b;
                
                    {Const.Inlined}public static bool operator <=({h.ClassName} a, short b) => a.SignedValue <= b;
                    {Const.Inlined}public static bool operator >=({h.ClassName} a, short b) => a.SignedValue >= b;


                    {Const.Inlined}public static bool operator ==({h.ClassName} a, void* b) => a.PointerValue == b;
                    {Const.Inlined}public static bool operator !=({h.ClassName} a, void* b) => a.PointerValue != b;
                
                    {Const.Inlined}public static bool operator <({h.ClassName} a, void* b) => a.PointerValue < b;
                    {Const.Inlined}public static bool operator >({h.ClassName} a, void* b) => a.PointerValue > b;
                
                    {Const.Inlined}public static bool operator <=({h.ClassName} a, void* b) => a.PointerValue <= b;
                    {Const.Inlined}public static bool operator >=({h.ClassName} a, void* b) => a.PointerValue >= b;
                """);
            }
            sb.AppendLine("\t#region Equality and Comparability");
            sb.AppendLine();
            _Equals(sb, in h);
            sb.AppendLine();
            _CompareTo(sb, in h);
            sb.AppendLine();
            _Operators(sb, in h);
            sb.AppendLine(
            $"""

                {Const.Inlined}
                public readonly override int GetHashCode() => {h.EqualityLogic._GetHashCode};

                #endregion
            """);
        }
        static void FormatAndParse(StringBuilder sb, in Handle16 h)
        {
            string tryParse = h.StringLogic.TryParse.Replace("\r\n", "\r\n\t\t");
            sb.AppendLine(
            $$"""
                #region Format and Parse

                {{Const.Inlined}}
                public readonly override string ToString() => {{h.StringLogic._ToString}};
                {{Const.Inlined}}
                public readonly string ToString(string? format, IFormatProvider? provider = null) => {{h.StringLogic.ToStringFormat}};

                {{Const.Inlined}}
                public readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
                    => {{h.StringLogic.TryFormat}};
                {{Const.Inlined}}
                public readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
                    => {{h.StringLogic.TryFormat}};
                {{Const.Inlined}}
                public static {{h.ClassName}} Parse(string s, IFormatProvider? provider = null) => {{h.StringLogic.Parse}};
                {{Const.Inlined}}
                public static bool TryParse(string s, IFormatProvider? provider, scoped out {{h.ClassName}} result)
                {
                    {{tryParse}}
                }

                {{Const.Inlined}}
                public static {{h.ClassName}} Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => {{h.StringLogic.Parse}};
                {{Const.Inlined}}
                public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out {{h.ClassName}} result)
                {
                    {{tryParse}}
                }

                {{Const.Inlined}}
                public static {{h.ClassName}} Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => {{h.StringLogic.Parse}};
                {{Const.Inlined}}
                public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out {{h.ClassName}} result)
                {
                    {{tryParse}}
                }

                #endregion
            """);
        }
        static void Cast(StringBuilder sb, in Handle16 h)
        {
            sb.AppendLine(
            """
                #region Cast

            """);
            if (h.BaseClassNames is not null)
                foreach (var baseName in h.BaseClassNames)
                    sb.AppendLine(
                    $"""
                        {Const.Inlined}
                        public static explicit operator {h.ClassName}({baseName} h) => new(h);
                        {Const.Inlined}
                        public static implicit operator {baseName}({h.ClassName} h) => h.{baseName}Value;

                    """);

            sb.AppendLine(
            $"""
                {Const.Inlined}
                public static explicit operator {h.ClassName}(Handle16 h) => new(h);
                {Const.Inlined}
                public static implicit operator Handle16({h.ClassName} h) => h.Handle16Value;

                {Const.Inlined}
                public static explicit operator {h.ClassName}(ushort h) => new(h);
                {Const.Inlined}
                public static explicit operator ushort({h.ClassName} h) => h.UnsignedValue;

                {Const.Inlined}
                public static explicit operator {h.ClassName}(short h) => new(h);
                {Const.Inlined}
                public static explicit operator short({h.ClassName} h) => h.SignedValue;

                {Const.Inlined}
                public static explicit operator {h.ClassName}(void* h) => new(h);
                {Const.Inlined}
                public static explicit operator void*({h.ClassName} h) => h.PointerValue;

                #endregion
            """);
        }

        Construct(sb, in h);
        sb.AppendLine();
        Fields(sb, in h);
        sb.AppendLine();
        Math(sb, in h);
        sb.AppendLine();
        EqualityAndComparability(sb, in h);
        sb.AppendLine();
        FormatAndParse(sb, in h);
        sb.AppendLine();
        Cast(sb, in h);
    }

    public static void Generate(StringBuilder sb, string @namespace, in Handle16 h)
    {
        static void Usings(StringBuilder sb, in Handle16 h)
        {
            sb.AppendLine("// --- Default usings ---");
            foreach (var use in DefaultUsings)
                sb.AppendLine($"using {use};");
            if (h.Usings is not null && h.Usings.Length > 0)
            {
                sb.AppendLine("// --- Custom usings ---");
                foreach (var use in h.Usings)
                    sb.AppendLine($"using {use};");
            }
        }

        sb.AppendLine("#nullable enable");
        Usings(sb, in h);
        sb.AppendLine(
        $"""

        namespace TypedWinAPI.{@namespace};

        """);
        GenerateDefinition(sb, in h);
        GenerateBody(sb, in h);
        sb.AppendLine("}");
        sb.Append("#nullable restore");
    }

    public static void Generate(StringBuilder sb, string @namespace, params ReadOnlySpan<Handle16> hSpan)
    {
        static void Usings(StringBuilder sb, ReadOnlySpan<Handle16> hSpan)
        {
            sb.AppendLine("// --- Default usings ---");
            foreach (var use in DefaultUsings)
                sb.AppendLine($"using {use};");
            foreach (ref readonly var h in hSpan)
                if (h.Usings is not null && h.Usings.Length > 0)
                {
                    sb.AppendLine("// --- Custom usings ---");
                    foreach (var use in h.Usings)
                        sb.AppendLine($"using {use};");
                }
        }

        sb.AppendLine("#nullable enable");
        Usings(sb, hSpan);
        sb.AppendLine(
        $"""

        namespace TypedWinAPI.{@namespace};

        """);

        for (int i = 0, last = hSpan.Length; i < hSpan.Length; i++)
        {
            ref readonly var h = ref hSpan[i];
            GenerateDefinition(sb, in h);
            GenerateBody(sb, in h);
            if (i != last)
                sb.AppendLine(
                """
                }

                """);
            else
                sb.AppendLine("}");
        }
        sb.Append("#nullable restore");
    }

    public readonly record struct Handle16(
        string ClassName,
        string[]? BaseClassNames,
        string? Comment,
        string[]? Usings,
        string[]? Attributes,
        string[]? Contracts,
        MathConsts MathConsts,
        EqualityLogic EqualityLogic,
        StringLogic StringLogic)
    {
        public Handle16(string className) : this(
            className,
            null,
            null,
            null,
            null,
            null,
            new(className),
            new(className),
            new(className))
        { }
        public Handle16(string className, string? comment = null) : this(
            className,
            null,
            comment,
            null,
            null,
            null,
            new(className),
            new(className),
            new(className))
        { }
        public Handle16(string className, string[] baseClassNames, string? comment = null) : this(
            className,
            baseClassNames,
            comment,
            null,
            null,
            null,
            new(className, baseClassNames[0]),
            new(className, baseClassNames[0]),
            new(className, baseClassNames[0]))
        { }
    }

    public readonly record struct MathConsts(
        string MinValue,
        string MaxValue,
        string Zero)
    {
        public MathConsts(string className, string? baseName = null) : this(
            $"({className}){baseName ?? "Handle16"}.MinValue",
            $"({className}){baseName ?? "Handle16"}.MaxValue",
            $"({className}){baseName ?? "Handle16"}.Zero")
        { }
    }
    public readonly record struct EqualityLogic(
        string Equal,
        string NonEqual,
        string _GetHashCode,
        string _CompareTo,
        string Less,
        string More,
        string LessOrEqual,
        string MoreOrEqual)
    {
        public EqualityLogic(string className, string? baseName = null) : this(
            $"a.{baseName ?? "Handle16"}Value == b.{baseName ?? "Handle16"}Value",
            $"a.{baseName ?? "Handle16"}Value != b.{baseName ?? "Handle16"}Value",
            $"{baseName ?? "Handle16"}Value.GetHashCode()",
            $"{baseName ?? "Handle16"}Value.CompareTo(other.{baseName ?? "Handle16"}Value)",
            $"a.{baseName ?? "Handle16"}Value < b.{baseName ?? "Handle16"}Value",
            $"a.{baseName ?? "Handle16"}Value > b.{baseName ?? "Handle16"}Value",
            $"a.{baseName ?? "Handle16"}Value <= b.{baseName ?? "Handle16"}Value",
            $"a.{baseName ?? "Handle16"}Value >= b.{baseName ?? "Handle16"}Value")
        { }
    }
    public readonly record struct StringLogic(
        string _ToString,
        string ToStringFormat,
        string TryFormat,
        string Parse,
        string TryParse)
    {
        public StringLogic(string className, string? baseName = null) : this(
            $"{baseName ?? "Handle16"}Value.ToString()",
            $"{baseName ?? "Handle16"}Value.ToString(format, provider)",
            $"{baseName ?? "Handle16"}Value.TryFormat(destination, out written, format, provider)",
            $"({className}){baseName ?? "Handle16"}.Parse(s, provider)",
            $$"""
            Unsafe.SkipInit(out result);
            return {{baseName ?? "Handle16"}}.TryParse(s, provider, out Unsafe.As<{{className}}, {{baseName ?? "Handle16"}}>(ref result));
            """)
        { }
    }
}