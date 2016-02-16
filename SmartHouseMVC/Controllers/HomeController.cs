using AutoMapper;
using Servises.Services;
using Interfaces;
using Interfaces.DTO;
using Interfaces.Tables;
using SmartHouseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces.MappingServices;
using Interfaces.CheckResults;

namespace SmartHouseMVC.Controllers
{
    public class HomeController : Controller
    {
        IGenericMappingService genericMappingService;
        IServer server;

        public HomeController(IGenericMappingService mapService, IServer server) 
        {
            this.genericMappingService = mapService;
            this.server = server;
        }
       
        public ActionResult Index()
        {
            var rooms = genericMappingService.MapAll<Room, RoomDTO>();
            return View(rooms);
        }

        public ActionResult CheckConfiguration()
        {   
            var list = server.CheckConfiguration();
            
            if(!list.Any())
            {

            }

            return Json("234567", JsonRequestBehavior.AllowGet);
        }
    }
}
