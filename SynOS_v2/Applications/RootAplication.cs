using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libary;
using Libary.Components;

namespace SynOS_v2.Applications
{
    public class RootAplication : Application
    {
        ListSelection listSelection = new ListSelection();

        public override void Start()
        {
            for (int i = 0; i < 6 ; i++)
            {
                Console.Clear();
                OS.Print("SynxOS - Hauptmenü", false, ConsoleColor.DarkBlue);
                OS.Print(" | ", false, ConsoleColor.DarkGray);
                OS.Print("Hinweis", true, ConsoleColor.Blue);
                OS.Print("", true);
                OS.Print("Diese Anwendung ist möglicherweise instabil und kann zu abstürzen führen.", true);
                var second = 5 - i;
                OS.Print("Geht weiter in ("+(second) +")", true);
                Thread.Sleep(1000);
            }
            List<Application> applications = new List<Application>();
            foreach (var item in ApplicationManager.GetApplications("SynOS_v2.Applications"))
            {
                Console.WriteLine("--> "+item.GetType().Name);
                listSelection.elements.Add(item.GetType().Name);
                applications.Add(item);
            }
            SelectionInformation selection = listSelection.Show();
            if (selection.selection == typeof(SelectionReturnException))
            {
                OS.Print("Irgendetwas hat einen Programm-Schleifenbruch verursacht!", true, ConsoleColor.Red);
                OS.Print("Das Program würde sich jetzt schließen oder neustarten aber bis jetzt ist dies noch nicht implementiert.", true, ConsoleColor.Red);
                while(true)
                {
                    Console.ReadKey();
                }
            }
            var app = ApplicationManager.GetApplications("SynOS_v2.Applications");
            app[selection.selectionIndex].Run();
        }

        public override void Init()
        {
            Console.Title = "SynOS - Hauptmenü";
        }
    }
}
