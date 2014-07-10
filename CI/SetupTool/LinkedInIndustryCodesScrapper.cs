using System.Collections.Generic;
using System.IO;
using System.Net;
using CI.Model.Infrastructure.Configuration;
using CI.Service.Models;
using HtmlAgilityPack;

namespace SetupTool
{
    public static class LinkedInIndustryCodesScrapper
    {
        public static IEnumerable<IndustryCodeRowModel> GetIndustryCodeRows()
        {
            string linkedInUrlWithIndustryCodes = ApplicationSettingsFactory.GetApplicationSettings().LinkedInUrlWithIndustryCodes;

            WebRequest webRequest = WebRequest.Create(linkedInUrlWithIndustryCodes);
            webRequest.Method = WebRequestMethods.Http.Get;

            HtmlDocument htmlDocument = new HtmlDocument();
            using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream stream = webResponse.GetResponseStream())
                    htmlDocument.Load(stream);
            
            HtmlNode table = htmlDocument.DocumentNode.SelectSingleNode("//table[contains(@class,'info')]");
            HtmlNode tbody = table.SelectSingleNode("//tbody");
            HtmlNodeCollection trs = tbody.ChildNodes;

            List<IndustryCodeRowModel> industryCodeRows = new List<IndustryCodeRowModel>();

            foreach (HtmlNode tr in trs)
            {
                HtmlNodeCollection trTags = tr.ChildNodes;

                IndustryCodeRowModel industryCodeRow = new IndustryCodeRowModel
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
