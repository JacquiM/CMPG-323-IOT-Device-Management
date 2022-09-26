using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DeviceManagement_WebApp.Models
{
    public partial class Device
    {
        [DisplayName("Device ID")]
        public Guid DeviceId { get; set; }
        [DisplayName("Device Name")]
        public string DeviceName { get; set; }
        [DisplayName("Category ID")]
        public Guid CategoryId { get; set; }
        [DisplayName("Zone ID")]
        public Guid ZoneId { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        [DisplayName("Is Active")]
        public bool IsActvie { get; set; }
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Category")]
        public virtual Category Category { get; set; }
        [DisplayName("Zone")]
        public virtual Zone Zone { get; set; }
    }
}
