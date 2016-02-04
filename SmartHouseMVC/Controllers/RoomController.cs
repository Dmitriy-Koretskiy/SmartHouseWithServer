using DTO.Services;
using Interfaces;
using Interfaces.DTO;
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
        IMappingService<TriggerDTO> triggerMappingService { get; set; }

        int roomId = 0;

        public RoomController() //should use IoC for service
        {
            this.roomMappingService = new RoomMappingService();
            this.sensorMappingService = new SensorMappingService();
            this.triggerMappingService = new TriggerMappingService();
        }

    
        public ActionResult Index(int? roomId)
        {
            if (roomId == null)
            {
                return RedirectToAction("Index", "Home", null);
            }

            string controller = RouteData.Values["controller"].ToString();
            this.roomId = (int)roomId;
            return View();
        }
    }
}
