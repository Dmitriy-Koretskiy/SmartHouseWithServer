using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace Interfaces.Tables
{
    public class HouseController : ParentTable
    {      
        public string Name { get; set; }
        public int? DeviceId { get; set; }
        public bool Enable { get; set; }

        public virtual Device Device { get; set; }

        public virtual ICollection<Trigger> Triggers { get; set; }

        public HouseController()
        { 
            this.Triggers = new List<Trigger>();
        }
    }
}
