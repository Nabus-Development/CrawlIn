using CI.Model.Infrastructure.Configuration;
using CI.Service;
using CI.Service.Interfaces;
using StructureMap.Configuration.DSL;

namespace CI.Web
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            // Application Settings
            For<IApplicationSettings>().Use<WebConfigApplicationSettings>();

            // Services
            For<ILocationService>().Use<LocationService>().Ctor<string>(ApplicationSettingsFactory.GetApplicationSettings().LinkedInUrlWithLocations);
        }
    }
}
