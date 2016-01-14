﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TriggerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public bool Enable { get; set; }
        public int? HouseControllerId { get; set; }
        public int? SensorId { get; set; }
    }
}