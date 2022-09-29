using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    //Created a Category repository class that i want data from 
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context) //Created the DeviceRepository class that will inherit IDeviceRepository  
        {


        }
        public bool exists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
        public Device GetMostRecentDevice()//then implemented the interface 
        {

            return _context.Device.Include(d => d.Category).Include(d => d.Zone).OrderByDescending(service => service.DateCreated).FirstOrDefault();
        }
        public Device GetDeviceById(Guid id)
        {

            return _context.Device.Where(m => m.DeviceId == id).Include(d => d.Category).Include(d => d.Zone).FirstOrDefault();
        }

    }
}
