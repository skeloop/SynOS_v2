using Libary.Extension;

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
                    $"\n&6┌ &3Hilfemenü".Print();
                    $"&6├ &5exit > Trennt die Verbindung & zurück zum Hauptmenü".Print();
                    $"&6├ &5admin > Öffnet die Administration".Print();
                    $"&6├ &5help > Ruft dieses Menü auf".Print();
                    $"&6├ &5list > Zeigt den Inhalt des aktuellen Ordners".Print();
                    $"&6├ &5back > Navigiert zurück".Print();
                    $"&6├ &5cd 'ordner_1/test_ordner/ziel_ordner' > Navigiert zu 'ziel_ordner'".Print();
                    $"&6├ &5copy Ordner/Dateiname > Kopiert das angegebene Objekt".Print();
                    $"&6├ &5cut Ordner/Dateiname > Schneidet das angegebene Objekt aus".Print();
                    $"&6├ &5paste Ordner/Dateiname > Fügt das angegebene Objekt hinzu".Print();
                    $"&6├ &5delete Ordner/Dateiname > Löscht das angegebene Objekt".Print();
                    $"&6├ &5create 'folder/file' name > Erstellt einen Ordner oder eine Datei mit dem angegebenen Name".Print();
                    $"&6├ &5buffer 'create, delete, append, dispose' 'filename'".Print();
                    $"&6├ &5open 'file' > Öffnet eine Datei".Print();
                    $"&6└ &5request 'permission' Ordner/Dateiname > Fordert Rechte bei einem Administrator an".Print();
                    break;
                case "admin":
                    $"\nAdministration".Print();
                    $"├ update *force* > Führt ein Update der Systemdatein durch und stellt diese für den publish bereit.\n                   Bei bedarf kann dieser Vorgang erzwungen werden.".Print();
                    $"└ request 'permission' Ordner/Dateiname > Fordert Rechte bei einem Administrator an".Print();
                    break;
                case "exit":
                    Stop();
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
            string hostname = "homeserver.nick@linux";
            OS.Print("> {hostname}:/root/ ", true);
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
