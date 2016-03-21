using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class TriggersSettingDTO : BaseEntityDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Condition { get; set; }
        public bool Enable { get; set; }
        public int? HouseControllerId { get; set; }
        public int? SensorId { get; set; }
        public int? RoomId { get; set; }
        public int? TriggersTypeId { get; set; }
        public string HouseControllerName { get; set; }
        public string RoomName { get; set; }
        public string SensorName { get; set; }
        public string TriggersTypeName { get; set; }
    }
}
