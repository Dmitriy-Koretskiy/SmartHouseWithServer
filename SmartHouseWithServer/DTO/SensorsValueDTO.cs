using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWithServer.DTO
{
    class SensorsValueDTO
    {
        public int Id { get; set; }
        public DateTime TimeMeasurement { get; set; }
        public int Value { get; set; }
        public int? SensorId { get; set; }
    }
}
