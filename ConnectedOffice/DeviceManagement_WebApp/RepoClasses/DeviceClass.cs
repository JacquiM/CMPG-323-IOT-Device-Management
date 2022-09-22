using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.RepoClasses
{
    public class DeviceClass
    {
        private readonly ConnectedOfficeContext _contex = new ConnectedOfficeContext();

        public List<Device> Getall()
        {
            return _contex.Device.ToList();
        }

    }

}
