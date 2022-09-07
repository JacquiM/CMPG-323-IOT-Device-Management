using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class Device
    {
        public Guid DeviceId { get; set; }
        public string DeviceName { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ZoneId { get; set; }
        public string Status { get; set; }
        public bool IsActvie { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
