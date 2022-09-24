using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository
    {
        protected readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        // GET ALL: Products
        public IEnumerable<Device> GetAll()
        {
            return _context.Device.ToList();
        }

        // TO DO: Add ‘Get By Id’
        // TO DO: Add ‘Create’
        // TO DO: Add ‘Edit’
        // TO DO: Add ‘Delete’
        // TO DO: Add ‘Exists’

    }
}