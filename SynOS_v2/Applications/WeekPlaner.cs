﻿using Libary.Components;
using Libary.Extension;

namespace SynOS_v2.Applications
{
    public class WeekPlaner : Application
    {
        ListSelection startMenuSel = new ListSelection();
        
        public override void Init()
        {
            active = true;
            startMenuSel.elements.Add("Plan laden");
            startMenuSel.elements.Add("Plan erstellen");
            startMenuSel.elements.Add("Erinnerung erstellen");
            startMenuSel.elements.Add("Einstellungen");

            projectSelection.elements.Add("Aufgabe erstellen");
        }

        public override void Update()
        {
            var selectionIndex = startMenuSel.Show("Wochenplaner").selectionIndex;
            switch (selectionIndex)
            {
                case 0:
                    
                    break;
                case 1:
                    Create();
                    break;
                case 4:
                    AskForAutostart();
                    break;
            }
        }

        ListSelection projectSelection = new ListSelection();

        public void Create()
        {
            ProjectData data = new()
            {
                name = "&6┌ &3Wie soll dein Plan heißen?".React("&5 Name: "),
                description = "&6┌ &3Gib eine Beschreibung ein... &6(Enter drücken zum leer lassen)".React(),
            };
            "Plan wurde erstellt".Print();

            Thread.Sleep(1500);
            LoadProject(data.name);
        }

        ListSelection tasksSelection = new ListSelection();
        public void LoadProject(string projectname)
        {

        }


    }
    public class ProjectData
    {
        public string name = "";
        public string description = "";
        public object[] Tasks = [];
    }


}
