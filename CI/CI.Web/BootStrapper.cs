using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;

namespace CI.Web
{
    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<DependencyRegistry>());
        }
    }
}