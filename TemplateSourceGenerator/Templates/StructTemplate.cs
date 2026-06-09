using System.Text;

namespace TemplateSourceGenerator.Templates;

internal static class StructTemplate
{
    public static readonly string[]
        DefaultUsings =
        [
            "System.Diagnostics",
            "System.Diagnostics.CodeAnalysis",
            "System.Runtime.CompilerServices",
            "System.Runtime.InteropServices",
            "TypedWinAPI.Contracts",
            "TypedWinAPI.Contracts.Struct",
            "TypedWinAPI.Contracts.Ptr"
        ],
        DefaultAttributes =
        [
            "DebuggerDisplay(\"{ToString(),nq}\")",
            "SkipLocalsInit"
        ];

    private static void GenerateDefinition(StringBuilder sb, in Struct s)
    {
        sb.AppendLine(
        $"""
        /// <summary>
        /// {s.Comment?.Replace("\r\n", "\r\n/// " ?? $"Struct of size {s.Size}")}
        /// </summary>
        """);
        sb.AppendLine("[");
        sb.AppendLine("\t// --- Default attrributes ---");
        foreach (var attr in DefaultAttributes)
        {
            sb.Append('\t'); sb.Append(attr); sb.AppendLine(",");
        }
        if (s.Attributes is not null && s.Attributes.Length > 0)
        {
            sb.AppendLine("\t// --- Custom attributes ---");
            foreach (var attr in s.Attributes)
            {
                sb.Append('\t'); sb.Append(attr); sb.AppendLine(",");
            }
        }
        sb.AppendLine($"\tStructLayout(LayoutKind.Explicit, Size = {s.Size})");
        bool primaryCon = false;
        foreach (var field in s.Fields)
            if (!string.IsNullOrWhiteSpace(field.DefaultValue))
            {
                primaryCon = true;
                break;
            }
        sb.AppendLine(
        $"""
        ]
        public {(s.IsReadOnly ? "readonly " : string.Empty)}unsafe struct {s.ClassName}{(primaryCon ? "() " : string.Empty)} :
        """);
        
        if (s.Contracts is not null && s.Contracts.Length > 0)
        {
            sb.AppendLine("\t// --- Custom contracts ---");
            foreach (var contract in s.Contracts)
            {
                sb.Append('\t'); sb.Append(contract); sb.AppendLine(",");
            }
        }

        sb.AppendLine(
        $$"""
            {{(s.IsReadOnly ? "IReadOnlyStructContracts" : "IStructContracts")}}<{{s.ClassName}}>
        {
        """);
    }
    private static void GenerateBody(StringBuilder sb, in Struct s)
    {
        static void StructContracts(StringBuilder sb, in Struct s)
        {
            sb.AppendLine(
            $$"""
                #region IReadOnlyStructContracts

                {{Const.Inlined}}
                public readonly override bool Equals(object? obj)
                    => obj is {{s.ClassName}} other && this == other;
                {{Const.Inlined}}
                public readonly bool Equals({{s.ClassName}} other) => this == other;
                public static bool operator ==({{s.ClassName}} a, {{s.ClassName}} b)
                {
            """);
            if (s.CustomBehavior.Equal is not null)
            {
                sb.Append("\t\t");
                sb.AppendLine(s.CustomBehavior.Equal.Replace("\r\n", "\r\n\t\t"));
            }
            else
            {
                foreach (var field in s.Fields)
                    sb.AppendLine(
                    $"""
                            if (a.{field.Name} != b.{field.Name})
                                return false;
                    """);
                if (s.Properties is not null && s.Properties.Length > 0)
                    foreach (var prop in s.Properties)
                        if (!prop.IsAbstract)
                            sb.AppendLine(
                            $"""
                                    if (a.{prop.Name} != b.{prop.Name})
                                        return false;
                            """);
                sb.AppendLine("\r\n\t\treturn true;");
            }
            sb.AppendLine(
            $$"""
                }
                public static bool operator !=({{s.ClassName}} a, {{s.ClassName}} b)
                {
                    {{s.CustomBehavior.NonEqual?.Replace("\r\n", "\r\n\t\t") ?? "return !(a == b);"}}
                }

                {{Const.UnscopedRef}}
                {{Const.Inlined}}
                public readonly ReadOnlySpan<byte> AsReadOnlySpan()
                {
                    {{s.CustomBehavior.AsReadOnlySpan?.Replace("\r\n", "\r\n\t\t") ?? "return MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1));"}}
                }

                #endregion
            """);
            if (!s.IsReadOnly)
            {
                sb.AppendLine(
                $$"""
                    #region IStructContracts

                    {{Const.UnscopedRef}}
                    {{Const.Inlined}}
                    public Span<byte> AsSpan()
                    {
                        {{s.CustomBehavior.AsSpan?.Replace("\r\n", "\r\n\t\t") ?? "return MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1));"}}
                    }

                    public void Clear()
                    {
                """);
                if (s.CustomBehavior.Clear is not null)
                {
                    sb.Append('\t'); sb.AppendLine(s.CustomBehavior.Clear.Replace("\r\n", "\r\n\t\t"));
                }
                else
                {
                    foreach (var field in s.Fields)
                        if (!field.Accessibility.Contains("readonly"))
                            sb.AppendLine(string.IsNullOrWhiteSpace(field.DefaultValue)
                                ? $"\t\t{field.Name} = default;"
                                : $"\t\t{field.Name} = {field.DefaultValue};");
                    if (s.Properties is not null && s.Properties.Length > 0)
                        foreach (var prop in s.Properties)
                            if (!prop.IsAbstract
                                && prop.SetBody is not null
                                && !prop.SetIsInit
                                && !prop.Accessibility.Contains("readonly")
                                && prop.SetAccessibility?.Contains("readonly") == false)
                                sb.AppendLine(string.IsNullOrWhiteSpace(prop.DefaultValue)
                                    ? $"\t\t{prop.Name} = default;"
                                    : $"\t\t{prop.Name} = {prop.DefaultValue};");
                }
                sb.AppendLine(
                $$"""
                    }

                    #endregion
                """);
            }
        }
        static void Constants(StringBuilder sb, in Struct s)
        {
            sb.AppendLine(
            """
                #region Constants

            """);
            foreach (var constant in s.Constants!)
                sb.AppendLine(
                $"""
                    /// <summary>
                    /// {constant.Comment?.Replace("\r\n", "\r\n\t/// ") ?? $"Constant of type {constant.Type.Replace('<', '[').Replace('>', ']')}"}
                    /// </summary>
                    {constant.Accessibility} const {constant.Type} {constant.Name} = {constant.Value};
                """);
            sb.AppendLine(
            """

                #endregion
            """);
        }
        static void Fields(StringBuilder sb, in Struct s)
        {
            sb.AppendLine(
            """
                #region Fields

            """);
            foreach (var field in s.Fields)
                sb.AppendLine(
                $"""
                    /// <summary>
                    /// {field.Comment?.Replace("\r\n", "\r\n\t/// ") ?? $"Field of type {field.Type.Replace('<', '[').Replace('>', ']')} on offset {field.Offset}"}
                    /// </summary>
                    [FieldOffset({field.Offset})] {field.Accessibility} {field.Type} {field.Name}{(field.DefaultValue is not null ? $" = {field.DefaultValue}" : string.Empty)};
                """);
            sb.AppendLine(
            """

                #endregion
            """);
        }
        static void Properties(StringBuilder sb, in Struct s)
        {
            sb.AppendLine(
            """
                #region Properties

            """);
            foreach (var prop in s.Properties!)
            {
                sb.AppendLine(
                $"""
                    /// <summary>
                    /// {prop.Comment?.Replace("\r\n", "\r\n\t/// ") ?? $"Property of type {prop.Type.Replace('<', '[').Replace('>', ']')}{(prop.Offset is not null ? $" at offset {prop.Offset}" : string.Empty)}"}
                    /// </summary>
                """);
                if (prop.Attributes is not null && prop.Attributes.Length > 0)
                {
                    sb.AppendLine("\t[");
                    for (int i = 0, last = prop.Attributes.Length - 1; i < prop.Attributes.Length; i++)
                    {
                        sb.Append('\t'); sb.Append(prop.Attributes[i]);
                        if (i != last)
                            sb.AppendLine(",");
                        else
                            sb.AppendLine();
                    }
                    sb.AppendLine("\t]");
                }
                sb.AppendLine(
                $$"""
                    {{prop.Accessibility}} {{prop.Type}} {{prop.Name}}
                    {
                """);
                if (!string.IsNullOrWhiteSpace(prop.GetBody))
                {
                    if (prop.GetAttributes is not null && prop.GetAttributes.Length > 0)
                    {
                        sb.AppendLine("\t\t[");
                        for (int i = 0, last = prop.GetAttributes.Length - 1; i < prop.GetAttributes.Length; i++)
                        {
                            sb.Append("\t\t"); sb.Append(prop.GetAttributes[i]);
                            if (i != last)
                                sb.AppendLine(",");
                            else
                                sb.AppendLine();
                        }
                        sb.AppendLine("\t\t]");
                    }
                    sb.AppendLine(
                    $$"""
                            get
                            {
                                {{prop.GetBody.Replace("\r\n", "\r\n\t\t\t")}}
                            }
                    """);
                }
                if (!string.IsNullOrWhiteSpace(prop.SetBody))
                {
                    if (prop.SetAttributes is not null && prop.SetAttributes.Length > 0)
                    {
                        sb.AppendLine("\t\t[");
                        for (int i = 0, last = prop.SetAttributes.Length - 1; i < prop.SetAttributes.Length; i++)
                        {
                            sb.Append("\t\t"); sb.Append(prop.SetAttributes[i]);
                            if (i != last)
                                sb.AppendLine(",");
                            else
                                sb.AppendLine();
                        }
                        sb.AppendLine("\t\t]");
                    }
                    sb.AppendLine(
                    $$"""
                            set
                            {
                                {{prop.SetBody.Replace("\r\n", "\r\n\t\t\t")}}
                            }
                    """);
                }
                sb.AppendLine(
                $$"""
                    }{{(prop.DefaultValue is not null ? $" = {prop.DefaultValue};" : string.Empty)}}
                """);
            }
            sb.AppendLine(
            """

                #endregion
            """);
        }
        static void Functions(StringBuilder sb, in Struct s)
        {
            sb.AppendLine(
            """
                #region Functions

            """);
            foreach (var func in s.Functions!)
            {
                sb.AppendLine(
                $"""
                    /// <summary>
                    /// {func.Comment?.Replace("\r\n", "\r\n\t/// ") ?? $"Function with return type {func.ReturnType.Replace('<', '[').Replace('>', ']')}"}
                    /// </summary>
                """);
                if (func.Attributes is not null && func.Attributes.Length > 0)
                {
                    sb.AppendLine("\t[");
                    for (int i = 0, last = func.Attributes.Length - 1; i < func.Attributes.Length; i++)
                    {
                        sb.Append('\t'); sb.Append(func.Attributes[i]);
                        if (i != last)
                            sb.AppendLine(",");
                        else
                            sb.AppendLine();
                    }
                    sb.AppendLine("\t]");
                }
                sb.Append(
                $"""
                    {func.Accessibility} {func.ReturnType} {func.Name}
                """);
                if (func.Generics is not null && func.Generics.Length > 0)
                {
                    sb.Append('<');
                    for (int i = 0, last = func.Generics.Length - 1; i < func.Generics.Length; i++)
                    {
                        sb.Append(func.Generics[i]);
                        if (i != last)
                            sb.Append(", ");
                    }
                    sb.Append('>');
                }
                sb.Append('(');
                if (func.Parameters is not null && func.Parameters.Length > 0)
                    for (int i = 0, last = func.Parameters.Length - 1; i < func.Parameters.Length; i++)
                    {
                        sb.Append(func.Parameters[i]);
                        if (i != last)
                            sb.Append(", ");
                    }
                sb.AppendLine(")");
                if (func.GenericStricts is not null && func.GenericStricts.Length > 0)
                    foreach (var strict in func.GenericStricts)
                    {
                        sb.Append("\t\t"); sb.AppendLine(strict);
                    }
                sb.AppendLine(
                $$"""
                    {
                        {{func.Body.Replace("\r\n", "\r\n\t\t")}}
                    }
                """);
            }
            sb.AppendLine(
            """

                #endregion
            """);
        }

        StructContracts(sb, in s);
        if (s.Constants is not null && s.Constants.Length > 0)
        {
            sb.AppendLine();
            Constants(sb, in s);
        }
        sb.AppendLine();
        Fields(sb, in s);
        if (s.Properties is not null && s.Properties.Length > 0)
        {
            sb.AppendLine();
            Properties(sb, in s);
        }
        if (s.Functions is not null && s.Functions.Length > 0)
        {
            sb.AppendLine();
            Functions(sb, in s);
        }
    }

