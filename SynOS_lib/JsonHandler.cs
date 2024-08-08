using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libary
{
    public class JsonHandler
    {
        private readonly string _applicationDataPath;

        public JsonHandler(string filePath)
        {
            _applicationDataPath = filePath;
        }

        public object LoadJsonAsync<T>(string filename)
        {
            try
            {
                string filePath = Path.Combine(_applicationDataPath, filename); // Korrigiert

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Datei {filePath} wurde nicht gefunden.");
                    return null;
                }

                var jsonString = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<T>(jsonString);
                return data;
            }
            catch (JsonException)
            {
                Console.WriteLine($"Fehler beim Dekodieren von JSON aus der Datei {Path.Combine(_applicationDataPath, filename)}.");
                return null;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei {Path.Combine(_applicationDataPath, filename)}: {e.Message}");
                return null;
            }
        }

        public void SaveJsonAsync<T>(T data, string filename)
        {
            try
            {
                string filePath = Path.Combine(_applicationDataPath, filename + ".json"); // Korrigiert

                var jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"Daten erfolgreich in {filePath} gespeichert.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Fehler beim Schreiben in die Datei {_applicationDataPath}: {e.Message}");
            }
        }
    }
}
