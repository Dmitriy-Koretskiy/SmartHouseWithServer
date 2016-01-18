using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class SensorsValueDTO
    {
        public int Id { get; set; }
        public DateTime TimeMeasurement { get; set; }
        public int Value { get; set; }
        public string SensorName { get; set; }
    }
}
