using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace Interfaces.Tables
{
    public class Trigger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public int? ControllerId { get; set; }
        public int? SensorId { get; set; }

        public virtual Controller Controller { get; set; }
        public virtual Sensor Sensor { get; set; }

        public virtual ICollection<TriggersAction> TriggersActions { get; set; }

        public Trigger()
        {
            this.TriggersActions = new List<TriggersAction>();
        }
    }
}
