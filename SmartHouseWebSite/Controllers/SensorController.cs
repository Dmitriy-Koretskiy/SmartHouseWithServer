using AutoMapper;
using BLL.DTO;
using BLL.Services;
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

        public SensorController() //should use IoC for service and repository
        {
            this.genericMappingService = new GenericMappingService();
        }

        public ActionResult Index()
        {
            var houseControllers = Mapper.Map<IEnumerable<SensorDTO>, List<SensorViewModel>>(genericMappingService.MapAll<Sensor, SensorDTO>());
            return View(houseControllers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SensorViewModel houseControllerVM = Mapper.Map<SensorDTO, SensorViewModel>(genericMappingService.MapById<Sensor, SensorDTO>(id));

            if (houseControllerVM == null)
            {
                return HttpNotFound();
            }
            return View(houseControllerVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SensorViewModel houseControllerVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<SensorViewModel, SensorDTO>(houseControllerVM);
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

            SensorViewModel houseControllerVM = Mapper.Map<SensorDTO, SensorViewModel>(genericMappingService.MapById<Sensor, SensorDTO>(id));

            if (houseControllerVM == null)
            {
                return HttpNotFound();
            }
            return View(houseControllerVM);
        }

        [HttpPost]
        public ActionResult Edit(SensorViewModel houseControllerVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<SensorViewModel, SensorDTO>(houseControllerVM);
                genericMappingService.Edit<SensorDTO, Sensor>(controllerDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            genericMappingService.Delete<Sensor>(id);


            return RedirectToAction("Index");
        }
    }
}
