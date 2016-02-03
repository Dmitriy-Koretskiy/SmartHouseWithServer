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

namespace SmartHouseWebSite.Controllers
{
    public class HouseControllerController : Controller
    {
        IGenericMappingService genericMappingService { get; set; }
        // IRepository repository { get; set; }

        public HouseControllerController() //should use IoC for service and repository
        {
            this.genericMappingService = new GenericMappingService();
        }

        public ActionResult Index()
        {
            //if (RouteData.Values["roomId"] != null)
            //{
            //    //int roomId = (Int32)RouteData.Values["roomId"];
                //var houseControllers = Mapper.Map<IEnumerable<HouseControllerDTO>, List<HouseControllerViewModel>>(genericMappingService.
                //    MapByRoomId<HouseController, HouseControllerDTO>(roomId));
                //return View(houseControllers);
            //}
            //else
            //{
                var houseControllers = Mapper.Map<IEnumerable<HouseControllerDTO>, List<HouseControllerViewModel>>(genericMappingService.
                    MapAll<HouseController, HouseControllerDTO>());
                return View(houseControllers);
            //}
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            HouseControllerViewModel houseControllerVM = Mapper.Map<HouseControllerDTO, HouseControllerViewModel>(genericMappingService.MapById<HouseController, HouseControllerDTO>(id));

            if (houseControllerVM == null)
            {
                return HttpNotFound();
            }
            return View(houseControllerVM);
        }

        public ActionResult Create()
        {
            ViewBag.houseControllersTypes = Mapper.Map<IEnumerable<HouseControllersTypeDTO>, List<HouseControllersTypeViewModel>>(genericMappingService.MapAll<HouseControllersType, HouseControllersTypeDTO>());
            ViewBag.rooms = Mapper.Map<IEnumerable<RoomDTO>, List<RoomViewModel>>(genericMappingService.MapAll<Room, RoomDTO>());
            return View();
        }

        [HttpPost]
        public ActionResult Create(HouseControllerViewModel houseControllerVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<HouseControllerViewModel, HouseControllerDTO>(houseControllerVM);
                genericMappingService.Add<HouseControllerDTO, HouseController>(controllerDTO);
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

            HouseControllerViewModel houseControllerVM = Mapper.Map<HouseControllerDTO, HouseControllerViewModel>(genericMappingService.MapById<HouseController, HouseControllerDTO>(id));

            if (houseControllerVM == null)
            {
                return HttpNotFound();
            }

            ViewBag.houseControllersTypes = Mapper.Map<IEnumerable<HouseControllersTypeDTO>, List<HouseControllersTypeViewModel>>(genericMappingService.MapAll<HouseControllersType, HouseControllersTypeDTO>());
            ViewBag.rooms = Mapper.Map<IEnumerable<RoomDTO>, List<RoomViewModel>>(genericMappingService.MapAll<Room, RoomDTO>());

            return View(houseControllerVM);
        }

        [HttpPost]
        public ActionResult Edit(HouseControllerViewModel houseControllerVM)
        {
            try
            {
                var controllerDTO = Mapper.Map<HouseControllerViewModel, HouseControllerDTO>(houseControllerVM);
                genericMappingService.Edit<HouseControllerDTO, HouseController>(controllerDTO);
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
