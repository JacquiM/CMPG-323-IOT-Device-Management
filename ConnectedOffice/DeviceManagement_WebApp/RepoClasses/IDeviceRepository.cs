using DeviceManagement_WebApp.Models;
using static DeviceManagement_WebApp.RepoClasses.IGenericRepository;

namespace DeviceManagement_WebApp.RepositoryClasses
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        Device GetMostRecentCategort();

    }

}
