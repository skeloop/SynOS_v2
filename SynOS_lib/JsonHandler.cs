using System.Reflection;
using Newtonsoft.Json;

namespace Libary
{
    public class JsonHandler
    {
        private readonly string _filePath;

        public JsonHandler(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(object obj)
        {
            var propertiesToSave = new Dictionary<string, object>();

            Type type = obj.GetType();
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.GetCustomAttribute<SaveToJsonAttribute>() != null)
                {
                    propertiesToSave[property.Name] = property.GetValue(obj);
                }
            }

            string json = JsonConvert.SerializeObject(propertiesToSave, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
