using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseMVC.Models
{
    public class RoomContentViewModel
    {
        public string Name { get; set; }
        public string LastState { get; set; }
        public string TriggerId { get; set; }
        public int SensorId { get; set; }
    }
}