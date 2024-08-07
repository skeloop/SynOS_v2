using Libary.Components;
using Libary.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS_v2.Applications
{
    public class WeekPlaner : Application
    {
        ListSelection startMenuSel = new ListSelection();

        public override void Init()
        {
            startMenuSel.elements.Add("Termin erstellen");
            startMenuSel.elements.Add("Erinnerung erstellen");
            startMenuSel.elements.Add("Einstellungen");
        }

        public override void Update()
        {
            var selectionIndex = startMenuSel.Show("Wochenplaner").selectionIndex;
            switch (selectionIndex)
            {
                case 0:
                    Create();
                    break;
            }
        }

        public void Create()
        {
            var data = new 
            { 
                name = "&6┌ &3Wie soll dein Plan heißen?".React("&5 Name: "),
                description = "&6┌ &3Gib deinem Projekt eine Beschreibung. &6(Enter drückem zum leer lassen)".React(),
            };
            
        }
    }
}
