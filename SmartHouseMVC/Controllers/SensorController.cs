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
        IGenericMappingService genericMappingService { get; set; }
        IRepository repository { get; set; }
        public string test;

        public SensorController() //should use IoC for service and repository
        {
            this.genericMappingService = new GenericMappingService();
        }

        public ActionResult Index()
        {
            var sensors = Mapper.Map<IEnumerable<SensorDTO>, List<SensorViewModel>>(genericMappingService.MapAll<Sensor, SensorDTO>());
            return View(sensors);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SensorViewModel sensorVM = Mapper.Map<SensorDTO, SensorViewModel>(genericMappingService.MapById<Sensor, SensorDTO>(id));

            if (sensorVM == null)
            {
                return HttpNotFound();
            }
            return View(sensorVM);
        }

        public ActionResult Create()
        {
            ViewBag.sensorsTypes = Mapper.Map<IEnumerable<SensorsTypeDTO>, List<SensorsTypeViewModel>>(genericMappingService.MapAll<SensorsType, SensorsTypeDTO>());
            ViewBag.rooms = Mapper.Map<IEnumerable<RoomDTO>, List<RoomViewModel>>(genericMappingService.MapAll<Room, RoomDTO>());
            return View();
        }

        [HttpPost]
        public ActionResult Create(SensorViewModel sensorVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<SensorViewModel, SensorDTO>(sensorVM);
                genericMappingService.Add<SensorDTO, Sensor>(controllerDTO);
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

            SensorViewModel sensorVM = Mapper.Map<SensorDTO, SensorViewModel>(genericMappingService.MapById<Sensor, SensorDTO>(id));

            if (sensorVM == null)
            {
                return HttpNotFound();
            }

            ViewBag.sensorsTypes = Mapper.Map<IEnumerable<SensorsTypeDTO>, List<SensorsTypeViewModel>>(genericMappingService.MapAll<SensorsType, SensorsTypeDTO>());
            ViewBag.rooms = Mapper.Map<IEnumerable<RoomDTO>, List<RoomViewModel>>(genericMappingService.MapAll<Room, RoomDTO>());

            return View(sensorVM);
        }

        [HttpPost]
        public ActionResult Edit(SensorViewModel sensorVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<SensorViewModel, SensorDTO>(sensorVM);
                genericMappingService.Edit<SensorDTO, Sensor>(controllerDTO);
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
                //TODO: Add Massege Error
                return RedirectToAction("Index");
            }
        }
    }
}
