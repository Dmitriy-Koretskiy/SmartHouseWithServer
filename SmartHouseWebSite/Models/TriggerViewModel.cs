using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWebSite.Models
{
    public class TriggerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public bool Enable { get; set; }
        public int HouseControllerId { get; set; }
        public int SensorId { get; set; }
        public string HouseControllerName { get; set; }
        public string SensorName { get; set; }
    }
}