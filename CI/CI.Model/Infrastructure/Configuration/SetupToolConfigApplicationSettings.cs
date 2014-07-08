using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CI.Model.Infrastructure.Configuration
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
