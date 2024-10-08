﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libary;
using Libary.Components;
using Libary.Extension;

namespace SynOS_v2.Applications
{
    public class RootAplication : Application
    {
        ListSelection listSelection = new ListSelection();
        List<Application> loadedApplications = new List<Application>();
        public override void Update()
        {
            SelectionInformation selection = listSelection.Show("Installierte Apps", "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n ┌─Steuerung Tabelle\n[Pfeiltaste hoch] - Nach oben\n[Pfeiltaste runter] - Nach unten\n[Enter] - Auswählen");
            if (selection.selection == typeof(SelectionReturnException))
            {
                OS.Print("Irgendetwas hat einen Programm-Schleifenbruch verursacht!", true, ConsoleColor.Red);
                OS.Print("Das Program würde sich jetzt schließen oder neustarten aber bis jetzt ist dies noch nicht implementiert.", true, ConsoleColor.Red);
                while(true)
                {
                    Console.ReadKey();
                }
            }
            if (loadedApplications.Count == 0) 
            {
                "&2Es wurden keine aktiven Anwenungen gefunden!".Print();
                Stop();
            }
            else
            {
                loadedApplications[selection.selectionIndex].Run();
            }
        }

        public override void Init()
        {
            AskForAutostart();
            Console.Title = "SynOS - Hauptmenü";
            foreach (var item in ApplicationManager.GetApplications("SynOS_v2.Applications"))
            {
                if (item.active)
                {
                    listSelection.elements.Add($"{item.GetType().Name}");
                }
                loadedApplications.Add(item);
            }
        }
    }
}
