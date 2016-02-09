using AutoMapper;
using Interfaces.DTO;
using DTO.Services;
using Interfaces;
using Interfaces.Tables;
using SmartHouseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouseWebSite.Controllers
{
    public class SensorsValueController : Controller
    {
        IMappingService<SensorsValueDTO> sensorsValueMappingService { get; set; }

        public SensorsValueController() 
        {
            this.sensorsValueMappingService = new SensorsValueMappingService();
        }

        public ActionResult Index()
        {
            int roomId = Convert.ToInt32(RouteData.Values["roomId"]);

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
