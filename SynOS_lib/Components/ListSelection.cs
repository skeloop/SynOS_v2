using Libary.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libary.Components
{
    public enum SelectionReturnException { exit }
    public struct SelectionInformation
    {
        public object selection;
        public int selectionIndex;
        public bool canSelected;
    }
    public class ListSelection
    {

        public ListSelection subListSelection;
        public List<object> elements = new List<object>();
        /// <summary>
        /// Zeigt eine Liste mit auswählbaren Elementen
        /// </summary>
        /// <returns>Gibt 'SelectionInformation' zurück. Enthält weitere Infos für das ausgewählte Element</returns>
        public SelectionInformation Show(string header = "", string sub = "", bool clearScreen = true)
        {
            Console.Clear();
            int currentIndex = 0;
            SelectionInformation selection = new SelectionInformation();
            while (true)
            {
                if (elements.Count == 0)
                {
                    break;
                }
                if (clearScreen) Console.Clear();
                if (header != "")
                {
                    header.Print();
                    Console.ResetColor();
                }
                int i = 0;
                foreach(var element in elements)
                {
                    if (i == currentIndex)
                    {
                        $"&4{element.ToString()} &5‹".Print();
                    }
                    else $"&6{element.ToString()}".Print();
                    i++;
                }
                sub.Print();
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
                if (key == ConsoleKey.Escape)
                {
                    return new SelectionInformation()
                    {
                        selection = SelectionReturnException.exit
                    };
                }
            }
            return new SelectionInformation()
            {
                selection = SelectionReturnException.exit
            };
        }
    }
}
