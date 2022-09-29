using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    //I Created the IDeviceRepository and added the interface definition
    public interface IZoneRepository : IGenericRepository<Zone>
    {
        bool exists(Guid id); //added Guid as a datatype instead of int
        Zone GetMostRecentZone();
    }
}
