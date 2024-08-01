using System.Reflection;
using Libary;

namespace SynOS_v2
{
    public class ApplicationManager
    {
        public static List<Application> GetApplications(string applicationNameSpace)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
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
