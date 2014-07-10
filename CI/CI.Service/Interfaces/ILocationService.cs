using CI.Service.Messaging;

namespace CI.Service.Interfaces
{
    public interface ILocationService
    {
        GetLocationsResponse GetLocations(GetLocationsRequest getLocationsRequest);
    }
}
