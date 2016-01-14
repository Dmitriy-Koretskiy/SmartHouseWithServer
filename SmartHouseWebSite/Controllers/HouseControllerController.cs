using AutoMapper;
using SmartHouseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
using Interfaces.Tables;
using BLL.Services;
using Interfaces;

namespace SmartHouseWebSite.Controllers
{
    public class HouseControllerController : Controller
    {
        //
        // GET: /Ctrl/
        IGenericMappingService genericService { get; set; }
        IRepository repository { get; set; }

        public HouseControllerController() //should use IoC for service and repository
        {
            this.genericService = new GenericMappingService();
        }

        public ActionResult Index()
        {
            var houseControllers = Mapper.Map<IEnumerable<HouseControllerDTO>, List<HouseControllerViewModel>>(genericService.MapAll<HouseController,HouseControllerDTO>());
            return View(houseControllers);
        }

        //
        // GET: /Ctrl/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Ctrl/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ctrl/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ctrl/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            HouseControllerViewModel houseControllerVM = Mapper.Map<HouseControllerDTO, HouseControllerViewModel>(genericService.MapById<HouseController, HouseControllerDTO>(id));

            if (houseControllerVM == null)
            {
                return HttpNotFound();
            }
            return View(houseControllerVM);
        }

        //
        // POST: /Ctrl/Edit/5

        [HttpPost]
        public ActionResult Edit(HouseControllerViewModel houseControllerVM)
        {
            try
            {
                // TODO: Add update logic here
                var controllerDTO = Mapper.Map<HouseControllerViewModel, HouseControllerDTO>(houseControllerVM);
                genericService.AddToDB<HouseControllerDTO, HouseController>(controllerDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ctrl/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Ctrl/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
