using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace Interfaces.Tables
{
    public class Trigger : BaseEntity
    {
        public string Name { get; set; }
        public string Condition { get; set; }
        public bool Enable { get; set; }
        public int? HouseControllerId { get; set; }
        public int? SensorId { get; set; }
        public int? TriggersTypeId { get; set; }
        public int? RoomId { get; set; }

        public virtual HouseController HouseController { get; set; }
        public virtual Sensor Sensor { get; set; }
        public virtual TriggersType TriggersType { get; set; }
        public virtual Room Room { get; set; }

        public virtual ICollection<TriggersAction> TriggersActions { get; set; }

        public Trigger()
        {
            this.TriggersActions = new List<TriggersAction>();
        }
    }
}
