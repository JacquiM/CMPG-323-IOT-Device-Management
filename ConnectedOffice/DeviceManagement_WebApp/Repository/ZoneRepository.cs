using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.IRepository;
using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly ConnectedOfficeContext _context;
        public ZoneRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets all Zones
        /// </summary>
        /// <returns>List of zones</returns>
        public IEnumerable<Zone> GetAll()
        {
            return _context.Zone.ToList();
        }
        /// <summary>
        /// Gets a specific zone
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Zone specified by ID</returns>
        public Zone GetZoneID(Guid? Id)
        {
            var zone = _context.Zone
               .FirstOrDefault(m => m.ZoneId == Id);
            return zone;
        }
        /// <summary>
        /// Creates a new xone
        /// </summary>
        /// <param name="zone"></param>
        /// <returns>newly created zone</returns>
        public Zone CreateZone(Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _context.Add(zone);
            _context.SaveChanges();
            return zone;
        }
        /// <summary>
        /// Updates specified zone
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="zone"></param>
        public void UpdateZone(Guid? Id, Zone zone)
        {
            _context.Update(zone);
            _context.SaveChanges();
        }
        /// <summary>
        /// Removes a specified zone
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Zone DeleteZone(Guid? Id)
        {
            var zone = GetZoneID(Id);
            _context.Zone.Remove(zone);
            _context.SaveChanges();
            return zone;

        }
        /// <summary>
        /// Dtermines if zone exists
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>true or false</returns>
        public bool ZoneExist(Guid Id)
        {
            return _context.Zone.Any(e => e.ZoneId == Id);
        }

   }
}
