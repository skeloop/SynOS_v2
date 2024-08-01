using Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS_v2.Applications
{
    public class Editor : Application
    {
        Panel panel = new Panel();
        public override void Init()
        {
            
        }
        public override void Update()
        {
            ScreenObject.Render();
        }
    }

    public class Panel
    {
        public List<ScreenObject> screenObjects = new();
        public void Render()
        {

        }
    }

    public class ScreenObject
    {
        public int layerOrder = 0;
        public static void Render()
        {                             //. . . . . .|
            Print.Add("screen_object", "    []¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯[]");
            Print.Add("screen_object", "    |  Das ist ein leeres ScreenObject  |");
            Print.Add("screen_object", "    |                                   |");
            Print.Add("screen_object", "    |                                   |");
            Print.Add("screen_object", "    |                                   |");
            Print.Add("screen_object", "    []_________________________________[]");
            Print.PrintContent("screen_object");
        }
    }
}
