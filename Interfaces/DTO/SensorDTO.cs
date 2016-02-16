using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Interfaces.DTO
{
    public class SensorDTO : BaseEntityDTO
    {
        [Required]
        public string Name { get; set; }
        public bool Enable { get; set; }
        public int? RoomId { get; set; }
        public int? SensorsTypeId { get; set; } 
        public string RoomName { get; set; }
        public string SensorsTypeName { get; set; }
    }
}
