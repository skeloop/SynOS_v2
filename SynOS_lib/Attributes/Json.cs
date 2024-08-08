using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Libary
{
    // Attribut, das auf Klassen angewendet werden kann
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class Json : Attribute
    {
        public string Version { get; }
        public string Description { get; }

        // Konstruktor des Attributs, der Beschreibung und optional eine Version entgegennimmt
        public Json(string description, string version = "1.0")
        {
            Description = description;
            Version = version;
        }

        public void Save(object targetClass)
        {
            // Verwende GetType() auf der Instanz, um den tatsächlichen Typ zur Laufzeit zu ermitteln
            Type type = targetClass.GetType();

            // Prüfe, ob die Klasse das JsonAttribute hat
            var jsonAttribute = (Json)GetCustomAttribute(type, typeof(Json));

            if (jsonAttribute != null)
            {
                Console.WriteLine($"Klasse: {type.Name}");
                Console.WriteLine($"Beschreibung: {jsonAttribute.Description}");
                Console.WriteLine($"Version: {jsonAttribute.Version}");

                // Optional: Logik zum Speichern der Klasse als JSON-Datei
                string jsonString = JsonSerializer.Serialize(targetClass, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText($"{type.Name}.json", jsonString);
                Console.WriteLine($"Daten erfolgreich in {type.Name}.json gespeichert.");
            }
            else
            {
                Console.WriteLine($"Die Klasse {type.Name} hat kein JsonAttribute.");
            }
        }

    }
}
