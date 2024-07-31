using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Libary;

namespace SynOS_v2
{
    public class ApplicationManager
    {
        public static List<Application> GetApplications(string applicationNameSpace)
        {
            // Laden Sie die Assembly, die Ihre Klassen enthält
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Alternativ: Laden Sie eine spezifische Assembly, falls die Klassen nicht in der aktuellen Assembly sind
            // Assembly assembly = Assembly.Load("Ihr.Assembly.Name");

            // Finden Sie alle Typen in der Assembly, die im angegebenen Namespace sind und Klassen (nicht abstrakt) sind
            List<Type> classesInNamespace = assembly.GetTypes()
                                                    .Where(t => t.IsClass && t.Namespace == applicationNameSpace && t.IsSubclassOf(typeof(Application)))
                                                    .ToList();
            List<Application> instances = new List<Application>();
            foreach (Type type in classesInNamespace)
            {
                if (Activator.CreateInstance(type) is Application instance)
                {
                    instances.Add(instance);
                }
            }
            return instances;
        }
    }
}
