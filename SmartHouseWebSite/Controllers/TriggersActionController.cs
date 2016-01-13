using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouseWebSite.Controllers
{
    public class TriggersActionController : Controller
    {
        //
        // GET: /TriggersAction/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /TriggersAction/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TriggersAction/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TriggersAction/Create

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
        // GET: /TriggersAction/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TriggersAction/Edit/5

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
        // GET: /TriggersAction/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TriggersAction/Delete/5

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
