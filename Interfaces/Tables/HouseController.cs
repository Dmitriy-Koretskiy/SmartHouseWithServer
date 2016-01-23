using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace Interfaces.Tables
{
    public class HouseController : BaseEntity
    {      
        public string Name { get; set; }
        public bool Enable { get; set; }
        public int? HouseControllersTypeId { get; set; }
        public int? RoomId { get; set; }

        public virtual HouseControllersType HouseControllersType { get; set; }
        public virtual Room Room { get; set; }

        public virtual ICollection<Trigger> Triggers { get; set; }

        public HouseController()
        { 
            this.Triggers = new List<Trigger>();
        }
    }
}
