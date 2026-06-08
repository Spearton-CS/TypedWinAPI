using System.Text;

using TemplateSourceGenerator.Templates;

namespace TemplateSourceGenerator.Groups;

internal static class GDIPlus
{
    public static void Generate(StringBuilder sb)
    {
#if !DEBUG
        try
        {
#endif
        Console.WriteLineInfo("Starting generation for GDI+...");

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

        Console.WriteLineSuccess("Generation done for GDI+, saving...");

        File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/GDIPlus/Handles/RootHandles.g.cs"), sb.ToString());

        Console.WriteLineSuccess("Saved generation for GDI+");

        sb.Clear();

        Console.WriteLineInfo("Starting generation for GDI+ (HImage derived)...");

        HandleTemplate.Generate(sb, "GDIPlus",
            new HandleTemplate.Handle("HBitmap", "Handle to a GDI+ bitmap"));

        Console.WriteLineSuccess("Generation done for GDI+ (HImage derived), saving...");

        File.WriteAllText(Path.GetFullPath($"{Program.TypedWinAPI_DIR}/_Modules/GDIPlus/Handles/ImageHandles.g.cs"), sb.ToString());

        Console.WriteLineSuccess("Saved generation for GDI+ (HImage derived)");

#if !DEBUG
        }
        catch (Exception ex)
        {
            Console.WriteLineError($"Caught an error during generation for an GDI+:\r\n{ex}");
        }
#endif
    }
}