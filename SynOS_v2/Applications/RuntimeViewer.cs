using Libary.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynOS_v2.Applications
{
    public class RuntimeViewer : Application
    {
        public override void Init()
        {
            var assembly = GetType().Assembly;
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                $"┌ Klasse: {type.Name}".Print();
                foreach (var type2 in type.Get)
                {

                }
            }
        }

        public override void Update()
        {

        }
    }
}
