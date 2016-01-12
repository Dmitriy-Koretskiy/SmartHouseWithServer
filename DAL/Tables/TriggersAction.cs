using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tables
{
    public class TriggersAction
    {
        public int Id { get; set; }
        public DateTime TimeChange { get; set; }
        public string Description { get; set; }
        public int? TriggerId { get; set; }

        public virtual Trigger Trigger { get; set; }
    }
}
