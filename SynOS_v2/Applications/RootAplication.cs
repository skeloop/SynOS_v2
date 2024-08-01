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

        public override void Update()
        {
            Console.Clear();
            List<Application> applications = new List<Application>();
            foreach (var item in ApplicationManager.GetApplications("SynOS_v2.Applications"))
            {
                listSelection.elements.Add($"&6└ {item.GetType().Name}");
                applications.Add(item);
            }
            SelectionInformation selection = listSelection.Show("&6┌ &3Installierte Apps\n", "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n ┌─Steuerung Tabelle\n[Pfeiltaste hoch] - Nach oben\n[Pfeiltaste runter] - Nach unten\n[Enter] - Auswählen");
            if (selection.selection == typeof(SelectionReturnException))
            {
                OS.Print("Irgendetwas hat einen Programm-Schleifenbruch verursacht!", true, ConsoleColor.Red);
                OS.Print("Das Program würde sich jetzt schließen oder neustarten aber bis jetzt ist dies noch nicht implementiert.", true, ConsoleColor.Red);
                while(true)
                {
                    Console.ReadKey();
                }
            }
            applications[selection.selectionIndex].Run();
        }

        public override void Init()
        {
            Console.Title = "SynOS - Hauptmenü";
        }
    }
}
