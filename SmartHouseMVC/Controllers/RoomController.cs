using DTO.Services;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouseWebSite.Controllers
{
    public class RoomController : Controller
    {
        IGenericMappingService genericMappingService { get; set; }
       // IRepository repository { get; set; }
        int roomId = 0;

        public RoomController() //should use IoC for service and repository
        {
            this.genericMappingService = new GenericMappingService();
        }
        //
        // GET: /Room/
    
        public ActionResult Index(int roomId)
        {
            string controller = RouteData.Values["controller"].ToString();
            this.roomId = roomId;
            return View();
        }

        //
        // GET: /Room/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Room/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Room/Create

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
        // GET: /Room/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Room/Edit/5

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
        // GET: /Room/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Room/Delete/5

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
