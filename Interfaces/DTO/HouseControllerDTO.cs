using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class HouseControllerDTO : BaseEntityDTO
    {
        [Required]
        public string Name { get; set; }
        public bool Enable { get; set; }
        public int? RoomId { get; set; }
        public int? HouseControllersTypeId { get; set; }
        public string RoomName { get; set; }
        public string HouseControllersTypeName { get; set; }
    }
}
