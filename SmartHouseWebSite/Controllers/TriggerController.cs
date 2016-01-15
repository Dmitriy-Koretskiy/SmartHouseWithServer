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
    public class TriggerController : Controller
    {   //!!!!! change to intarface
        TriggerMappingService mappingService { get; set; }
        IRepository repository { get; set; }

        public TriggerController() //should use IoC for service and repository
        {
            this.mappingService = new TriggerMappingService();
        }

        public ActionResult Index()
        {
            var houseControllers = Mapper.Map<IEnumerable<TriggerDTO>, List<TriggerViewModel>>(mappingService.GetAllFromDB());
            return View(houseControllers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TriggerViewModel houseControllerVM = Mapper.Map<TriggerDTO, TriggerViewModel>(mappingService.GetByIdFromDB(id));

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
        public ActionResult Create(TriggerViewModel houseControllerVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<TriggerViewModel, TriggerDTO>(houseControllerVM);
                mappingService.AddToDB(controllerDTO);
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

            TriggerViewModel houseControllerVM = Mapper.Map<TriggerDTO, TriggerViewModel>(mappingService.GetByIdFromDB(id));

            if (houseControllerVM == null)
            {
                return HttpNotFound();
            }
            return View(houseControllerVM);
        }

        [HttpPost]
        public ActionResult Edit(TriggerViewModel houseControllerVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<TriggerViewModel, TriggerDTO>(houseControllerVM);
                mappingService.Edit(controllerDTO);
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

            mappingService.Delete(id);


            return RedirectToAction("Index");
        }
    }
}
