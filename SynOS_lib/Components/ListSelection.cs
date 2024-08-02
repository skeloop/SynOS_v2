using Libary.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libary.Components
{
    public enum SelectionReturnException { exit, selected }
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

        public int GetHighestElementTextLenght()
        {
            char[] chars = [];
            int number = 0;
            foreach (var element in elements)
            {
                if (element.GetType() == typeof(string))
                {
                    chars = element.ToString().ToCharArray();
                    if (chars.Length > number) number = chars.Length;
                }
            }
            return number;
        }
        /// <summary>
        /// Zeigt eine Liste mit auswählbaren Elementen
        /// </summary>
        /// <returns>Gibt 'SelectionReturnException' zurück. Nützlich für weitere Behandlungen die eine Rückgabe brauchen.</returns>
        public SelectionInformation Show(string header = "", string sub = "", bool clearScreen = true)
        {
            Console.Clear();

            if (elements.Count == 0)
            {
                return new();
            }

            int currentIndex = 0;
            SelectionInformation selection = new SelectionInformation();
            while (true)
            {

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
