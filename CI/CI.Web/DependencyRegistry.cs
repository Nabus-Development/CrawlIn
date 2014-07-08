using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CI.Model.Infrastructure.Configuration;
using StructureMap.Configuration.DSL;

namespace CI.Web
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            // Application Settings
            For<IApplicationSettings>().Use<WebConfigApplicationSettings>();
        }
    }
}