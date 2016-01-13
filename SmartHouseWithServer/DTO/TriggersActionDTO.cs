using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWithServer.DTO
{
    public class TriggersActionDTO
    {
        public int Id { get; set; }
        public DateTime TimeChange { get; set; }
        public string Description { get; set; }
        public int? TriggerId { get; set; }
    }
}
