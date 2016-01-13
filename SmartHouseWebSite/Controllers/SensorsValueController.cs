using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouseWebSite.Controllers
{
    public class SensorsValueController : Controller
    {
        //
        // GET: /SensorsValue/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /SensorsValue/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SensorsValue/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SensorsValue/Create

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
        // GET: /SensorsValue/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SensorsValue/Edit/5

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
        // GET: /SensorsValue/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SensorsValue/Delete/5

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
