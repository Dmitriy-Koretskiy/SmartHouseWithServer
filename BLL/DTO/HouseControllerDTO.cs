﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class HouseControllerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }
        public int? DeviceId { get; set; }
    }
}