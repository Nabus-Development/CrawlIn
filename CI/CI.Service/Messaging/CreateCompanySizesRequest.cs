using System.Collections.Generic;
using CI.Service.Models;

namespace CI.Service.Messaging
{
    public class CreateCompanySizesRequest
    {
        public List<CompanySizeModel> CompanySizeModels { get; set; }
    }
}
