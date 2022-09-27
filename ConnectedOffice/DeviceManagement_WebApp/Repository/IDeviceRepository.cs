using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device> // create and implement repository
    {
        Device GetMostRecentDevice();
    }
}

