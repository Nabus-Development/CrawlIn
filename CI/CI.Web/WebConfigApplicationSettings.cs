using System.Configuration;
using CI.Model.Infrastructure.Configuration;

namespace CI.Web
{
    public class WebConfigApplicationSettings : IApplicationSettings, IConnectionString
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["CrawlInDbConnectionString"].ConnectionString; }
        }
    }
}
