using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository
    {
        ConnectedOfficeContext _context = new ConnectedOfficeContext();
        public IEnumerable<Zone> GetAll()
        {
            return _context.Zone.ToList();
        }

        public Zone GetZoneID(Guid? Id)
        {
            var zone = _context.Zone
               .FirstOrDefault(m => m.ZoneId == Id);
            return zone;
        }

        public Zone CreateZone(Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _context.Add(zone);
            _context.SaveChanges();
            return zone;
        }

        public void UpdateZone(Guid? Id, Zone zone)
        {
            _context.Update(zone);
            _context.SaveChanges();
        }

        public Zone DeleteZone(Guid Id)
        {
            var zone = GetZoneID(Id);
            _context.Zone.Remove(zone);
            _context.SaveChanges();
            return zone;

        }

        public bool ZoneExist(Guid Id)
        {
            return _context.Zone.Any(e => e.ZoneId == Id);
        }

    }
}
