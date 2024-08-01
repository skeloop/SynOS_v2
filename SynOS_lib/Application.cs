using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libary
{
    public enum ApplicationExitException { restart, exit }

    public class Application
    {
        public bool running = true;

        public ApplicationExitException Run()
        {
            running = true;
            Init();
            while (running)
            {
                Update();
            }
            return ApplicationExitException.exit;
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
