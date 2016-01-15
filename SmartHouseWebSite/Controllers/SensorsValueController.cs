﻿using AutoMapper;
using Interfaces.DTO;
using BLL.Services;
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
        IGenericMappingService genericMappingService { get; set; }
        IRepository repository { get; set; }

        public SensorsValueController() //should use IoC for service and repository
        {
            this.genericMappingService = new GenericMappingService();
        }

        public ActionResult Index()
        {
            var houseControllers = Mapper.Map<IEnumerable<SensorsValueDTO>, List<SensorsValueViewModel>>(genericMappingService.MapAll<SensorsValue, SensorsValueDTO>());
            return View(houseControllers);
        }
    }
}
