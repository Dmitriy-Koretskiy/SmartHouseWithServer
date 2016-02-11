using AutoMapper;
using DTO.Services;
using Interfaces;
using Interfaces.DTO;
using Interfaces.Tables;
using SmartHouseWebSite.Models;
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

namespace SmartHouseWebSite.Controllers
{
    public class HomeController : Controller
    {
        IGenericMappingService genericMappingService;


        public HomeController(IGenericMappingService mapService) 
        {
            this.genericMappingService = mapService;
        }
       
        public ActionResult Index()
        {
            var rooms = genericMappingService.MapAll<Room, RoomDTO>();
            return View(rooms);
        }

        public ActionResult CheckConfiguration()
        {
            //Server server = new Server();
            //var list = server.CheckConfiguration().missingDevices;
            List<MissingDevice> l = new List<MissingDevice>();
            MissingDevice r1 = new MissingDevice { RoomName = "Room1", DeviceName = "Conditioner" };
            MissingDevice r2 = new MissingDevice { RoomName = "Room2", DeviceName = "Lamp" };
            l.Add(r1);
            l.Add(r2);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}
