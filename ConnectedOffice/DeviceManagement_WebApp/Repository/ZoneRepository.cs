using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Data;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(zone => zone.DateCreated).FirstOrDefault();
        }
    }

}