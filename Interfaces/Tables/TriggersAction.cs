using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Tables
{
    public class TriggersAction : BaseEntity
    {
        public DateTime TimeChange { get; set; }
        public string Description { get; set; }
        public int? TriggerId { get; set; }

        public virtual Trigger Trigger { get; set; }
    }
}
