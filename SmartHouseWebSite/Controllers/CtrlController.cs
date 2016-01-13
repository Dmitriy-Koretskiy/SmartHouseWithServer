using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouseWebSite.Controllers
{
    public class CtrlController : Controller
    {
        //
        // GET: /Ctrl/

        public ActionResult Index()
        {
            return View();
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
