using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Tables
{
    public class SensorsValue : ParentTable
    {
        public DateTime TimeMeasurement { get; set; }
        public int Value { get; set; }
        public int? SensorId { get; set; }

        public virtual Sensor Sensor { get; set; }
    }
}
