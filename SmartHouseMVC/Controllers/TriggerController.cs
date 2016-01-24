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
    public class TriggerController : Controller
    {   
        IMappingService triggerMappingService { get; set; }
        IGenericMappingService genericMappingService { get; set; }
        IRepository repository { get; set; }

        public TriggerController() //should use IoC for service and repository
        {
            this.triggerMappingService = new TriggerMappingService();
            this.genericMappingService = new GenericMappingService();
        }

        public ActionResult Index()
        {
            var triggers = Mapper.Map<IEnumerable<TriggerDTO>, List<TriggerViewModel>>(triggerMappingService.GetAll());
            return View(triggers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriggerViewModel triggerVM = Mapper.Map<TriggerDTO, TriggerViewModel>(triggerMappingService.GetById(id));

            if (triggerVM == null)
            {
                return HttpNotFound();
            }
            return View(triggerVM);
        }

        public ActionResult Create()
        {
            ViewBag.houseControllers = Mapper.Map<IEnumerable<HouseControllerDTO>, List<HouseControllerViewModel>>(genericMappingService.MapAll<HouseController, HouseControllerDTO>());
            ViewBag.sensors = Mapper.Map<IEnumerable<SensorDTO>, List<SensorViewModel>>(genericMappingService.MapAll<Sensor, SensorDTO>());

            return View();
        }

        [HttpPost]
        public ActionResult Create(TriggerViewModel triggerVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<TriggerViewModel, TriggerDTO>(triggerVM);
                triggerMappingService.Add(controllerDTO);
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

            TriggerViewModel triggerVM = Mapper.Map<TriggerDTO, TriggerViewModel>(triggerMappingService.GetById(id));

            if (triggerVM == null)
            {
                return HttpNotFound();
            }

            ViewBag.houseControllers = Mapper.Map<IEnumerable<HouseControllerDTO>, List<HouseControllerViewModel>>(genericMappingService.MapAll<HouseController, HouseControllerDTO>());
            ViewBag.sensors = Mapper.Map<IEnumerable<SensorDTO>, List<SensorViewModel>>(genericMappingService.MapAll<Sensor, SensorDTO>());

            return View(triggerVM);
        }

        [HttpPost]
        public ActionResult Edit(TriggerViewModel triggerVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<TriggerViewModel, TriggerDTO>(triggerVM);
                triggerMappingService.Edit(controllerDTO);
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
                //TODO: Add Massege Error
                return RedirectToAction("Index");
            }
           
        }
    }
}
