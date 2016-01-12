using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWebSite.Models
{
    public class SensorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }
    }
}