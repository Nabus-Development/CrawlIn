using System;
using System.Configuration;
using CI.Model.Infrastructure.Configuration;

namespace CI.Web
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["CrawlInDbConnectionString"].ConnectionString; }
        }

        public string LinkedInUrlWithIndustryCodes
        {
            get { throw new NotImplementedException(); }
        }
    }
}
