using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseMVC.Models
{
    public class SensorsValueViewModel
    {
        public int Id { get; set; }
        public DateTime TimeMeasurement { get; set; }
        public int Value { get; set; }
        public string SensorName { get; set; }
    }
}