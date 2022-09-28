using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.RepoClasses
{
    public class ZoneRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        public List<Zone> Getall()
        {
            return _context.Zone.ToList();
        }
    }
}
