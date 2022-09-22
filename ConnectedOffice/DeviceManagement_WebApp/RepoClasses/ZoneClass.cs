using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.RepoClasses
{
    public class ZoneClass
    {
        private readonly ConnectedOfficeContext contex_ = new ConnectedOfficeContext();

        public List<Zone> Getall()
        {
            return contex_.Zone.ToList();
        }

    }
}
