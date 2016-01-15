using AutoMapper;
using SmartHouseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interfaces.DTO;
using Interfaces.Tables;
using BLL.Services;
using Interfaces;

namespace SmartHouseWebSite.Controllers
{
    public class HouseControllerController : Controller
    {
        IGenericMappingService genericMappingService { get; set; }
        IRepository repository { get; set; }

        public HouseControllerController() //should use IoC for service and repository
        {
            this.genericMappingService = new GenericMappingService();
        }

        public ActionResult Index()
        {
            var houseControllers = Mapper.Map<IEnumerable<HouseControllerDTO>, List<HouseControllerViewModel>>(genericMappingService.MapAll<HouseController,HouseControllerDTO>());
            return View(houseControllers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            HouseControllerViewModel houseControllerVM = Mapper.Map<HouseControllerDTO, HouseControllerViewModel>(genericMappingService.MapById<HouseController, HouseControllerDTO>(id));

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
        public ActionResult Create(HouseControllerViewModel houseControllerVM)
        {
            try
            {            
                var controllerDTO = Mapper.Map<HouseControllerViewModel, HouseControllerDTO>(houseControllerVM);
                genericMappingService.Add<HouseControllerDTO, HouseController>(controllerDTO);
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

            HouseControllerViewModel houseControllerVM = Mapper.Map<HouseControllerDTO, HouseControllerViewModel>(genericMappingService.MapById<HouseController, HouseControllerDTO>(id));

            if (houseControllerVM == null)
            {
                return HttpNotFound();
            }
            return View(houseControllerVM);
        }

        [HttpPost]
        public ActionResult Edit(HouseControllerViewModel houseControllerVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<HouseControllerViewModel, HouseControllerDTO>(houseControllerVM);
                genericMappingService.Edit<HouseControllerDTO, HouseController>(controllerDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

           genericMappingService.Delete<HouseController>(id);

           
            return RedirectToAction("Index");
        }
    }
}
