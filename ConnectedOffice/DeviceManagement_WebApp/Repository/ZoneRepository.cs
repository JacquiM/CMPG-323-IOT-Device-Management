using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
        }
        public bool exists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(service => service.DateCreated).FirstOrDefault();
        }
    }
}
