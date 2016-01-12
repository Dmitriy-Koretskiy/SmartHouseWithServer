using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Tables
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public virtual ICollection<Controller> Controllers { get; set; }

        public Device()
        { 
            this.Controllers = new List<Controller>();
        }
    }
}
