using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS_v2.Network
{
    public class DirectoryManager
    {
        public string basePath = "D:\\Cloud";

        public string[] neededDirectories = ["Files", "Accounts", "Administration"];

        public void Init()
        {
            foreach(string dir in neededDirectories)
            {
                string path = Path.Combine(basePath, dir);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}
