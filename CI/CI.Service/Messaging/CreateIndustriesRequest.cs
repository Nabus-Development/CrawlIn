using System.Collections.Generic;
using CI.Service.Models;

namespace CI.Service.Messaging
{
    public class CreateIndustriesRequest
    {
        public IEnumerable<IndustryCodeRowModel> IndustryCodeRowModels { get; set; }
    }
}
