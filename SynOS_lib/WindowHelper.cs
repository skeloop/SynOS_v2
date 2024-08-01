using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Libary
{
    public class WindowHelper
    {
        public static void CreateWindow(int width, int height)
        {
            for (int h = 0; h < height; h++)
            {
                string corner = "";
                string column = "";
                for (int w = 0; w < width; w++)
                {
                    bool isTop = h == 0;
                    bool isBottom = h == height - 1;
                    bool isRight = w == width - 1;
                    bool isLeft = w == 0;
                    if (isTop)
                    {
                        if (isRight)
                        {
                            corner = "┐";
                        }
                        if (isLeft)
                        {
                            corner = "┌";
                        }
                        column = $"{column}=";
                    } else if(isBottom)
                    {
                        if (isRight)
                        {

                            corner = "└";

                        }
                        if (isLeft)
                        {
                            corner = "┘";
                            
                            
                        }
                        column = $"{column}=";

                    }
                    bool done = w == width - 1;
                    if (done)
                    {
                        corner = $"{corner}{column}{corner}";
                        Console.WriteLine(corner);
                        column = "";
                    }

                }




            }
            while(true)
            {
                GetCursorPos(out POINT pOINT);
                Console.WriteLine(pOINT.X.ToString() + " | " + pOINT.Y.ToString());
            }
            
            Console.ReadKey();
            /*
            return;
            if (h == 0 && h == height) // Oberste und untereste Zeile
            {
                output = "D";

                Console.WriteLine(output);
            }
            else
            {
                var message = "Element";
                var array = message.ToCharArray();
                foreach (char c in array)
                {
                    Console.Write(c);
                    Thread.Sleep(1);
                }
                Console.Write("\n");
            }*/
        }
        // Importiere die FindWindow-Funktion aus der user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Importiere die ShowWindow-Funktion aus der user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // Definiere Konstanten für die ShowWindow-Funktion
        private const int SW_MAXIMIZE = 3;
        public static void SetFullscren()
        {
            // Finde das Konsolenfenster mit dem Titel des aktuellen Prozesses
            IntPtr hWnd = FindWindow(null, Console.Title);
            if (hWnd != IntPtr.Zero)
            {
                // Maximiere das Konsolenfenster
                ShowWindow(hWnd, SW_MAXIMIZE);
                Console.WriteLine("Konsolenfenster wurde maximiert.");
            }
            else
            {
                Console.WriteLine("Konsolenfenster nicht gefunden.");
            }
    }

        // Importiere die GetCursorPos-Funktion aus der user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetCursorPos(out POINT lpPoint);
    }

    // Definiere die POINT-Struktur
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    public static class PrintAnimator
    {
        public static void Print(string message)
        {

        }
    }
}
