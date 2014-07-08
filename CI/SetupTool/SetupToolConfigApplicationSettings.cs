using System.Configuration;
using CI.Model.Infrastructure.Configuration;

namespace SetupTool
{
    public class SetupToolConfigApplicationSettings : IApplicationSettings
    {
        private string _connectionString;

        public SetupToolConfigApplicationSettings(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }
    
        public string  LinkedInUrlWithIndustryCodes
        {
            get { return ConfigurationManager.AppSettings["LinkedInUrlWithIndustryCodes"]; }
        }
    }
}
