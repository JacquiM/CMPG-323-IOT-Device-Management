using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.RepositoryClasses
{
    public interface IZoneRepository : IGenericRepository<Zone>
    {
        Zone GetMostRecentZone();

    }
}