    public static void Generate(StringBuilder sb, string @namespace, in Struct s)
    {
        static void Usings(StringBuilder sb, in Struct s)
        {
            sb.AppendLine("// --- Default usings ---");
            foreach (var use in DefaultUsings)
                sb.AppendLine($"using {use};");
            if (s.Usings is not null && s.Usings.Length > 0)
            {
                sb.AppendLine("// --- Custom usings ---");
                foreach (var use in s.Usings)
                    sb.AppendLine($"using {use};");
            }
        }

        sb.AppendLine("#nullable enable");
        Usings(sb, in s);
        sb.AppendLine(
        $"""

        namespace TypedWinAPI.{@namespace};

        """);

        GenerateDefinition(sb, in s);
        GenerateBody(sb, in s);
        sb.AppendLine("}");
        sb.Append("#nullable restore");
    }
    public static void Generate(StringBuilder sb, string @namespace, params ReadOnlySpan<Struct> sSpan)
    {
        static void Usings(StringBuilder sb, ReadOnlySpan<Struct> sSpan)
        {
            sb.AppendLine("// --- Default usings ---");
            foreach (var use in DefaultUsings)
                sb.AppendLine($"using {use};");
            foreach (ref readonly var s in sSpan)
                if (s.Usings is not null && s.Usings.Length > 0)
                {
                    sb.AppendLine("// --- Custom usings ---");
                    foreach (var use in s.Usings)
                        sb.AppendLine($"using {use};");
                }
        }

        sb.AppendLine("#nullable enable");
        Usings(sb, sSpan);
        sb.AppendLine(
        $"""

        namespace TypedWinAPI.{@namespace};

        """);

        for (int i = 0, last = sSpan.Length - 1; i < sSpan.Length; i++)
        {
            ref readonly var s = ref sSpan[i];
            GenerateDefinition(sb, in s);
            GenerateBody(sb, in s);

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

    public readonly record struct Struct(
        int Size,
        string ClassName,
        bool IsReadOnly,
        string? Comment,
        string[]? Usings,
        string[]? Attributes,
        string[]? Contracts,
        Field[] Fields,
        Constant[]? Constants,
        Property[]? Properties,
        Function[]? Functions,
        CustomBehavior CustomBehavior = default)
    {
        public Struct(int size, string className, bool isReadOnly, Field[] fields, string? comment = null) : this(
            size,
            className,
            isReadOnly,
            comment,
            null,
            null,
            null,
            fields,
            null,
            null,
            null,
            default)
        { }
        public Struct(int size, string className, bool isReadOnly, Field[] fields, Constant[]? constants, Property[]? properties = null, Function[]? functions = null, string? comment = null) : this(
            size,
            className,
            isReadOnly,
            comment,
            null,
            null,
            null,
            fields,
            constants,
            properties,
            functions,
            default)
        { }
        public Struct(int size, string className, bool isReadOnly, Field[] fields, string[]? usings, string[]? attributes = null, string[]? contracts = null, string? comment = null) : this(
            size,
            className,
            isReadOnly,
            comment,
            usings,
            attributes,
            contracts,
            fields,
            null,
            null,
            null,
            default)
        { }
    }
    public readonly record struct Field(
        string? Comment,
        int Offset,
        string Accessibility,
        string Type,
        string Name,
        string? DefaultValue = null);
    public readonly record struct Constant(
        string? Comment,
        string Accessibility,
        string Type,
        string Name,
        string Value);
    public readonly record struct Property(
        string? Comment,
        string Accessibility,
        string Type,
        string Name,
        string? GetAccessibility, string? GetBody,
        string? SetAccessibility, string? SetBody, bool SetIsInit,
        string? DefaultValue = null,
        int? Offset = null,
        string[]? Attributes = null,
        string[]? GetAttributes = null, string[]? SetAttributes = null,
        bool IsAbstract = true)
    {
        public Property(string accessibility, string type, string name, string getBody, string? comment = null) : this(
            comment,
            accessibility,
            type,
            name,
            accessibility, getBody,
            null, null, false,
            null,
            null,
            null,
            null, null,
            true)
        { }
        public Property(string accessibility, string type, string name, string getBody, int offset, string? defaultValue = null, string? comment = null) : this(
            comment,
            accessibility,
            type,
            name,
            accessibility, getBody,
            null, null, false,
            defaultValue,
            offset,
            null,
            null, null,
            true)
        { }
        public Property(string accessibility, string type, string name, string getBody, string setBody, string? comment = null, bool setIsInit = false, string? getAccessibility = null, string? setAccessibility = null) : this(
            comment,
            accessibility,
            type,
            name,
            getAccessibility ?? accessibility, getBody,
            setAccessibility ?? accessibility, setBody, setIsInit,
            null,
            null,
            null,
            null, null,
            true)
        { }
    }
    public readonly record struct Function(
        string? Comment,
        string Accessibility,
        string ReturnType,
        string Name,
        string[]? Generics,
        string[]? Parameters,
        string[]? GenericStricts,
        string Body,
        string[]? Attributes = null)
    {
        public Function(string accessibility, string name, string body, string? returnType = null, string? comment = null) : this(
            comment,
            accessibility,
            returnType ?? "void",
            name,
            null,
            null,
            null,
            body,
            null)
        { }
        public Function(string accessibility, string name, string body, string[] parameters, string? returnType = null, string? comment = null) : this(
            comment,
            accessibility,
            returnType ?? "void",
            name,
            null,
            parameters,
            null,
            body,
            null)
        { }
    }

    public readonly record struct CustomBehavior(
        string? _ToString,
        string? Equal,
        string? NonEqual,
        string? AsReadOnlySpan,
        string? AsSpan,
        string? Clear);
}