using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.IRepository
{
    /// <summary>
    /// Interface For Zone repository
    /// </summary>
    public interface IZoneRepository
    {
        IEnumerable<Zone> GetAll();
        Zone GetZoneID(Guid? Id);
        Zone CreateZone(Zone zone);
        void UpdateZone(Guid? Id, Zone zone);
        Zone DeleteZone(Guid? Id);
        bool ZoneExist(Guid Id);

    }
}
