using Libary;

namespace SynOS_v2.Applications
{
    public class Cloud : Application
    {
        public override void Update()
        {
            OS.Print("");
            OS.Print(" ┌── Gebe einen Command ein");
            Console.Write(" ");
            var command = Console.ReadLine();
            CheckCommand(command);
        }

        void CheckCommand(string cmd)
        {
            switch (cmd)
            {
                case "help":
                    OS.Print("\nHilfemenü", true);
                    OS.Print("├ admin > Öffnet die Administration", true);
                    OS.Print("├ help > Ruft dieses Menü auf", true);
                    OS.Print("├ list > Zeigt den Inhalt des aktuellen Ordners", true);
                    OS.Print("├ back > Navigiert zurück", true);
                    OS.Print("├ cd 'ordner_1/test_ordner/ziel_ordner' > Navigiert zu 'ziel_ordner'", true);
                    OS.Print("├ copy Ordner/Dateiname > Kopiert das angegebene Objekt", true);
                    OS.Print("├ cut Ordner/Dateiname > Schneidet das angegebene Objekt aus", true);
                    OS.Print("├ paste Ordner/Dateiname > Fügt das angegebene Objekt hinzu", true);
                    OS.Print("├ delete Ordner/Dateiname > Löscht das angegebene Objekt", true);
                    OS.Print("├ create 'folder/file' name > Erstellt einen Ordner oder eine Datei mit dem angegebenen Name", true);
                    OS.Print("├ buffer 'create, delete, append, dispose' 'filename'", true);
                    OS.Print("├ open 'file' > Öffnet eine Datei", true);
                    OS.Print("└ request 'permission' Ordner/Dateiname > Fordert Rechte bei einem Administrator an", true);
                    break;
                case "admin":
                    OS.Print("\nAdministration", true);
                    OS.Print("├ update *force* > Führt ein Update der Systemdatein durch und stellt diese für den publish bereit.\n                   Bei bedarf kann dieser Vorgang erzwungen werden.", true);
                    OS.Print("└ request 'permission' Ordner/Dateiname > Fordert Rechte bei einem Administrator an", true);
                    break;
            }
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
