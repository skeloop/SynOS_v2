using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS_v2
{
    public enum DebugType { info, warning, error, fatal }
    public static class Debug
    {
        static bool timeDebugging = false;

        static double lastSeconds = 0;
        static double lastMiliSeconds = 0;
        /// <summary>
        /// Sendet eine Debug-Log Nachricht an die Konsole
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="debugType"></param>
        /// <param name="waitForKeyInput"></param>
        public static void Log(string msg, DebugType debugType = DebugType.info, bool waitForKeyInput = false)
        {
            DateTime dateTime = DateTime.Now;
            
            ConsoleColor color = ConsoleColor.Gray;
            string output = "";
            switch (debugType)
            {
                case DebugType.info:
                    output = "[Info] > ";
                    break;
                case DebugType.warning:
                    color = ConsoleColor.Yellow;
                    output = "[Warning] > ";
                    break;
                case DebugType.error:
                    color = ConsoleColor.Red;
                    output = "[Error] > ";
                    break;
                case DebugType.fatal:
                    color = ConsoleColor.DarkRed;
                    output = "[Fatal Error] > ";
                    break;
            }

            if (timeDebugging) output = $"{output}Zeitunterschied zum letzten Aufruf: {dateTime.TimeOfDay.TotalSeconds - lastSeconds}|{dateTime.TimeOfDay.TotalMilliseconds - lastMiliSeconds}";

            output = output + dateTime.TimeOfDay.ToString();
            output = output + "\n" + msg;
            Console.ForegroundColor = color;
            Console.WriteLine(output);
            lastSeconds = dateTime.TimeOfDay.TotalSeconds;
            lastMiliSeconds = dateTime.TimeOfDay.TotalMilliseconds;

            if (waitForKeyInput ) Console.ReadKey();
        }
        /// <summary>
        /// Sendet eine Nachricht an die Konsole
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="debugType"></param>
        /// <returns>Der ConsoleKey der gedrückt wurde</returns>
        public static ConsoleKey LogAndKeyReturn(string msg, DebugType debugType = DebugType.info)
        {
            DateTime dateTime = DateTime.Now;

            ConsoleColor color = ConsoleColor.Gray;
            string output = "";
            switch (debugType)
            {
                case DebugType.info:
                    output = "[Info] > ";
                    break;
                case DebugType.warning:
                    color = ConsoleColor.Yellow;
                    output = "[Warning] > ";
                    break;
                case DebugType.error:
                    color = ConsoleColor.Red;
                    output = "[Error] > ";
                    break;
                case DebugType.fatal:
                    color = ConsoleColor.DarkRed;
                    output = "[Fatal Error] > ";
                    break;
            }

            if (timeDebugging) output = $"{output}Zeitunterschied zum letzten Aufruf: {dateTime.TimeOfDay.TotalSeconds - lastSeconds}|{dateTime.TimeOfDay.TotalMilliseconds - lastMiliSeconds}";

            output = output + dateTime.TimeOfDay.ToString();
            output = output + "\n" + msg;
            Console.ForegroundColor = color;
            Console.WriteLine(output);
            lastSeconds = dateTime.TimeOfDay.TotalSeconds;
            lastMiliSeconds = dateTime.TimeOfDay.TotalMilliseconds;

            return Console.ReadKey().Key;
        }
    }

}
