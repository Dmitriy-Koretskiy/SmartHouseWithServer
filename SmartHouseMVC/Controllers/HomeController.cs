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
            var l = server;
            Server server1 = new Server();
            var s = server1.CheckConfiguration();
            var l1 = l.CheckConfiguration().missingDevices;
            var list = server.CheckConfiguration().missingDevices;
            //List<MissingDevice> l = new List<MissingDevice>();
            //MissingDevice r1 = new MissingDevice { RoomName = "Room1", DeviceName = "Conditioner" };
            //MissingDevice r2 = new MissingDevice { RoomName = "Room2", DeviceName = "Lamp" };
            //l.Add(r1);
            //l.Add(r2);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
