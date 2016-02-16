using AutoMapper;
using SmartHouseWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interfaces.DTO;
using Interfaces.Tables;
using DTO.Services;
using Interfaces;
using Interfaces.MappingServices;

namespace SmartHouseWebSite.Controllers
{
    public class HouseControllerController : Controller
    {
        IMappingService<HouseControllerDTO> houseControllerMappingService { get; set; }
        IGenericMappingService genericMappingService { get; set; }

        public HouseControllerController(IGenericMappingService genMapService, IMappingService<HouseControllerDTO> houseControllerMapService) 
        {
            this.houseControllerMappingService = houseControllerMapService;
            this.genericMappingService = genMapService;
        }

        public ActionResult Index(int roomId)
        {
            if (roomId != 0)
            {
                var houseControllers = houseControllerMappingService.GetByRoomId(roomId);
                return View(houseControllers);
            }
            else
            {
                var houseControllers = houseControllerMappingService.GetAll();
                return View(houseControllers);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            HouseControllerDTO houseControllerDTO = genericMappingService.MapById<HouseController, HouseControllerDTO>(id);

            if (houseControllerDTO == null)
            {
                return HttpNotFound();
            }
            return View(houseControllerDTO);
        }

        public ActionResult Create()
        {
            ViewBag.houseControllersTypes = genericMappingService.MapAll<HouseControllersType, HouseControllersTypeDTO>();
            ViewBag.rooms = genericMappingService.MapAll<Room, RoomDTO>();
            return View();
        }

        [HttpPost]
        public ActionResult Create(HouseControllerDTO houseControllerDTO)
        {
            try
            {
                genericMappingService.Add<HouseControllerDTO, HouseController>(houseControllerDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            HouseControllerDTO houseControllerDTO = genericMappingService.MapById<HouseController, HouseControllerDTO>(id);

            if (houseControllerDTO == null)
            {
                return HttpNotFound();
            }

            ViewBag.houseControllersTypes = genericMappingService.MapAll<HouseControllersType, HouseControllersTypeDTO>();
            ViewBag.rooms = genericMappingService.MapAll<Room, RoomDTO>();

            return View(houseControllerDTO);
        }

        [HttpPost]
        public ActionResult Edit(HouseControllerDTO houseControllerDTO)
        {
            try
            {
                genericMappingService.Edit<HouseControllerDTO, HouseController>(houseControllerDTO);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return HttpNotFound();
                }

                genericMappingService.Delete<HouseController>(id);
                return RedirectToAction("Index");
            }
            catch
            {
                //TODO: Add Massege Error
                return RedirectToAction("Index");
            }

        }
    }
}
