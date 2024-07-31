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
            Init();
            Start();
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

        public virtual void Start()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning! Empty application setup.");
            Console.WriteLine("Please add 'Start()' function to your application\n\n\n\n");
            Console.ResetColor();
        }
        public virtual void Update()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning! application start range ends here.");
            Console.WriteLine("Please add 'Update()' function to your application\n\n\n\n");
            Console.WriteLine("Pressing any key continues the loop...");
            Console.ResetColor();
            Console.ReadKey();

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
    }
}
