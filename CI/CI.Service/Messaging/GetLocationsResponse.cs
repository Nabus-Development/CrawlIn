using System.Collections.Generic;
using CI.Service.ViewModels;

namespace CI.Service.Messaging
{
    public class GetLocationsResponse
    {
        public IEnumerable<LocationViewModel> LocationViewModels { get; set; }
    }
}
