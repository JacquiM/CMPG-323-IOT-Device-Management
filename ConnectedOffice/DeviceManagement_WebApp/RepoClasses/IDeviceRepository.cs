using DeviceManagement_WebApp.Models;


namespace DeviceManagement_WebApp.RepositoryClasses
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        Device GetMostRecentCategort();

    }

}
