using System.Collections.Generic;
using CI.Service.ViewModels;

namespace CI.Service.Mapping
{
    public static class JsonLocationExtensionMethods
    {
        public static IEnumerable<LocationViewModel> ConvertToLocationViewModelList(this IEnumerable<JsonLocation> jsonLocations)
        {
            List<LocationViewModel> locationViewModels = new List<LocationViewModel>();

            foreach (var jsonLocation in jsonLocations)
                locationViewModels.Add(jsonLocation.ConvertToLocationViewModel());

            return locationViewModels;
        }

        public static LocationViewModel ConvertToLocationViewModel(this JsonLocation jsonLocation)
        {
            LocationViewModel locationViewModel = new LocationViewModel();
            locationViewModel.Code = jsonLocation.Id;
            locationViewModel.Name = jsonLocation.DisplayName;

            return locationViewModel;
        }
    }
}
