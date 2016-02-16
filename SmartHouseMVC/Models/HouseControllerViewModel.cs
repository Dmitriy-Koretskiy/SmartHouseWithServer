﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouseMVC.Models
{
    public class HouseControllerViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Enable { get; set; }
        public int? RoomId { get; set; }
        public int? HouseControllersTypeId { get; set; }

        public string RoomName { get; set; }
        public string HouseControllersTypeName { get; set; }
    }
}