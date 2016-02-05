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

namespace SmartHouseWebSite.Controllers
{
    public class HomeController : Controller
    {
        IGenericMappingService genericMappingService { get; set; }


        public HomeController() 
        {
            this.genericMappingService = new GenericMappingService();
        }
       
        public ActionResult Index()
        {
            var rooms = genericMappingService.MapAll<Room, RoomDTO>();
            return View(rooms);
        }
    }
}
