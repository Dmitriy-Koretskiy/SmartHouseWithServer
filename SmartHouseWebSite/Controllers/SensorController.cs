using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouseWebSite.Controllers
{
    public class SensorController : Controller
    {
        //
        // GET: /Sensor/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Sensor/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Sensor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sensor/Create

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
        // GET: /Sensor/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Sensor/Edit/5

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
        // GET: /Sensor/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Sensor/Delete/5

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
