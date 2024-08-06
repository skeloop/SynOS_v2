using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libary
{
    public class JsonHandler
    {
        private readonly string _filePath;

        public JsonHandler(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<T?> LoadJsonAsync<T>()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine($"Datei {_filePath} wurde nicht gefunden.");
                    return default;
                }

                var jsonString = await File.ReadAllTextAsync(_filePath);
                var data = JsonSerializer.Deserialize<T>(jsonString);
                return data;
            }
            catch (JsonException)
            {
                Console.WriteLine($"Fehler beim Dekodieren von JSON aus der Datei {_filePath}.");
                return default;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei {_filePath}: {e.Message}");
                return default;
            }
        }

        public async Task SaveJsonAsync<T>(T data)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(_filePath, jsonString);
                Console.WriteLine($"Daten erfolgreich in {_filePath} gespeichert.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Fehler beim Schreiben in die Datei {_filePath}: {e.Message}");
            }
        }
    }

    // Beispielverwendung der Klasse
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var handler = new JsonHandler("data.json");

            // Daten speichern
            var dataToSave = new { Name = "Max Mustermann", Alter = 30, Stadt = "Berlin" };
            await handler.SaveJsonAsync(dataToSave);

            // Daten laden
            var loadedData = await handler.LoadJsonAsync<dynamic>();
            if (loadedData != null)
            {
                Console.WriteLine("Geladene Daten:");
                Console.WriteLine($"Name: {loadedData.Name}");
                Console.WriteLine($"Alter: {loadedData.Alter}");
                Console.WriteLine($"Stadt: {loadedData.Stadt}");
            }
        }
    }

}