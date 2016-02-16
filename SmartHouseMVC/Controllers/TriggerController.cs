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
    public class TriggerController : Controller
    {
        IMappingService<TriggerDTO> triggerMappingService;
        IGenericMappingService genericMappingService;

        public TriggerController(IGenericMappingService genericMapService, IMappingService<TriggerDTO> triggerMapService) 
        {
            this.triggerMappingService = triggerMapService;
            this.genericMappingService = genericMapService;
        }

        
        public ActionResult Index(int roomId)
        {
            if (roomId != 0)
            {               
                var triggers = triggerMappingService.
                    GetByRoomId(roomId);
                return View(triggers);
            }
            else
            {
                var triggers = triggerMappingService.GetAll();
                return View(triggers);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriggerDTO triggerDTO = triggerMappingService.GetById(id);

            if (triggerDTO == null)
            {
                return HttpNotFound();
            }
            return View(triggerDTO);
        }

        public ActionResult Create()
        {
            ViewBag.houseControllers = genericMappingService.MapAll<HouseController, HouseControllerDTO>();
            ViewBag.sensors = genericMappingService.MapAll<Sensor, SensorDTO>();
            ViewBag.triggersTypes = genericMappingService.MapAll<TriggersType, TriggersTypeDTO>();
            ViewBag.rooms = genericMappingService.MapAll<Room, RoomDTO>();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TriggerDTO triggerDTO)
        {
            try
            {
                triggerMappingService.Add(triggerDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriggerDTO triggerDTO = triggerMappingService.GetById(id);

            if (triggerDTO == null)
            {
                return HttpNotFound();
            }

            ViewBag.houseControllers = genericMappingService.MapAll<HouseController, HouseControllerDTO>();
            ViewBag.sensors = genericMappingService.MapAll<Sensor, SensorDTO>();
            ViewBag.triggersTypes = genericMappingService.MapAll<TriggersType, TriggersTypeDTO>();
            ViewBag.rooms = genericMappingService.MapAll<Room, RoomDTO>();

            return View(triggerDTO);
        }

        [HttpPost]
        public ActionResult Edit(TriggerDTO triggerDTO)
        {
            try
            {
                triggerMappingService.Edit(triggerDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return HttpNotFound();
                }

                triggerMappingService.Delete(id);
                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("Index");
            }          
        }
    }
}
