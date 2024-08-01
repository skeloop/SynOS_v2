using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libary.Extension
{
    public static class ExtensionRegister
    {
        /// <summary>
        ///  1 - Blau
        ///  2 - Rot
        ///  3 - Gelb
        ///  4 - Grün
        ///  5 - Grau
        ///  6 - Dunkelgrau
        ///  
        ///  r - Reset Color
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void Print(this string text, int x = 0, int y = 0)
        {
            for (int iy = 0; iy < y; iy++)
            {
                Console.WriteLine();
            }

            List<(string, ConsoleColor)> segments = new List<(string, ConsoleColor)>();

            int currentPos = 0;
            ConsoleColor currentColor = ConsoleColor.White;

            while (currentPos < text.Length)
            {
                if (text[currentPos] == '&' && currentPos + 1 < text.Length && char.IsDigit(text[currentPos + 1]))
                {
                    if (currentPos > 0)
                    {
                        segments.Add((text.Substring(0, currentPos), currentColor));
                    }

                    currentColor = CheckColor($"&{text[currentPos + 1]}");

                    text = text.Substring(currentPos + 2);
                    currentPos = 0;
                }
                else
                {
                    currentPos++;
                }
            }

            if (!string.IsNullOrEmpty(text))
            {
                segments.Add((text, currentColor));
            }


            Console.SetCursorPosition(x, Console.CursorTop);

            foreach (var (segment, color) in segments)
            {
                Console.ForegroundColor = color;
                Console.Write(segment);
            }
            Console.ResetColor();
            Console.WriteLine();

        }
        
        /// <summary>
        ///  1 - Blau
        ///  2 - Rot
        ///  3 - Gelb
        ///  4 - Grün
        ///  5 - Grau
        ///  6 - Dunkelgrau
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static ConsoleColor CheckColor(string message)
        {
            if (message.Contains("&1")) return ConsoleColor.Blue;
            if (message.Contains("&2")) return ConsoleColor.Red;
            if (message.Contains("&3")) return ConsoleColor.Yellow;
            if (message.Contains("&4")) return ConsoleColor.Green;
            if (message.Contains("&5")) return ConsoleColor.Gray;
            if (message.Contains("&6")) return ConsoleColor.DarkGray;
            return ConsoleColor.White; // Standardfarbe, falls keine Übereinstimmung gefunden wird
        }
    }
}
