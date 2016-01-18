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
        IGenericMappingService genericMappingService { get; set; }
        IRepository repository { get; set; }

        public TriggersActionController() //should use IoC for service and repository
        {
            this.genericMappingService = new GenericMappingService();
        }

        public ActionResult Index()
        {
            var triggersActions = Mapper.Map<IEnumerable<TriggersActionDTO>, List<TriggersActionViewModel>>(genericMappingService.MapAll<TriggersAction, TriggersActionDTO>());
            return View(triggersActions);
        }
    }
}
