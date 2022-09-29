using DeviceManagement_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DeviceManagement_WebApp.Models;



public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
{
    public ZoneRepository(ConnectedOfficeContext context) : base(context)
    {
    }

}


