using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{

    public class DeviceRepository
    {
        ConnectedOfficeContext _context = new ConnectedOfficeContext();
        public IEnumerable<Device> GetAll()
        {
            return _context.Device.ToList();
        }

        public Device GetDeviceID(Guid? Id)
        {
            var device =  _context.Device
               .Include(d => d.Category)
               .Include(d => d.Zone)
               .FirstOrDefault(m => m.DeviceId == Id);
            return device;
        }

        

        public Device CreateDevice(Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _context.Add(device);
            _context.SaveChanges();
            return device;
        }

        public void UpdateDevice(Guid Id, Device device)
        {
            _context.Update(device);
            _context.SaveChanges();

        }

        public Device DeleteDevice(Guid? Id)
        {
            var device = GetDeviceID(Id);
            _context.Device.Remove(device);
            _context.SaveChanges();
            return device;
            
            
        }
        public bool DeviceExist(Guid Id)
        {
            return _context.Device.Any(e => e.DeviceId == Id);
        }


    }
}
