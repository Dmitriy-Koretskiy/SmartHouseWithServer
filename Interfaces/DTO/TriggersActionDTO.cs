using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class TriggersActionDTO : BaseEntityDTO
    {
        public DateTime TimeChange { get; set; }
        public string Description { get; set; }
        public string TriggerName { get; set; }
    }
}
