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
    public class SensorsValueController : Controller
    {
        IMappingService<SensorsValueDTO> sensorsValueMappingService { get; set; }

        public SensorsValueController() //should use IoC for service and repository
        {
            this.sensorsValueMappingService = new SensorsValueMappingService();
        }

        public ActionResult Index()
        {
            if (RouteData.Values["roomId"] != null)
            {
                int roomId = Convert.ToInt32(RouteData.Values["roomId"]);
                var sensorsValues = Mapper.Map<IEnumerable<SensorsValueDTO>, List<SensorsValueViewModel>>(sensorsValueMappingService.
                    GetByRoomId(roomId));
                return View(sensorsValues);
            }
            else
            {
                var sensorsValues = Mapper.Map<IEnumerable<SensorsValueDTO>, List<SensorsValueViewModel>>(sensorsValueMappingService.GetAll());
                return View(sensorsValues);
            }
        }
    }
}
