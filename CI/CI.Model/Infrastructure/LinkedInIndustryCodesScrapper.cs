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

            HtmlNodeCollection tableRows = htmlDocument.DocumentNode
                .SelectSingleNode("//table[contains(@class,'info')]")
                .SelectSingleNode("//tbody")
                .SelectNodes("//tr");

            List<IndustryCodeRow> industryCodeRows = new List<IndustryCodeRow>();

            foreach (HtmlNode tableRow in tableRows)
            {
                HtmlNodeCollection rowCells = tableRow.SelectNodes("//td");

                IndustryCodeRow industryCodeRow = new IndustryCodeRow
                {
                    Code = rowCells[0].InnerText,
                    Group = rowCells[1].InnerText,
                    Description = rowCells[2].InnerText
                };

                industryCodeRows.Add(industryCodeRow);
            }

            return industryCodeRows;
        }
    }
}
