using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Libary;
using Libary.Components;
using Libary.Extension;

namespace SynOS_v2.Applications
{
    public class ObjectCatalog : Application
    {
        ListSelection classSelection = new ListSelection();
        ListSelection variablesSelection = new ListSelection();

        public override void Init()
        {
            Console.WriteLine("C# Objektkatalog lädt...");
            foreach (var item in OS.GetAllClassesInNamespace())
            {
                $"&6... &3{item.Name} &5gefunden".Print();
                object exampleInstance = Activator.CreateInstance(item);
                classSelection.elements.Add(exampleInstance);
                Thread.Sleep(RandomNumberGenerator.GetInt32(100, 1500));
            }
        }


        public override void Update()
        {
            var ex = HandleInput();
            switch(ex)
            {
                case ApplicationExitException.exit:
                    Stop();
                    OS.rootApplication.Run();
                    return;
            }
            Console.Clear();
            Console.WriteLine("Alle Klassen im Namespace:");
            ListSelection subList = new ListSelection();
            variablesSelection.subListSelection = subList;
            object selection = classSelection.Show().selection;
            if (selection.GetType() == typeof(SelectionReturnException))
            {
                Stop();
            } 
            var infos = OS.AnalyzeClass(selection.GetType());
            foreach(var info in infos)
            {
                string output = $"{info.variableModifier} | {info.variableType} | {info.variableName} = {info.variableValue}";

                OS.Print($"{info.variableModifier}", false, ConsoleColor.DarkBlue);
                OS.Print(" | ", false, ConsoleColor.DarkGray);
                OS.Print($"{info.variableType}", false, ConsoleColor.Blue);
                OS.Print(" | ", false, ConsoleColor.DarkGray);
                OS.Print($"{info.variableName}", false, ConsoleColor.Gray);
                OS.Print(" = ", false, ConsoleColor.DarkGray);
                OS.Print($"'{info.variableValue}'", true, ConsoleColor.Cyan);
                variablesSelection.subListSelection.elements.Add(output);
            }
            variablesSelection.subListSelection = subList;
            var sel = variablesSelection.subListSelection.Show();
            if (sel.GetType() == typeof(SelectionReturnException))
            {
                Stop();
            }
            OS.Print($"selection: {sel}");


            return;
            int i = 0;
            foreach (var item in OS.GetFields(selection))
            {
                variablesSelection.elements.Add("--" + item.FieldType.Name + " | " + item.Name + " = '" + OS.GetFieldValues(item)[i].GetType().FullName + "'");//
                i++;
            }
            variablesSelection.Show();
        }

        ApplicationExitException HandleInput()
        {
            Console.WriteLine("[i] Um diese Anwenung zu schließen drücke ESC");
            Console.WriteLine("Drücke irgendwas um fortzufahren...");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                Stop();
                return ApplicationExitException.exit;
            } else
            {
                return ApplicationExitException.restart;
            }
        }
    }
}
