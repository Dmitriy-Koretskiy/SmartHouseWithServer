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
    public class SensorController : Controller
    {
        IMappingService<SensorDTO> sensorMappingService { get; set; }
        IGenericMappingService genericMappingService { get; set; }
        public string test;

        public SensorController() 
        {
            this.sensorMappingService = new SensorMappingService();
            this.genericMappingService = new GenericMappingService();
        }

        public ActionResult Index()
        {
            if (RouteData.Values["roomId"] != null)
            {
                int roomId = Convert.ToInt32(RouteData.Values["roomId"]);
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
