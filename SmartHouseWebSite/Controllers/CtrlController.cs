using AutoMapper;
using SmartHouseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouseWithServer.DTO;
using SmartHouseWithServer.Interfaces;
using SmartHouseWithServer.Services;

namespace SmartHouseWebSite.Controllers
{
    public class CtrlController : Controller
    {
        //
        // GET: /Ctrl/
        IControllerService ctrlServie { get; set; }

        public CtrlController() //should use IoC
        {
            this.ctrlServie = new ControllerService();
        }

        public ActionResult Index()
        {
            Mapper.CreateMap<ControllerDTO, ControllerViewModel>();
            var controllers = Mapper.Map<IEnumerable<ControllerDTO>, List<ControllerViewModel>>(ctrlServie.GetControllers());
            return View(controllers);
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Ctrl/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
