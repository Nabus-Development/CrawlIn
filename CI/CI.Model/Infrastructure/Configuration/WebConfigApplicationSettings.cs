using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CI.Model.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings, IConnectionString
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["CrawlInDbConnectionString"].ConnectionString; }
        }
    }
}
