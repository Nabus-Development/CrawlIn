using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CI.Model.Infrastructure;

namespace CI.Service.Messaging
{
    public class CreateIndustriesRequest
    {
        public IEnumerable<IndustryCodeRow> IndustryCodeRows { get; set; }
    }
}
