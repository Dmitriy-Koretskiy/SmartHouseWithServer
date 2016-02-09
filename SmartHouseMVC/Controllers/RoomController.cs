using AutoMapper;
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
        SensorsValueMappingService sensorsValueMappingService { get; set; }
        

        public RoomController() 
        {
            this.roomMappingService = new RoomMappingService();
            this.sensorsValueMappingService = new SensorsValueMappingService();
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

        public ActionResult RefreshTriggerState(int? triggerId)
        {     
            if (triggerId != null)
            {
                return Json(roomMappingService.GetLastStateOfTrigger((int)triggerId), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("IncorrectTriggerId", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSensorStatisticThisDay(int? sensorId)
        {

            if (sensorId != null)
            {
                return Json(sensorsValueMappingService.GetThisDayBySensorId((int)sensorId), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSensorStatisticLastHour(int? sensorId)
        {
            var oldDate = sensorsValueMappingService.GetById(1);

            var date = (DateTime.Now - oldDate.TimeMeasurement).Days;

            if (sensorId != null)
            {
                return Json(sensorsValueMappingService.GetLastHourBySensorId((int)sensorId), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
     
    }
}
