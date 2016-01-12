using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Tables
{
    public  class Controller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DeviceId { get; set; }

        public virtual Device Device { get; set; }

        public virtual ICollection<Trigger> Triggers { get; set; }

        public Controller()
        { 
            this.Triggers = new List<Trigger>();
        }
    }
}
