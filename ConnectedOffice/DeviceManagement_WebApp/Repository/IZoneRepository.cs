using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZoneRepository : IGenericRepository<Zone> //create the interface and implement the repo
    {
        Zone GetMostRecentZone();
    }
}
