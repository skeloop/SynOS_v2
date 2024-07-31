using Libary;

namespace SynOS_v2.Applications
{
    public class Cloud : Application
    {
        public override void Start()
        {
            Animation();
        }

        void Animation()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                OS.Print("Verbinde mit Cloud.");
                Thread.Sleep(100);
                Console.Clear();
                OS.Print("Verbinde mit Cloud..");
                Thread.Sleep(100);
                Console.Clear();
                OS.Print("Verbinde mit Cloud...");
                Thread.Sleep(100);
                Console.Clear();
                OS.Print("Verbinde mit Cloud");
                Thread.Sleep(100);
            }
            OS.Print("Verbunden!", true, ConsoleColor.Green);
            Thread.Sleep(500);
            Console.Clear();
            OS.Print("Account: ", false);
            OS.Print("Anonym", false, ConsoleColor.Yellow);
            OS.Print(" | ", false);
            OS.Print("> Home_Server:Linux/root ", true);
            OS.Print("------------------------------------------------------------() ", true);
            OS.Print(" root", true);
            OS.Print(" └─ /bin", false);
            OS.Print(" ■ Zugriff: ", false);
            OS.Print("Verweigert", true, ConsoleColor.Red);
            OS.Print(" └─ /debug", false);
            OS.Print(" ■ Zugriff: ", false);
            OS.Print("Verweigert", true, ConsoleColor.Red);
            OS.Print(" └─ /dev", false);
            OS.Print(" ■ Zugriff: ", false);
            OS.Print("Verweigert", true, ConsoleColor.Red);
            OS.Print(" └─ /extern", false);
            OS.Print(" ■ Zugriff: ", false);
            OS.Print("Erlaubt", true, ConsoleColor.Green);
            OS.Print(" └─ /logs", false);
            OS.Print(" ■ Zugriff: ", false);
            OS.Print("Verweigert", true, ConsoleColor.Red);
            OS.Print(" └─ /projects", false);
            OS.Print(" ■ Zugriff: ", false);
            OS.Print("Verweigert", true, ConsoleColor.Red);
            OS.Print(" └─ /info.json", false);
            OS.Print(" ■ Zugriff: ", false);
            OS.Print("Verweigert", true, ConsoleColor.Red);
            OS.Print(" └─ /data.lua", false);
            OS.Print(" ■ Zugriff: ", false);
            OS.Print("Verweigert", true, ConsoleColor.Red);
        }
    }

    public class CloudObject
    {
        Secrurity secrurity = new();
    }



    public enum SecrurityLevel { NONE, ACCOUNT, ADMIN }
    public class Secrurity
    {
        public SecrurityLevel secrurityLevel;
    }
}
