using DeviceManagement_WebApp.Models;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Interfaces
{
    public interface IDevicesRepository : IGenericRepository<Device>
    {
        bool Exists(Guid id);
        new Task<Device> FindAsync(Guid? id);
        IEnumerable getCategories();
        IEnumerable getZones();
    }
}