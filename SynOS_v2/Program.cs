using SynOS_v2;
using SynOS_v2.Applications;
using System.Reflection;
using Libary;
namespace SynOS_v2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                OS.Print(arg);
                Console.ReadKey();
            }

            WindowHelper.SetFullscren();
            Applicationimporter applicationimporter = new Applicationimporter();
            applicationimporter.Start();
            Thread.Sleep(2000);
            Console.ResetColor();
            SynOS_v2.OS.Run();

            Debug.LogAndKeyReturn("Die Anwenung ist aus einem unerwartetem Grund abgestürzt.\n" +
                "Drücke [1] um neuzustarten oder [2] um zu verlassen...", DebugType.fatal);
        }
    }
}


/*



*/



namespace SynOS_v2
{
    public class ExampleClass
    {
        public int publicField = 10;
        private string privateField = "Private Field";
        protected bool protectedField = true;

        public void PublicMethod() { }
        private void PrivateMethod() { }
        protected void ProtectedMethod() { }
    }
}

