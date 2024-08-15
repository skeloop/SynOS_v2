using System;
using System.Security.Cryptography;
using Libary;
using Libary.Extension;


namespace SynOS_v2.Applications
{
    public class Animations : Application
    {
        string[] strings = [
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "1", "2", "3", "4", "5", "6", "7", "8", "9"
            ];
        public override void Init()
        {

        }

        public override void Update()
        {
            for (int i = 0; i < 100; i++)
            {
                GenText();
                Console.WriteLine("");
            }
            Console.ReadKey();
        }

        void GenText()
        {
            for (int i = 0; i < 100; i++)
            {
                $"&4{strings[RandomNumberGenerator.GetInt32(strings.Length)].ToUpper()} ".Write();
            }
        }
    }
}
