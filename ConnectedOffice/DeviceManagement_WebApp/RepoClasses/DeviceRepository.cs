using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.RepoClasses;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeviceManagement_WebApp.RepositoryClasses
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Device GetMostRecentCategort()
        {
            throw new System.NotImplementedException();
        }

        public Device GetMostRecentDevice()
        {
            return _context.Device.OrderByDescending(device => device.CreatedDate).FirstOrDefault();
        }
    }
}

