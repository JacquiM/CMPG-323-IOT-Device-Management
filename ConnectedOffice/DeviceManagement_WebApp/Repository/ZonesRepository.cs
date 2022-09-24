using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Interfaces;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository : GenericRepository<Zone>, IZonesRepository
    {
        public ZonesRepository(ConnectedOfficeContext context) : base(context)
        {
        }
        public bool Exists(Guid? id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
    }
}