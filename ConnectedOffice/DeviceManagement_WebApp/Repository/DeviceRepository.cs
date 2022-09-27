using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Data;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Device GetMostRecentDevice()
        {
            return _context.Device.OrderByDescending(device => device.DateCreated).FirstOrDefault();
        }
    }

}

