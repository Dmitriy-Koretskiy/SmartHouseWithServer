using AutoMapper;
using Interfaces.DTO;
using DTO.Services;
using Interfaces;
using Interfaces.Tables;
using SmartHouseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouseWebSite.Controllers
{
    public class TriggersActionController : Controller
    {
        IMappingService<TriggersActionDTO> triggersActionMappingService { get; set; }

        public TriggersActionController() 
        {
            this.triggersActionMappingService = new TriggersActionMappingService();
        }

        public ActionResult Index()
        {
            if (RouteData.Values["roomId"] != null)
            {
                int roomId = Convert.ToInt32(RouteData.Values["roomId"]);
                var triggersActions = triggersActionMappingService.GetByRoomId(roomId);
                return View(triggersActions);
            }
            else
            {
                var triggersActions = triggersActionMappingService.GetAll();
                return View(triggersActions);
            }
        }
    }
}
