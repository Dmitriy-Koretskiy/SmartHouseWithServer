using AutoMapper;
using Interfaces.DTO;
using Servises.Services;
using Interfaces;
using Interfaces.Tables;
using SmartHouseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interfaces.MappingServices;

namespace SmartHouseMVC.Controllers
{
    public class SensorsValueController : Controller
    {
        ISensorsValueMappingService sensorsValueMappingService;

        public SensorsValueController(ISensorsValueMappingService sensorsValueMapService) 
        {
            this.sensorsValueMappingService = sensorsValueMapService;
        }

        public ActionResult Index(int roomId)
        {
            if (roomId != 0)
            {
                var sensorsValues = sensorsValueMappingService.GetByRoomId(roomId);
                return View(sensorsValues);
            }
            else
            {
                var sensorsValues = sensorsValueMappingService.GetAll();
                return View(sensorsValues);
            }
        }
    }
}
