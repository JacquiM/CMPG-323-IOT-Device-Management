using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.RepoClasses;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DeviceManagement_WebApp.RepositoryClasses
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(zone => zone.CreatedDate).FirstOrDefault();
        }


    }
}
