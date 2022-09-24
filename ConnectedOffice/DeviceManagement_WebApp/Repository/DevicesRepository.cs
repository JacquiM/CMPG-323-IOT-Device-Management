using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Interfaces;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository : GenericRepository<Device>, IDevicesRepository
    {
        public DevicesRepository(ConnectedOfficeContext context) : base(context)
        {
        }
        public bool Exists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
        new public async Task<Device> FindAsync(Guid? id)
        {
            return await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
        }
        public IEnumerable getCategories()
        {
            return _context.Category;
        }
        public IEnumerable getZones()
        {
            return _context.Zone;
        }
    }
}