using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        Device GetMostRecentDevice();
    }


}