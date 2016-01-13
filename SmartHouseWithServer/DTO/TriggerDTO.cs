using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWithServer.DTO
{
    public class TriggerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public bool Enable { get; set; }
        public int? ControllerId { get; set; }
        public int? SensorId { get; set; }
    }
}
