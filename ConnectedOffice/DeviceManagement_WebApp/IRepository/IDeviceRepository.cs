using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.IRepository
{
    public interface IDeviceRepository
    {
        /// <summary>
        /// Interface for Device repository
        /// </summary>
        /// <returns></returns>
        IEnumerable<Device> GetAll();
        Device GetDeviceID(Guid? Id);
        Device CreateDevice(Device device);
        void UpdateDevice(Guid Id, Device device);
        Device DeleteDevice(Guid? Id);
        bool DeviceExist(Guid Id);

    }
}
