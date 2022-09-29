using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    //Created a Zone repository class that i want data from 

    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context) //Created the ZoneRepository class that will inherit IZoneRepository  
        {
        }
        public bool exists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
        public Zone GetMostRecentZone()//then implemented the interface 
        {
            return _context.Zone.OrderByDescending(service => service.DateCreated).FirstOrDefault();
        }
    }
}
