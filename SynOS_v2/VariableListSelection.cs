using Libary.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libary
{
    public class VariableListSelection
    {

        public List<object> elements = new List<object>();
        /// <summary>
        /// Zeigt eine Liste mit auswählbaren Elementen
        /// </summary>
        /// <returns>Gibt 'SelectionInformation' zurück. Enthält weitere Infos für das ausgewählte Element</returns>
        public SelectionInformation Show()
        {
            int currentIndex = 0;
            SelectionInformation selection = new SelectionInformation();
            while (true)
            {
                Console.Clear();
                int i = 0;
                foreach(var element in elements)
                {
                    if (i == currentIndex)
                    {
                        Console.WriteLine("> " + element.ToString());
                    }
                    else Console.WriteLine(element.ToString());
                    i++;
                }
                selection.selectionIndex = currentIndex;
                selection.selection = elements[currentIndex];
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    return selection;
                }
                if (key == ConsoleKey.UpArrow)
                {
                    if (currentIndex > 0)
                    {
                        currentIndex--;
                    }
                }
                if (key == ConsoleKey.DownArrow)
                {
                    if (currentIndex < elements.Count - 1)
                    {
                        currentIndex++;
                    }
                }
            }
        }
    }
}
