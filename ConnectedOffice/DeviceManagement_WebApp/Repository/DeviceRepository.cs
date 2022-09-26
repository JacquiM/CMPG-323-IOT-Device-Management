using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {


        }
        public bool exists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
        public Device GetMostRecentDevice()
        {
           
            return _context.Device.Include(d => d.Category).Include(d => d.Zone).OrderByDescending(service => service.DateCreated).FirstOrDefault();
        }
        public Device GetDeviceById(Guid id)
        {

            return _context.Device.Where(m => m.DeviceId == id).Include(d => d.Category).Include(d => d.Zone).FirstOrDefault();
        }

    }  
} 
