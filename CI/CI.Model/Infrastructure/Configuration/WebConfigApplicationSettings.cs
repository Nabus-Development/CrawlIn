using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CI.Model.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["CrawlInDatabaseConnectionString"]; }
        }
    }
}
