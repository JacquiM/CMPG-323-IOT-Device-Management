using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;


namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository : GenericRepository<Device>, IDevicesRepository
    {
        public DevicesRepository(ConnectedOfficeContext context) : base(context)
        {
        }


    }

}