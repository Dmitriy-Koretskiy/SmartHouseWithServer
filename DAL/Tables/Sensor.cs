using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Tables
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Trigger> Triggers { get; set; }
        public virtual ICollection<SensorsValue> SensorValues { get; set; }

        public Sensor()
        { 
            this.Triggers = new List<Trigger>();
            this.SensorValues = new List<SensorsValue>();
        }
    }
}
