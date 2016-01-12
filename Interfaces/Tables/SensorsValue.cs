using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Tables
{
    public class SensorsValue : ParentIClass
    {
        public DateTime TimeMeasurement { get; set; }
        public int Value { get; set; }
        public int? SensorId { get; set; }

        public Sensor Sensor { get; set; }
    }
}
