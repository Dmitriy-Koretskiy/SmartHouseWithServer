using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWebSite.Models
{
    public class TriggersAcionViewModel
    {
        public int Id { get; set; }
        public DateTime TimeChange { get; set; }
        public string Description { get; set; }
        public int? TriggerId { get; set; }
    }
}