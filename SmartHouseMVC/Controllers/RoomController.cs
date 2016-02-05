﻿using AutoMapper;
using DTO.Services;
using Interfaces;
using Interfaces.DTO;
using SmartHouseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouseWebSite.Controllers
{
    public class RoomController : Controller
    {
        RoomMappingService roomMappingService { get; set; }
        IMappingService<SensorDTO> sensorMappingService { get; set; }

        int roomId = 0;

        public RoomController() 
        {
            this.roomMappingService = new RoomMappingService();
            this.sensorMappingService = new SensorMappingService();
        }
    
        public ActionResult Index(int? roomId)
        {
            if (roomId == null)
            {
                return RedirectToAction("Index", "Home", null);
            }
            var room = roomMappingService.GetRoomById((int)roomId);
            ViewBag.RoomName = room.Name;
            var triggersStates = roomMappingService.GetLastStatesOfTriggers((int)roomId);
            return View(triggersStates);
        }
    }
}
