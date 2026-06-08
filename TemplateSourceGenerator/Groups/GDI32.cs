using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class GDI32
{
    public static void Generate(StringBuilder sb)
    {
#if !DEBUG
        try
        {
#endif
            Console.WriteLineInfo("Starting generation for GDI32...");

            HandleTemplate.Generate(sb, "GDI32",
                new("HDC", "Handle to a GDI32 Device Context"),
                new("HObj", "Handle to a GDI32 Object"));

            Console.WriteLineSuccess("Generation done for GDI32, saving...");

            File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/GDI32/Handles/RootHandles.g.cs"), sb.ToString());

            Console.WriteLineSuccess("Saved generation for GDI32");

            sb.Clear();

            Console.WriteLineInfo("Starting generation for GDI32 (HObj derived)...");

            HandleTemplate.Generate(sb, "GDI32",
                    new("HRegion", ["HObj"], "Handle to a GDI32 region object"),
                    new("HPen", ["HObj"], "Handle to a GDI32 pen object"),
                    new("HPalette", ["HObj"], "Handle to a GDI32 palette object"),
                    new("HFont", ["HObj"], "Handle to a GDI32 font object"),
                    new("HBrush", ["HObj"], "Handle to a GDI32 brush object"),
                    new("HBitmap", ["HObj"], "Handle to a GDI32 bitmap object"));

            Console.WriteLineSuccess("Generation done for GDI32 (HObj derived), saving...");

            File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/GDI32/Handles/GdiObjectHandles.g.cs"), sb.ToString());

            Console.WriteLineSuccess("Saved generation for GDI32 (HObj derived)");
#if !DEBUG
        }
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an error during generation for an GDI32:\r\n{ex}");
        }
#endif
    }
}