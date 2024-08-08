using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;
using Libary.Extension;

namespace Libary
{


    public enum ApplicationExitException { restart, exit }

    public class Application
    {
        public bool running = true;
        public bool initComplete = false;
        public ApplicationExitException Run()
        {
            running = true;
            CheckInit();
            while (running)
            {
                Update();
            }
            return ApplicationExitException.exit;
        }

        public void AskForAutostart()
        {
            string targetExe = "E:\\C#\\SynOS_v2\\SynOS_v2\\bin\\Debug\\net8.0\\SynOS_v2.exe";
            while (true)
            {
                "&5Möchtest du dass diese App automatisch gestartet wird?".Print();
                "&6[&2Y: Ja&6] &5| &6[&2N: Nein&6]".Print();

                var key = Console.ReadKey(true).Key; // true, um die Taste nicht auf der Konsole anzuzeigen

                if (key == ConsoleKey.Y)
                {
                    CreateShortcut(targetExe);
                    break; // Beende die Schleife nach dem Erstellen der Verknüpfung
                }
                else if (key == ConsoleKey.N)
                {
                    break;
                }
            }
        }

        void CheckInit()
        {
            if (!initComplete)
            {
                Init();
                initComplete = true;
            }
        }

        public virtual void Init()
        {
            Console.Title = "New application";
            Console.WriteLine("Warning!", true, ConsoleColor.Yellow);
            Console.WriteLine("The base 'Init()' method is implemented.", true, ConsoleColor.Yellow);
            Console.WriteLine("Please add your own override to it.");
            Console.WriteLine("");
            Console.WriteLine("(This message cannot be disabled)");
        }

        public virtual void Update()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning! application start range ends here.");
            Console.WriteLine("Please add 'Update()' function to your application\n\n\n\n");
            Console.WriteLine("Pressing any key continues the loop...");
            Console.ResetColor();
            Console.ReadKey();
            Stop();

        }
        public virtual void Stop()
        {
            running = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please add 'Stop()' function to your application.\n" +
                "Something tried to close this application but the standard logic for that is implemented yet.\n\n\n\n");
            Console.ResetColor();
            Console.ReadKey();
        }

        public virtual void Awake()
        {

        }

        static void CreateShortcut(string file)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string startupPath = System.IO.Path.Combine(appDataPath, @"Microsoft\Windows\Start Menu\Programs\Startup");

            // Name der Verknüpfung
            string shortcutName = "MeinProgramm.lnk";

            // Vollständiger Pfad zur Verknüpfung
            string shortcutPath = System.IO.Path.Combine(startupPath, shortcutName);

            // WshShell-Objekt erstellen
            WshShell shell = new WshShell();

            // Verknüpfungsobjekt erstellen
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            // Zielpfad der Verknüpfung setzen
            shortcut.TargetPath = file;

            // Optionale Einstellungen
            shortcut.WorkingDirectory = System.IO.Path.GetDirectoryName(file);
            shortcut.Description = "Mein Programm";

            // Verknüpfung speichern
            shortcut.Save();
        }

        /*
        public void Warnig()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                Print.Add("SynxOS - Hauptmenü", false, ConsoleColor.DarkBlue);
                Print.Add(" | ", false, ConsoleColor.DarkGray);
                Print.Add("Hinweis", true, ConsoleColor.Blue);
                Print.Add("", true);
                Print.Add("Diese Anwendung ist möglicherweise instabil und kann zu abstürzen führen.", true);
                var second = 5 - i;
                Print.Add("Geht weiter in (" + (second) + ")...", true);
                Thread.Sleep(1000);
            }
        }*/
    }
}
