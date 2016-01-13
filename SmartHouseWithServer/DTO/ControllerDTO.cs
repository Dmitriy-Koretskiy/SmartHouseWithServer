using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWithServer.DTO
{
    public class ControllerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }
        public int? DeviceId { get; set; }
    }
}
