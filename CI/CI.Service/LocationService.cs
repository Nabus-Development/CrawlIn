using System.IO;
using System.Net;
using CI.Service.Interfaces;
using CI.Service.Mapping;
using CI.Service.Messaging;
using Newtonsoft.Json;

namespace CI.Service
{
    public class LocationService : ILocationService
    {
        private string _linkedInUrlWithLocations;

        public LocationService(string linkedInUrlWithLocations)
        {
            _linkedInUrlWithLocations = linkedInUrlWithLocations;
        }

        public GetLocationsResponse GetLocations(GetLocationsRequest getLocationsRequest)
        {
            GetLocationsResponse getLocationsResponse = new GetLocationsResponse();

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_linkedInUrlWithLocations + getLocationsRequest.Query);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";

            string jsonLocationList = null;
            using (WebResponse webResponse = httpWebRequest.GetResponse())
                using (Stream stream = webResponse.GetResponseStream())
                    if (stream != null)
                        using (StreamReader streamReader = new StreamReader(stream))
                            jsonLocationList = streamReader.ReadToEnd();

            JsonLocationListObject jsonLocationListObject = JsonConvert.DeserializeObject<JsonLocationListObject>(jsonLocationList);

            getLocationsResponse.LocationViewModels = jsonLocationListObject.ResultList.ConvertToLocationViewModelList();

            return getLocationsResponse;
        }
    }
}
