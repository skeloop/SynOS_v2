using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS_v2
{
    public struct PrintInformation
    {
        public string text;
        public ConsoleColor color;
        public int startSpacing, endSpacing;
        public string id;
        public bool nextLine;
    }
    public static class Print
    {
        public static ConsoleColor standardPrintColor = ConsoleColor.DarkGray;
        public static List<PrintInformation> printInformations = new();
        /// <summary>
        /// Gibt den Inhalt (PrintInformation) der Klasse in der Konsole aus
        /// </summary>
        public static void PrintContent(string id)
        {
            foreach (var info in printInformations)
            {
                if (info.id != id) continue;
                string spaceString = "";
                string text = info.text;
                Console.ForegroundColor = info.color;
                for (int i = 0; i < info.startSpacing; i++)
                {
                    spaceString += $"-";
                }
                text = $"{spaceString}{text}";
                spaceString = "";
                for (int i = 0; i < info.endSpacing; i++)
                {
                    spaceString += $"-";
                }
                text = $"{text}{spaceString}";
                Console.WriteLine(text);
            }
            Console.ResetColor();
        }

        public static PrintInformation[] GetPrintContent(string id)
        {
            int iteration = 0;
            PrintInformation[] back = [];
            foreach (var info in printInformations)
            {
                if (info.id != id) continue;
                back[back.Length] = new();
                string spaceString = "";
                string text = info.text;
                Console.ForegroundColor = info.color;
                for (int i = 0; i < info.startSpacing; i++)
                {
                    spaceString += $"-";
                }
                text = $"{spaceString}{text}";
                spaceString = "";
                for (int i = 0; i < info.endSpacing; i++)
                {
                    spaceString += $"-";
                }
                text = $"{text}{spaceString}";
                back[back.Length-1].text = text;
                iteration++;
                Console.WriteLine(text);
            }
            Console.ResetColor();
            return back;
        }

        public static void Add(string id, string msg, bool nextLine = true, ConsoleColor color = ConsoleColor.DarkGray)
        {
            PrintInformation print = new PrintInformation();
            print.text = msg;
            print.color = color;
            print.id = id;
            print.nextLine = nextLine;
            printInformations.Add(print);
        }
    }
}
