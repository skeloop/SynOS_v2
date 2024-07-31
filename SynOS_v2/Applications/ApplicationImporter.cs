using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;
using SynOS_v2;
class Applicationimporter
{
    public void Start()
    {
        string filePath = Path.Combine(SpecialDirectories.Programs+"Applications");
        Directory.CreateDirectory(Path.Combine(filePath, "SynOS"));
        string code = File.ReadAllText(Path.Combine(filePath, "SynOS", "TestMod.cs"));

        OS.Print(Path.Combine(filePath, "SynOS", "TestMod.cs"), true, ConsoleColor.DarkGray);
        OS.Print("TestMod.cs", true, ConsoleColor.Yellow);

        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
        CSharpCompilation compilation = CSharpCompilation.Create(
            "UserModAssembly",
            new[] { syntaxTree },
            new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using (var ms = new MemoryStream())
        {
            var result = compilation.Emit(ms);
            OS.Print(result.ToString(), true, ConsoleColor.Green);
            if (!result.Success)
            {
                foreach (var diagnostic in result.Diagnostics)
                {
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
                    programType = assembly.GetType("Usermod.TestMod");
                    OS.Print("Klasse '" + programType.Name + "' wird analysiert...");
                }
                catch(Exception ex)
                {
                    SynOS_v2.Debug.Log(ex.ToString(), SynOS_v2.DebugType.fatal);
                    Thread.Sleep(1000);
                    return;
                }
                try
                {

                    mainMethod = programType.GetMethod("Init");
                    Console.WriteLine(mainMethod.Invoke(null, null));
                } catch (Exception ex)
                {
                    SynOS_v2.Debug.Log(ex.ToString(), SynOS_v2.DebugType.fatal);
                    Thread.Sleep(1000);
                    return;
                }

                
            }
        }
        Console.WriteLine("Externe Applicationen wurden geladen.");
        Console.WriteLine("Lade...");
        Thread.Sleep(2000);
    }
}
