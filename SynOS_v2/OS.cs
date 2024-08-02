using SynOS_v2.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Libary;

namespace SynOS_v2
{
    public static class OS
    {
        public static void Run()
        {
            Console.WriteLine(
                "  _____              ____   _____ \n" +
                " / ____|            / __ \\ / ____|\n" +
                "| (___  _   _ _ __ | |  | | (___  \n" +
                " \\___ \\| | | | '_ \\| |  | |\\___ \\ \n" +
                " ____) | |_| | | | | |__| |____) |\n" +
                "|_____/ \\__, |_| |_|\\____/|_____/ \n" +
                "         __/ |                    \n" +
                "        |___/                     \n");
            Thread.Sleep(1000);
            LoadApplications();
            Console.ReadKey();
        }

        static void LoadApplications()
        {
            Random random = new Random();
            Console.WriteLine("Load applications...");
            Thread.Sleep(100);
            foreach (var app in ApplicationManager.GetApplications("SynOS.Applications"))
            {
                Console.WriteLine("boot: " + app.GetType().Name);
                Thread.Sleep(random.Next(50, 1000));
                Console.WriteLine("Done!");
            }
            Print("Starte Input Thread...", true, ConsoleColor.Cyan);
            ProgramLoop();
        }
        public static RootAplication rootApplication = new RootAplication();
        static void ProgramLoop()
        {
            Console.WriteLine("Start program loop...");
            Thread.Sleep(500);
            while (true)
            {
                ApplicationExitException exitException = rootApplication.Run();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Application wurde beendet! Ist das gewollt?");
                Console.WriteLine("Grund: \n >>>" + exitException.ToString());
                Console.ResetColor();
                Console.ReadKey(true);
            }
        }

        public static string applicationNameSpace = "SynOS_v2.Applications";

        public static List<Type> GetAllClassesInNamespace()
        {
            // Laden Sie die Assembly, die Ihre Klassen enthält
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Alternativ: Laden Sie eine spezifische Assembly, falls die Klassen nicht in der aktuellen Assembly sind
            // Assembly assembly = Assembly.Load("Ihr.Assembly.Name");

            // Finden Sie alle Typen in der Assembly, die im angegebenen Namespace sind und Klassen (nicht abstrakt) sind
            List<Type> classesInNamespace = assembly.GetTypes()
                                                    .Where(t => t.IsClass && !t.IsAbstract)
                                                    .ToList();
            return classesInNamespace;
        }

        public static FieldInfo[] GetFields(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            // Abrufen des Typs des Objekts
            Type type = obj.GetType();

            // Abrufen aller Felder der Klasse
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            return fields;
        }

        public static List<object> GetFieldValues(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            List<object> fieldValues = new List<object>();

            // Abrufen des Typs des Objekts
            Type type = obj.GetType();

            // Abrufen aller Felder der Klasse
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                object fieldValue = field.GetValue(obj);
                fieldValues.Add(fieldValue);
            }

            return fieldValues;
        }

        public static void Print(string message, bool nextLine = true, ConsoleColor consoleColor = ConsoleColor.Gray)
        {
            string output = message;
            if (nextLine)
            {
                output = $"{output}\n";
            }
            Console.ForegroundColor = consoleColor;
            Console.Write(output);
        }

        public static List<ClassAnalyzeInformation> AnalyzeClass(Type type)
        {
            
            Print("Klasse '", false, ConsoleColor.DarkGray);
            Print(type.Name, false, ConsoleColor.Yellow);
            Print("'", true, ConsoleColor.DarkGray);
            Print("═══════════════════════════════", true);
            Print("", true);
            Print("■ Variablen", true);
            // Alle Felder (Variablen) der Klasse abrufen
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            List<ClassAnalyzeInformation> informations = new();
            ClassAnalyzeInformation classAnalyzeInformation = new ClassAnalyzeInformation();
            foreach (FieldInfo field in fields)
            {
                classAnalyzeInformation = new ClassAnalyzeInformation();
                // Zugriffsmodifikator ermitteln
                string accessModifier = GetAccessModifier(field);
                //Print("└─ ", false);
                //Print(accessModifier, false, ConsoleColor.DarkBlue);
                //Print(" | ", false, ConsoleColor.Gray);
                // Wert des Feldes (falls es instanzierte Objekte gibt) ermitteln
                object fieldValue = field.GetValue(Activator.CreateInstance(type));
                if (fieldValue == null)
                {
                    classAnalyzeInformation.variableValue = "&2null";
                } else
                {
                    classAnalyzeInformation.variableValue = fieldValue.ToString();
                }
                
                classAnalyzeInformation.variableName = field.Name;
                classAnalyzeInformation.variableType = field.FieldType;
                classAnalyzeInformation.variableModifier = accessModifier;
                informations.Add(classAnalyzeInformation);
                //Print(field.FieldType.Name +" ", false, ConsoleColor.Blue);
                //Print(field.Name, false, ConsoleColor.White);
                //Print(" = ", false, ConsoleColor.Gray);
                //Print(fieldValue.ToString(), true, ConsoleColor.Gray);
            }
            return informations;
            //Print("", true);
            //Print("■ Methoden", true);

            // Alle Methoden der Klasse abrufen
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {
                // Zugriffsmodifikator ermitteln
                string accessModifier = GetAccessModifier(method);

                Print("└─ ", false);
                Print(accessModifier, false, ConsoleColor.DarkBlue);
                Print(" " + method.ReturnType.Name, false, ConsoleColor.Blue);
                Print(" " + method.Name + "()", true, ConsoleColor.Gray);
            }
        }

        private static string GetAccessModifier(MemberInfo member)
        {
            if (member is FieldInfo field)
            {
                if (field.IsPublic) return "public";
                if (field.IsPrivate) return "private";
                if (field.IsFamily) return "protected";
            }
            else if (member is MethodInfo method)
            {
                if (method.IsPublic) return "public";
                if (method.IsPrivate) return "private";
                if (method.IsFamily) return "protected";
            }
            return "internal";
        }
    }

    public struct ClassAnalyzeInformation
    {
        public string variableName;
        public string variableModifier;
        public Type variableType;
        public string variableValue;
    }
}
