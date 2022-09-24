using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Interfaces
{
    public interface IZonesRepository : IGenericRepository<Zone>
    {
        bool Exists(Guid? id);
    }
}