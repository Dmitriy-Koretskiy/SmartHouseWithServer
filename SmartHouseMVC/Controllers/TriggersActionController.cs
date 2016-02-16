using AutoMapper;
using Interfaces.DTO;
using Servises.Services;
using Interfaces;
using Interfaces.Tables;
using SmartHouseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interfaces.MappingServices;

namespace SmartHouseMVC.Controllers
{
    public class TriggersActionController : Controller
    {
        IMappingService<TriggersActionDTO> triggersActionMappingService { get; set; }

        public TriggersActionController(IMappingService<TriggersActionDTO> triggersActionMapService) 
        {
            this.triggersActionMappingService = triggersActionMapService;
        }

        public ActionResult Index(int roomId)
        {
            if (roomId != 0)
            {
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
