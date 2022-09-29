using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    //I Created the IDeviceRepository and added the interface definition
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        bool exists(Guid id); //added Guid as a datatype instead of int
        Device GetMostRecentDevice();
        Device GetDeviceById(Guid id); //added Guid as a datatype instead of int
    }
}
