using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CI.Model.Infrastructure
{
    public class LinkedInIndustryCodesScrapper
    {
        private string _linkedInUrlOfWebPageWithIndustryCodes;

        public LinkedInIndustryCodesScrapper(string linkedInUrlOfWebPageWithIndustryCodes)
        {
            _linkedInUrlOfWebPageWithIndustryCodes = linkedInUrlOfWebPageWithIndustryCodes;
        }
    }
}
