using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualBasic.FileIO;
using SynOS_v2;

class Applicationimporter
{
    public void Start()
    {
        string filePath = Path.Combine(SpecialDirectories.Programs, "SynOS", "Applications");
        Directory.CreateDirectory(Path.Combine(filePath, "SynOS"));
        foreach(var file in Directory.GetFiles(filePath))
        {
            string code = File.ReadAllText(file);

            OS.Print(file, true, ConsoleColor.DarkGray);
            OS.Print("└─ ", false, ConsoleColor.DarkGray);
            OS.Print("TestMod.cs wird geladen...", true, ConsoleColor.Yellow);

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            CSharpCompilation compilation = CSharpCompilation.Create(
                "UserModAssembly",
                new[] { syntaxTree },
                new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var ms = new MemoryStream())
            {
                var result = compilation.Emit(ms);
                if (!result.Success)
                {
                    foreach (var diagnostic in result.Diagnostics)
                    {
                        OS.Print("Fehler ", false, ConsoleColor.Red);
                        OS.Print("beim laden von ", false, ConsoleColor.DarkGray);
                        OS.Print("TestMod.cs", true, ConsoleColor.Gray);
                        OS.Print("└─ ", false, ConsoleColor.DarkGray);
                        OS.Print(diagnostic.ToString(), true, ConsoleColor.Red);
                    }
                    return;
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    Assembly assembly = Assembly.Load(ms.ToArray());
                    Type programType = null;
                    MethodInfo mainMethod = null;
                    try
                    {
                        programType = assembly.GetType("Extern.Applications");
                        OS.Print("Klasse '" + programType.Name + "' wird analysiert...");
                    }
                    catch (Exception ex)
                    {
                        SynOS_v2.Debug.Log(ex.ToString(), SynOS_v2.DebugType.fatal);
                        Thread.Sleep(100);
                        return;
                    }
                    try
                    {

                        mainMethod = programType.GetMethod("Init");
                        Console.WriteLine(mainMethod.Invoke(null, null));
                    }
                    catch (Exception ex)
                    {
                        SynOS_v2.Debug.Log(ex.ToString(), SynOS_v2.DebugType.fatal);
                        Thread.Sleep(100);
                        return;
                    }


                }
            }
        }
        


        Console.WriteLine("Externe Applicationen wurden geladen.");
        Console.WriteLine("Lade...");
        Thread.Sleep(250);
    }
}
