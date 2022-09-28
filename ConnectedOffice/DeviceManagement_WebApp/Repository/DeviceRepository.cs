using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.IRepository;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{

    public class DeviceRepository : IDeviceRepository
    {
        private readonly ConnectedOfficeContext _context;
        public DeviceRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets all Devices from database
        /// </summary>
        /// <returns>List of devices</returns>
        public IEnumerable<Device> GetAll()
        {
            return _context.Device
               .Include(d => d.Category)
               .Include(d => d.Zone).ToList();
        }

        /// <summary>
        /// Finds devices by specific ID field
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Devices matching specified ID</returns>

        public Device GetDeviceID(Guid? Id)
        {
            var device =  _context.Device
               .Include(d => d.Category)
               .Include(d => d.Zone)
               .FirstOrDefault(m => m.DeviceId == Id);
            return device;
        }

        
        /// <summary>
        /// Creates a device
        /// </summary>
        /// <param name="device"></param>
        /// <returns>Newly created Device</returns>
        public Device CreateDevice(Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _context.Add(device);
            _context.SaveChanges();
            return device;
        }
        /// <summary>
        /// Updates existing Device
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="device"></param>
        public void UpdateDevice(Guid Id, Device device)
        {
            _context.Update(device);
            _context.SaveChanges();

        }
        /// <summary>
        /// Removes a specified device
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Device DeleteDevice(Guid? Id)
        {
            var device = GetDeviceID(Id);
            _context.Device.Remove(device);
            _context.SaveChanges();
            return device;
            
            
        }
        /// <summary>
        /// Determines if the device exists
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>true or false</returns>
        public bool DeviceExist(Guid Id)
        {
            return _context.Device.Any(e => e.DeviceId == Id);
        }


    }
}
