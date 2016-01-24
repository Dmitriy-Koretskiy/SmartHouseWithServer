﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class SensorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }
        public int? RoomId { get; set; }
        public int? SensorsTypeId { get; set; } 
        public string RoomName { get; set; }
        public string SensorsTypeName { get; set; }
    }
}
