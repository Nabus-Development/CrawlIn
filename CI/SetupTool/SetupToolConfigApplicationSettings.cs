using CI.Model.Infrastructure.Configuration;

namespace SetupTool
{
    public class SetupToolConfigApplicationSettings : IApplicationSettings, IConnectionString
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
    }
}
