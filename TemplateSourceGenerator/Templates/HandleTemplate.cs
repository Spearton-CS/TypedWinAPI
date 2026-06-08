using System.Text;

namespace TemplateSourceGenerator.Templates;

internal static class HandleTemplate
{
    private static void GenerateDefinition(StringBuilder sb, in Handle h)
    {
        static void Attributes(StringBuilder sb, in Handle h)
        {
            sb.AppendLine("[");
            sb.AppendLine("\t// --- Default attributes ---");
            for (int i = 0, last = Const.DefaultAttributes.Length - 1; i < Const.DefaultAttributes.Length; i++)
            {
                sb.Append($"\t{Const.DefaultAttributes[i]}");
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
            sb.AppendLine("\t// --- Default contracts ---");
            sb.AppendLine($"\tIHandleTSelfContracts<{h.ClassName}>,");
            if (h.BaseClassNames is not null)
                foreach (var baseName in h.BaseClassNames)
                    sb.AppendLine($"\tIHandleTBaseHandleContracts<{h.ClassName}, {baseName}>,");
            if (h.Contracts is not null)
            {
                sb.AppendLine("\t --- Custom contracts ---");
                foreach (var contract in h.Contracts)
                    sb.AppendLine($"\t{contract},");
            }
            else
                sb.AppendLine("\t// --- Default contracts ---");
            sb.AppendLine($"\tIHandleTBaseHandleContracts<{h.ClassName}, Handle>,");
            sb.AppendLine($"\tIHandleContracts<{h.ClassName}>");
        }

        if (h.Comment is not null)
        {
            sb.AppendLine("/// <summary>");
            sb.Append("/// ");
            sb.AppendLine(h.Comment.Replace("\r\n", "\r\n///"));
            sb.AppendLine("/// </summary>");
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
            sb.AppendLine("\t#region Construct");
            sb.AppendLine();
            {
                sb.Append('\t'); sb.AppendLine(Const.Inlined);

                if (h.BaseClassNames is not null)
                {
                    sb.AppendLine($"\tpublic {h.ClassName}() => {h.BaseClassNames[0]}Value = default;");
                    sb.AppendLine();
                    sb.AppendLine("\t");
                    foreach (var baseName in h.BaseClassNames)
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic {h.ClassName}({baseName} h) => {baseName}Value = h;");
                    }
                    sb.AppendLine();
                }
                else
                    sb.AppendLine($"\tpublic {h.ClassName}() => HandleValue = default;");

                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic {h.ClassName}(Handle h) => HandleValue = h;");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic {h.ClassName}(void* ptr) => PointerValue = ptr;");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic {h.ClassName}(nuint unsig) => UnsignedValue = unsig;");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic {h.ClassName}(nint sig) => SignedValue = sig;");
            }
            sb.AppendLine();
            sb.AppendLine("\t#endregion");
        }
        static void Fields(StringBuilder sb, in Handle h)
        {
            sb.AppendLine("\t#region Fields");
            sb.AppendLine();
            {
                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                        sb.AppendLine($"\t[FieldOffset(0)] public readonly {baseName} {baseName}Value;");

                sb.AppendLine("\t[FieldOffset(0)] public readonly Handle HandleValue;");
                sb.AppendLine("\t[FieldOffset(0)] public readonly void* PointerValue;");
                sb.AppendLine("\t[FieldOffset(0)] public readonly nuint UnsignedValue;");
                sb.AppendLine("\t[FieldOffset(0)] public readonly nint SignedValue;");
            }
            sb.AppendLine();
            sb.AppendLine("\t#endregion");
        }
        static void Math(StringBuilder sb, in Handle h)
        {
            static void _Consts(StringBuilder sb, in Handle h)
            {
                sb.AppendLine($"\tpublic static {h.ClassName} MinValue");
                sb.AppendLine("\t{");
                {
                    sb.Append("\t\t"); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\t\tget => {h.MathConsts.MinValue};");
                }
                sb.AppendLine("\t}");

                sb.AppendLine();

                sb.AppendLine($"\tpublic static {h.ClassName} MaxValue");
                sb.AppendLine("\t{");
                {
                    sb.Append("\t\t"); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\t\tget => {h.MathConsts.MaxValue};");
                }
                sb.AppendLine("\t}");

                sb.AppendLine();

                sb.AppendLine($"\tpublic static {h.ClassName} Zero");
                sb.AppendLine("\t{");
                {
                    sb.Append("\t\t"); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\t\tget => {h.MathConsts.Zero};");
                }
                sb.AppendLine("\t}");
            }
            static void _BitOps(StringBuilder sb, in Handle h)
            {
                static void __Handles(StringBuilder sb, in Handle h)
                {
                    if (h.BaseClassNames is not null)
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator <<({h.ClassName} a, int shift) => ({h.ClassName})a.{h.BaseClassNames[0]}Value << shift;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator >>({h.ClassName} a, int shift) => ({h.ClassName})a.{h.BaseClassNames[0]}Value >> shift;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator >>>({h.ClassName} a, int shift) => ({h.ClassName})a.{h.BaseClassNames[0]}Value >>> shift;");

                        foreach (var baseName in h.BaseClassNames)
                        {
                            sb.AppendLine();

                            sb.Append('\t'); sb.AppendLine(Const.Inlined);
                            sb.AppendLine($"\tpublic static {h.ClassName} operator &({h.ClassName} a, {baseName} b) => ({h.ClassName})(a.{baseName}Value & b);");
                            sb.Append('\t'); sb.AppendLine(Const.Inlined);
                            sb.AppendLine($"\tpublic static {h.ClassName} operator |({h.ClassName} a, {baseName} b) => ({h.ClassName})(a.{baseName}Value | b);");
                            sb.Append('\t'); sb.AppendLine(Const.Inlined);
                            sb.AppendLine($"\tpublic static {h.ClassName} operator ^({h.ClassName} a, {baseName} b) => ({h.ClassName})(a.{baseName}Value ^ b);");
                        }

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator &({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(a.UnsignedValue & b.UnsignedValue);");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator |({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(a.UnsignedValue | b.UnsignedValue);");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator ^({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(a.UnsignedValue ^ b.UnsignedValue);");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator ~({h.ClassName} a) => ({h.ClassName})~a.UnsignedValue;");
                    }
                    else
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator <<({h.ClassName} a, int shift) => ({h.ClassName})a.HandleValue << shift;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator >>({h.ClassName} a, int shift) => ({h.ClassName})a.HandleValue >> shift;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator >>>({h.ClassName} a, int shift) => ({h.ClassName})a.HandleValue >>> shift;");

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator &({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(a.UnsignedValue & b.UnsignedValue);");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator |({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(a.UnsignedValue | b.UnsignedValue);");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator ^({h.ClassName} a, {h.ClassName} b) => ({h.ClassName})(a.UnsignedValue ^ b.UnsignedValue);");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static {h.ClassName} operator ~({h.ClassName} a) => ({h.ClassName})~a.UnsignedValue;");
                    }
                }
                static void __Primitives(StringBuilder sb, in Handle h)
                {
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator &({h.ClassName} a, Handle b) => ({h.ClassName})(a.HandleValue & b);");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator |({h.ClassName} a, Handle b) => ({h.ClassName})(a.HandleValue | b);");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator ^({h.ClassName} a, Handle b) => ({h.ClassName})(a.HandleValue ^ b);");

                    sb.AppendLine();

                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator &({h.ClassName} a, nuint b) => ({h.ClassName})(a.UnsignedValue & b);");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator |({h.ClassName} a, nuint b) => ({h.ClassName})(a.UnsignedValue | b);");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator ^({h.ClassName} a, nuint b) => ({h.ClassName})(a.UnsignedValue ^ b);");

                    sb.AppendLine();

                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator &({h.ClassName} a, nint b) => ({h.ClassName})(a.SignedValue & b);");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator |({h.ClassName} a, nint b) => ({h.ClassName})(a.SignedValue | b);");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator ^({h.ClassName} a, nint b) => ({h.ClassName})(a.SignedValue ^ b);");

                    sb.AppendLine();

                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator &({h.ClassName} a, void* b) => ({h.ClassName})(a.UnsignedValue & (nuint)b);");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator |({h.ClassName} a, void* b) => ({h.ClassName})(a.UnsignedValue | (nuint)b);");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static {h.ClassName} operator ^({h.ClassName} a, void* b) => ({h.ClassName})(a.UnsignedValue ^ (nuint)b);");
                }

                __Handles(sb, in h);
                sb.AppendLine();
                __Primitives(sb, in h);
            }

            sb.AppendLine("\t#region Math");
            sb.AppendLine();
            _Consts(sb, in h);
            sb.AppendLine();
            _BitOps(sb, in h);
            sb.AppendLine();
            sb.AppendLine("\t#endregion");
        }
        static void EqualityAndComparability(StringBuilder sb, in Handle h)
        {
            static void _Equals(StringBuilder sb, in Handle h)
            {
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly override bool Equals([NotNullWhen(true)] object? obj)");
                sb.AppendLine($"\t\t=> obj is {h.ClassName} other ? this == other");
                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                        sb.AppendLine($"\t\t\t: obj is {baseName} @{baseName} ? this == @{baseName}");
                sb.AppendLine("\t\t\t\t: obj is Handle h ? this == h");
                sb.AppendLine("\t\t\t\t\t: obj is nuint unsig ? this == unsig");
                sb.AppendLine("\t\t\t\t\t\t: obj is nint sig && this == sig;");

                sb.AppendLine();

                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic readonly bool Equals({baseName} other) => this == other;");
                        sb.AppendLine();
                    }

                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic readonly bool Equals({h.ClassName} other) => this == other;");

                sb.AppendLine();

                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly bool Equals(Handle other) => this == other;");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly bool Equals(nuint other) => this == other;");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly bool Equals(nint other) => this == other;");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly bool Equals(void* other) => this == other;");
            }
            static void _CompareTo(StringBuilder sb, in Handle h)
            {
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly int CompareTo([NotNullWhen(true)] object? obj)");
                sb.AppendLine($"\t\t=> obj is {h.ClassName} other ? CompareTo(other)");
                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                        sb.AppendLine($"\t\t\t: obj is {baseName} @{baseName} ? CompareTo(@{baseName})");
                sb.AppendLine("\t\t\t\t: obj is Handle h ? CompareTo(h)");
                sb.AppendLine("\t\t\t\t\t: obj is nuint unsig ? CompareTo(unsig)");
                sb.AppendLine("\t\t\t\t\t\t: obj is nint sig ? CompareTo(sig) : 0;");

                sb.AppendLine();

                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic readonly int CompareTo({baseName} other) => {baseName}Value.CompareTo(other);");
                        sb.AppendLine();
                    }

                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic readonly int CompareTo({h.ClassName} other) => {h.EqualityLogic._CompareTo};");
                sb.AppendLine();

                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly int CompareTo(Handle other) => HandleValue.CompareTo(other);");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly int CompareTo(nuint other) => UnsignedValue.CompareTo(other);");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly int CompareTo(nint other) => SignedValue.CompareTo(other);");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly int CompareTo(void* other) => UnsignedValue.CompareTo((nuint)other);");
            }
            static void _Operators(StringBuilder sb, in Handle h)
            {
                static void __Self(StringBuilder sb, in Handle h)
                {
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static bool operator ==({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.Equal};");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static bool operator !=({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.NonEqual};");

                    sb.AppendLine();

                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static bool operator <({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.Less};");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static bool operator >({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.More};");

                    sb.AppendLine();

                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static bool operator <=({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.LessOrEqual};");
                    sb.Append('\t'); sb.AppendLine(Const.Inlined);
                    sb.AppendLine($"\tpublic static bool operator >=({h.ClassName} a, {h.ClassName} b) => {h.EqualityLogic.MoreOrEqual};");
                }
                static void __Base(StringBuilder sb, in Handle h)
                {
                    if (h.BaseClassNames is not null)
                        foreach (var baseName in h.BaseClassNames)
                        {
                            sb.Append('\t'); sb.AppendLine(Const.Inlined);
                            sb.AppendLine($"\tpublic static bool operator ==({h.ClassName} a, {baseName} b) => a.{baseName}Value == b;");
                            sb.Append('\t'); sb.AppendLine(Const.Inlined);
                            sb.AppendLine($"\tpublic static bool operator !=({h.ClassName} a, {baseName} b) => a.{baseName}Value != b;");

                            sb.AppendLine();

                            sb.Append('\t'); sb.AppendLine(Const.Inlined);
                            sb.AppendLine($"\tpublic static bool operator <({h.ClassName} a, {baseName} b) => a.{baseName}Value < b;");
                            sb.Append('\t'); sb.AppendLine(Const.Inlined);
                            sb.AppendLine($"\tpublic static bool operator >({h.ClassName} a, {baseName} b) => a.{baseName}Value > b;");

                            sb.AppendLine();

                            sb.Append('\t'); sb.AppendLine(Const.Inlined);
                            sb.AppendLine($"\tpublic static bool operator <=({h.ClassName} a, {baseName} b) => a.{baseName}Value <= b;");
                            sb.Append('\t'); sb.AppendLine(Const.Inlined);
                            sb.AppendLine($"\tpublic static bool operator >=({h.ClassName} a, {baseName} b) => a.{baseName}Value >= b;");

                            sb.AppendLine();
                        }
                }
                static void __Primitives(StringBuilder sb, in Handle h)
                {
                    static void ___Handle(StringBuilder sb, in Handle h)
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator ==({h.ClassName} a, Handle b) => a.HandleValue == b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator !=({h.ClassName} a, Handle b) => a.HandleValue != b;");

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator <({h.ClassName} a, Handle b) => a.HandleValue < b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator >({h.ClassName} a, Handle b) => a.HandleValue > b;");

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator <=({h.ClassName} a, Handle b) => a.HandleValue <= b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator >=({h.ClassName} a, Handle b) => a.HandleValue >= b;");
                    }
                    static void ___Unsigned(StringBuilder sb, in Handle h)
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator ==({h.ClassName} a, nuint b) => a.UnsignedValue == b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator !=({h.ClassName} a, nuint b) => a.UnsignedValue != b;");

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator <({h.ClassName} a, nuint b) => a.UnsignedValue < b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator >({h.ClassName} a, nuint b) => a.UnsignedValue > b;");

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator <=({h.ClassName} a, nuint b) => a.UnsignedValue <= b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator >=({h.ClassName} a, nuint b) => a.UnsignedValue >= b;");
                    }
                    static void ___Signed(StringBuilder sb, in Handle h)
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator ==({h.ClassName} a, nint b) => a.SignedValue == b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator !=({h.ClassName} a, nint b) => a.SignedValue != b;");

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator <({h.ClassName} a, nint b) => a.SignedValue < b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator >({h.ClassName} a, nint b) => a.SignedValue > b;");

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator <=({h.ClassName} a, nint b) => a.SignedValue <= b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator >=({h.ClassName} a, nint b) => a.SignedValue >= b;");
                    }
                    static void ___Pointer(StringBuilder sb, in Handle h)
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator ==({h.ClassName} a, void* b) => a.PointerValue == b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator !=({h.ClassName} a, void* b) => a.PointerValue != b;");

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator <({h.ClassName} a, void* b) => a.PointerValue < b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator >({h.ClassName} a, void* b) => a.PointerValue > b;");

                        sb.AppendLine();

                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator <=({h.ClassName} a, void* b) => a.PointerValue <= b;");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static bool operator >=({h.ClassName} a, void* b) => a.PointerValue >= b;");
                    }

                    ___Handle(sb, in h);
                    sb.AppendLine();
                    ___Unsigned(sb, in h);
                    sb.AppendLine();
                    ___Signed(sb, in h);
                    sb.AppendLine();
                    ___Pointer(sb, in h);
                }

                __Self(sb, in h);
                sb.AppendLine();
                __Base(sb, in h);
                __Primitives(sb, in h);
            }
            sb.AppendLine("\t#region Equality and Comparability");
            sb.AppendLine();
            _Equals(sb, in h);
            sb.AppendLine();
            _CompareTo(sb, in h);
            sb.AppendLine();
            _Operators(sb, in h);
            sb.AppendLine();
            sb.Append('\t'); sb.AppendLine(Const.Inlined);
            sb.AppendLine($"\tpublic readonly override int GetHashCode() => {h.EqualityLogic._GetHashCode};");
            sb.AppendLine();
            sb.AppendLine("\t#endregion");
        }
        static void FormatAndParse(StringBuilder sb, in Handle h)
        {
            sb.AppendLine("\t#region Format and Parse");
            sb.AppendLine();
            {
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic readonly override string ToString() => {h.StringLogic._ToString};");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic readonly string ToString(string? format, IFormatProvider? provider = null) => {h.StringLogic.ToStringFormat};");


                sb.AppendLine();


                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly bool TryFormat(Span<char> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)");
                sb.AppendLine($"\t\t=> {h.StringLogic.TryFormat};");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine("\tpublic readonly bool TryFormat(Span<byte> destination, scoped out int written, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)");
                sb.AppendLine($"\t\t=> {h.StringLogic.TryFormat};");


                sb.AppendLine();


                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static {h.ClassName} Parse(string s, IFormatProvider? provider = null) => {h.StringLogic.Parse};");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static bool TryParse(string s, IFormatProvider? provider, scoped out {h.ClassName} result)");
                sb.AppendLine("\t{");
                string tryParse = "\t\t" + h.StringLogic.TryParse.Replace("\r\n", "\r\n\t\t");
                sb.AppendLine(tryParse);
                sb.AppendLine("\t}");


                sb.AppendLine();


                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static {h.ClassName} Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null) => {h.StringLogic.Parse};");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, scoped out {h.ClassName} result)");
                sb.AppendLine("\t{");
                sb.AppendLine(tryParse);
                sb.AppendLine("\t}");



                sb.AppendLine();


                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static {h.ClassName} Parse(ReadOnlySpan<byte> s, IFormatProvider? provider = null) => {h.StringLogic.Parse};");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider? provider, scoped out {h.ClassName} result)");
                sb.AppendLine("\t{");
                sb.AppendLine(tryParse);
                sb.AppendLine("\t}");
            }
            sb.AppendLine();
            sb.AppendLine("\t#endregion");
        }
        static void Cast(StringBuilder sb, in Handle h)
        {
            sb.AppendLine("\t#region Cast");
            sb.AppendLine();
            {
                if (h.BaseClassNames is not null)
                    foreach (var baseName in h.BaseClassNames)
                    {
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static explicit operator {h.ClassName}({baseName} h) => new(h);");
                        sb.Append('\t'); sb.AppendLine(Const.Inlined);
                        sb.AppendLine($"\tpublic static implicit operator {baseName}({h.ClassName} h) => h.{baseName}Value;");

                        sb.AppendLine();
                    }

                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static explicit operator {h.ClassName}(Handle h) => new(h);");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static implicit operator Handle({h.ClassName} h) => h.HandleValue;");

                sb.AppendLine();

                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static explicit operator {h.ClassName}(nuint h) => new(h);");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static explicit operator nuint({h.ClassName} h) => h.UnsignedValue;");

                sb.AppendLine();

                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static explicit operator {h.ClassName}(nint h) => new(h);");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static explicit operator nint({h.ClassName} h) => h.SignedValue;");

                sb.AppendLine();

                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static explicit operator {h.ClassName}(void* h) => new(h);");
                sb.Append('\t'); sb.AppendLine(Const.Inlined);
                sb.AppendLine($"\tpublic static explicit operator void*({h.ClassName} h) => h.PointerValue;");
            }
            sb.AppendLine();
            sb.AppendLine("\t#endregion");
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
            foreach (var use in Const.DefaultUsings)
                sb.AppendLine($"using {use};");
            if (h.Usings is not null)
            {
                sb.AppendLine("// --- Custom usings ---");
                foreach (var use in h.Usings)
                    sb.AppendLine($"using {use};");
            }
        }
        Usings(sb, in h);
        sb.AppendLine();
        sb.AppendLine($"namespace TypedWinAPI.{@namespace};");
        sb.AppendLine();
        GenerateDefinition(sb, in h);
        GenerateBody(sb, in h);
        sb.AppendLine("}");
    }

    public static void Generate(StringBuilder sb, string @namespace, params ReadOnlySpan<Handle> hSpan)
    {
        static void Usings(StringBuilder sb, ReadOnlySpan<Handle> hSpan)
        {
            sb.AppendLine("// --- Default usings ---");
            foreach (var use in Const.DefaultUsings)
                sb.AppendLine($"using {use};");
            foreach (ref readonly var h in hSpan)
                if (h.Usings is not null)
                {
                    sb.AppendLine("// --- Custom usings ---");
                    foreach (var use in h.Usings)
                        sb.AppendLine($"using {use};");
                }
        }
        Usings(sb, hSpan);
        sb.AppendLine();
        sb.AppendLine($"namespace TypedWinAPI.{@namespace};");
        sb.AppendLine();

        for (int i = 0, last = hSpan.Length; i < hSpan.Length; i++)
        {
            ref readonly var h = ref hSpan[i];
            GenerateDefinition(sb, in h);
            GenerateBody(sb, in h);
            sb.AppendLine("}");
            if (i != last)
                sb.AppendLine();
        }
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