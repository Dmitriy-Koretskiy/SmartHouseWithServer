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
    public class SensorController : Controller
    {
        IMappingService<SensorDTO> sensorMappingService;
        IGenericMappingService genericMappingService;
        public string test;

        public SensorController(IMappingService<SensorDTO> sensorMapService, IGenericMappingService genericMapService) 
        {
            this.sensorMappingService = sensorMapService;
            this.genericMappingService = genericMapService;
        }

        public ActionResult Index(int roomId)
        {
            if (roomId != 0)
            {
                var sensors = sensorMappingService.GetByRoomId(roomId);
                return View(sensors);
            }
            else
            {
                var sensors = sensorMappingService.GetAll();
                return View(sensors);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SensorDTO sensorVM = genericMappingService.MapById<Sensor, SensorDTO>(id);

            if (sensorVM == null)
            {
                return HttpNotFound();
            }
            return View(sensorVM);
        }

        public ActionResult Create()
        {
            ViewBag.sensorsTypes = genericMappingService.MapAll<SensorsType, SensorsTypeDTO>();
            ViewBag.rooms = genericMappingService.MapAll<Room, RoomDTO>();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SensorDTO sensorDTO)
        {
            try
            {
                genericMappingService.Add<SensorDTO, Sensor>(sensorDTO);
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

            SensorDTO sensorDTO = genericMappingService.MapById<Sensor, SensorDTO>(id);

            if (sensorDTO == null)
            {
                return HttpNotFound();
            }

            ViewBag.sensorsTypes = genericMappingService.MapAll<SensorsType, SensorsTypeDTO>();
            ViewBag.rooms = genericMappingService.MapAll<Room, RoomDTO>();

            return View(sensorDTO);
        }

        [HttpPost]
        public ActionResult Edit(SensorDTO sensorDTO)
        {
            try
            {
                genericMappingService.Edit<SensorDTO, Sensor>(sensorDTO);
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

                genericMappingService.Delete<Sensor>(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
