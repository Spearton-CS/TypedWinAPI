using System.Text;

namespace TemplateSourceGenerator.Templates;

internal static class HandleTemplate
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
            "StructLayout(LayoutKind.Explicit, Size = 8)",
            "DebuggerDisplay(\"{ToString(),nq}\")",
            "DebuggerStepThrough",
            "SkipLocalsInit"
        ];

    private static void GenerateDefinition(StringBuilder sb, in Handle h)
    {
        static void Attributes(StringBuilder sb, in Handle h)
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
        static void Contracts(StringBuilder sb, in Handle h)
        {
            sb.AppendLine(
            $"""
                // --- Default contracts ---
                IHandleTSelfContracts<{h.ClassName}>,
            """);
            if (h.BaseClassNames is not null)
                foreach (var baseName in h.BaseClassNames)
                    sb.AppendLine($"\tIHandleTBaseHandleContracts<{h.ClassName}, {baseName}>,");
            if (h.Contracts is not null)
                sb.AppendLine(
                $"""
                    // --- Custom contracts ---
                    {string.Join(",\r\n\t", h.Contracts)},
                    // --- Default contracts ---
                 """);
            sb.AppendLine(
            $"""
                IHandleTBaseHandleContracts<{h.ClassName}, Handle>,
                IHandleContracts<{h.ClassName}>
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
    private static void GenerateBody(StringBuilder sb, in Handle h)
    {
        static void Construct(StringBuilder sb, in Handle h)
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
                        public {h.ClassName}() => HandleValue = default;
                    """);

                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public {h.ClassName}(Handle h) => HandleValue = h;
                    {Const.Inlined}
                    public {h.ClassName}(void* ptr) => PointerValue = ptr;
                    {Const.Inlined}
                    public {h.ClassName}(nuint unsig) => UnsignedValue = unsig;
                    {Const.Inlined}
                    public {h.ClassName}(nint sig) => SignedValue = sig;
                """);
            }
            sb.AppendLine(
            """

                #endregion
            """);
        }
        static void Fields(StringBuilder sb, in Handle h)
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
                    [FieldOffset(0)] public readonly Handle HandleValue;
                    [FieldOffset(0)] public readonly void* PointerValue;
                    [FieldOffset(0)] public readonly nuint UnsignedValue;
                    [FieldOffset(0)] public readonly nint SignedValue;
                """);
            }
            sb.AppendLine(
            """

                #endregion
            """);
        }
        static void Math(StringBuilder sb, in Handle h)
        {
            static void _BitOps(StringBuilder sb, in Handle h)
            {
                static void __Handles(StringBuilder sb, in Handle h)
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
                            public static {h.ClassName} operator <<({h.ClassName} a, int shift) => ({h.ClassName})(a.HandleValue << shift);
                            {Const.Inlined}
                            public static {h.ClassName} operator >>({h.ClassName} a, int shift) => ({h.ClassName})(a.HandleValue >> shift);
                            {Const.Inlined}
                            public static {h.ClassName} operator >>>({h.ClassName} a, int shift) => ({h.ClassName})(a.HandleValue >>> shift);
                        """);

                    sb.AppendLine(
                    $"""

                        {Const.Inlined}
                        public static {h.ClassName} operator &({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(a.UnsignedValue & b.UnsignedValue);
                        {Const.Inlined}
                        public static {h.ClassName} operator |({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(a.UnsignedValue | b.UnsignedValue);
                        {Const.Inlined}
                        public static {h.ClassName} operator ^({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(a.UnsignedValue ^ b.UnsignedValue);
                        {Const.Inlined}
                        public static {h.ClassName} operator ~({h.ClassName} a) => ({h.ClassName})~a.UnsignedValue;
                    """);
                }

                __Handles(sb, in h);
                sb.AppendLine();
                sb.AppendLine(
                $"""
                    {Const.Inlined}
                    public static {h.ClassName} operator &({h.ClassName} a, Handle b) => ({h.ClassName})(a.HandleValue & b);
                    {Const.Inlined}
                    public static {h.ClassName} operator |({h.ClassName} a, Handle b) => ({h.ClassName})(a.HandleValue | b);
                    {Const.Inlined}
                    public static {h.ClassName} operator ^({h.ClassName} a, Handle b) => ({h.ClassName})(a.HandleValue ^ b);

                    {Const.Inlined}
                    public static {h.ClassName} operator &({h.ClassName} a, nuint b) => ({h.ClassName})(a.UnsignedValue & b);
                    {Const.Inlined}
                    public static {h.ClassName} operator |({h.ClassName} a, nuint b) => ({h.ClassName})(a.UnsignedValue | b);
                    {Const.Inlined}
                    public static {h.ClassName} operator ^({h.ClassName} a, nuint b) => ({h.ClassName})(a.UnsignedValue ^ b);

                    {Const.Inlined}
                    public static {h.ClassName} operator &({h.ClassName} a, nint b) => ({h.ClassName})(a.SignedValue & b);
                    {Const.Inlined}
                    public static {h.ClassName} operator |({h.ClassName} a, nint b) => ({h.ClassName})(a.SignedValue | b);
                    {Const.Inlined}
                    public static {h.ClassName} operator ^({h.ClassName} a, nint b) => ({h.ClassName})(a.SignedValue ^ b);

                    {Const.Inlined}
                    public static {h.ClassName} operator &({h.ClassName} a, void* b) => ({h.ClassName})(a.UnsignedValue & (nuint)b);
                    {Const.Inlined}
                    public static {h.ClassName} operator |({h.ClassName} a, void* b) => ({h.ClassName})(a.UnsignedValue | (nuint)b);
                    {Const.Inlined}
                    public static {h.ClassName} operator ^({h.ClassName} a, void* b) => ({h.ClassName})(a.UnsignedValue ^ (nuint)b);
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
        static void EqualityAndComparability(StringBuilder sb, in Handle h)
        {
            static void _Equals(StringBuilder sb, in Handle h)
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
                                : obj is Handle h ? this == h
                                    : obj is nuint unsig ? this == unsig
                                        : obj is nint sig && this == sig;


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
                    public readonly bool Equals(Handle other) => this == other;
                    {Const.Inlined}
                    public readonly bool Equals(nuint other) => this == other;
                    {Const.Inlined}
                    public readonly bool Equals(nint other) => this == other;
                    {Const.Inlined}
                    public readonly bool Equals(void* other) => this == other;
                """);
            }
            static void _CompareTo(StringBuilder sb, in Handle h)
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
                                : obj is Handle h ? CompareTo(h)
                                    : obj is nuint unsig ? CompareTo(unsig)
                                        : obj is nint sig ? CompareTo(sig) : 0;

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
                    public readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);
                    {Const.Inlined}
                    public readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);
                    {Const.Inlined}
                    public readonly int CompareTo(nint other) => SignedValue.CompareTo(other);
                    {Const.Inlined}
                    public readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);
                """);
            }
            static void _Operators(StringBuilder sb, in Handle h)
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
                    public static bool operator ==({h.ClassName} a, Handle b) => a.HandleValue == b;
                    {Const.Inlined}
                    public static bool operator !=({h.ClassName} a, Handle b) => a.HandleValue != b;

                    {Const.Inlined}
                    public static bool operator <({h.ClassName} a, Handle b) => a.HandleValue < b;
                    {Const.Inlined}
                    public static bool operator >({h.ClassName} a, Handle b) => a.HandleValue > b;

                    {Const.Inlined}
                    public static bool operator <=({h.ClassName} a, Handle b) => a.HandleValue <= b;
                    {Const.Inlined}
                    public static bool operator >=({h.ClassName} a, Handle b) => a.HandleValue >= b;


                    {Const.Inlined}public static bool operator ==({h.ClassName} a, nuint b) => a.UnsignedValue == b;
                    {Const.Inlined}public static bool operator !=({h.ClassName} a, nuint b) => a.UnsignedValue != b;

                    {Const.Inlined}public static bool operator <({h.ClassName} a, nuint b) => a.UnsignedValue < b;
                    {Const.Inlined}public static bool operator >({h.ClassName} a, nuint b) => a.UnsignedValue > b;

                    {Const.Inlined}public static bool operator <=({h.ClassName} a, nuint b) => a.UnsignedValue <= b;
                    {Const.Inlined}public static bool operator >=({h.ClassName} a, nuint b) => a.UnsignedValue >= b;


                    {Const.Inlined}public static bool operator ==({h.ClassName} a, nint b) => a.SignedValue == b;
                    {Const.Inlined}public static bool operator !=({h.ClassName} a, nint b) => a.SignedValue != b;
                
                    {Const.Inlined}public static bool operator <({h.ClassName} a, nint b) => a.SignedValue < b;
                    {Const.Inlined}public static bool operator >({h.ClassName} a, nint b) => a.SignedValue > b;
                
                    {Const.Inlined}public static bool operator <=({h.ClassName} a, nint b) => a.SignedValue <= b;
                    {Const.Inlined}public static bool operator >=({h.ClassName} a, nint b) => a.SignedValue >= b;


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
        static void FormatAndParse(StringBuilder sb, in Handle h)
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
        static void Cast(StringBuilder sb, in Handle h)
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
                public static explicit operator {h.ClassName}(Handle h) => new(h);
                {Const.Inlined}
                public static implicit operator Handle({h.ClassName} h) => h.HandleValue;

                {Const.Inlined}
                public static explicit operator {h.ClassName}(nuint h) => new(h);
                {Const.Inlined}
                public static explicit operator nuint({h.ClassName} h) => h.UnsignedValue;

                {Const.Inlined}
                public static explicit operator {h.ClassName}(nint h) => new(h);
                {Const.Inlined}
                public static explicit operator nint({h.ClassName} h) => h.SignedValue;

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

    public static void Generate(StringBuilder sb, string @namespace, in Handle h)
    {
        static void Usings(StringBuilder sb, in Handle h)
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

    public static void Generate(StringBuilder sb, string @namespace, params ReadOnlySpan<Handle> hSpan)
    {
        static void Usings(StringBuilder sb, ReadOnlySpan<Handle> hSpan)
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

    public readonly record struct Handle(
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
        public Handle(string className) : this(
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
        public Handle(string className, string? comment = null) : this(
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
        public Handle(string className, string[] baseClassNames, string? comment = null) : this(
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
            $"({className}){baseName ?? "Handle"}.MinValue",
            $"({className}){baseName ?? "Handle"}.MaxValue",
            $"({className}){baseName ?? "Handle"}.Zero")
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
            $"a.{baseName ?? "Handle"}Value == b.{baseName ?? "Handle"}Value",
            $"a.{baseName ?? "Handle"}Value != b.{baseName ?? "Handle"}Value",
            $"{baseName ?? "Handle"}Value.GetHashCode()",
            $"{baseName ?? "Handle"}Value.CompareTo(other.{baseName ?? "Handle"}Value)",
            $"a.{baseName ?? "Handle"}Value < b.{baseName ?? "Handle"}Value",
            $"a.{baseName ?? "Handle"}Value > b.{baseName ?? "Handle"}Value",
            $"a.{baseName ?? "Handle"}Value <= b.{baseName ?? "Handle"}Value",
            $"a.{baseName ?? "Handle"}Value >= b.{baseName ?? "Handle"}Value")
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
            $"{baseName ?? "Handle"}Value.ToString()",
            $"{baseName ?? "Handle"}Value.ToString(format, provider)",
            $"{baseName ?? "Handle"}Value.TryFormat(destination, out written, format, provider)",
            $"({className}){baseName ?? "Handle"}.Parse(s, provider)",
            $$"""
            Unsafe.SkipInit(out result);
            return {{baseName ?? "Handle"}}.TryParse(s, provider, out Unsafe.As<{{className}}, {{baseName ?? "Handle"}}>(ref result));
            """)
        { }
    }
}