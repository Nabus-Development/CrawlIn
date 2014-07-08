using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Text;
using CI.Model.Infrastructure.Configuration;
using HtmlAgilityPack;

namespace CI.Model.Infrastructure
{
    public static class LinkedInIndustryCodesScrapper
    {
        public static IEnumerable<IndustryCodeRow> GetIndustryCodeRows()
        {
            string linkedInUrlWithIndustryCodes = ApplicationSettingsFactory.GetApplicationSettings().LinkedInUrlWithIndustryCodes;

            WebRequest httpWebRequest = WebRequest.Create(linkedInUrlWithIndustryCodes);
            httpWebRequest.Method = "GET";

            WebResponse webResponse = httpWebRequest.GetResponse();

            Stream stream = webResponse.GetResponseStream();

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(stream);
            
            HtmlNode table = htmlDocument.DocumentNode.SelectSingleNode("//table[contains(@class,'info')]");
            HtmlNode tbody = table.SelectSingleNode("//tbody");
            HtmlNodeCollection trs = tbody.ChildNodes;

            List<IndustryCodeRow> industryCodeRows = new List<IndustryCodeRow>();

            foreach (HtmlNode tr in trs)
            {
                HtmlNodeCollection trTags = tr.ChildNodes;

                IndustryCodeRow industryCodeRow = new IndustryCodeRow
                {
                    Code = trTags[0].InnerText,
                    Group = trTags[2].InnerText,
                    Description = trTags[4].InnerText
                };

                industryCodeRows.Add(industryCodeRow);
            }

            return industryCodeRows;
        }
    }
}
