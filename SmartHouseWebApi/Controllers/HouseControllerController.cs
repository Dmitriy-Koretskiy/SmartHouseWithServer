using Interfaces.DTO;
using Interfaces.MappingServices;
using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHouseWebApi.Controllers
{
    public class HouseControllerController : ApiController
    {
        IMappingService<HouseControllerDTO> houseControllerMappingService { get; set; }
        IGenericMappingService genericMappingService { get; set; }

        public HouseControllerController(IGenericMappingService genMapService, IMappingService<HouseControllerDTO> houseControllerMapService)
        {
            this.houseControllerMappingService = houseControllerMapService;
            this.genericMappingService = genMapService;
        }

        // GET api/housecontroller/5
        //public IEnumerable<HouseControllerDTO> GetHouseControllersByRoomId(int roomId)
        //{
        //    if (roomId != 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return houseControllerMappingService.GetByRoomId(roomId);
        //    }
        //}


        [ActionName("getHouseControllersByRoomId")]
        public IEnumerable<HouseControllerDTO> Get(int roomId)
        {
            if (roomId <= 0)
            {
                return null;
            }
            else
            {
                var houseControllers = houseControllerMappingService.GetByRoomId(roomId);
                return houseControllers;
            }
        }

        [ActionName("getHouseControllerById")]
        public HouseControllerDTO GetSensorById(int houseControllerId)
        {
            return genericMappingService.MapById<HouseController, HouseControllerDTO>(houseControllerId);
        }

        [ActionName("getHouseControllersTypes")]
        public IEnumerable<HouseControllersTypeDTO> GetSensorsType()
        {
            return genericMappingService.MapAll<HouseControllersType, HouseControllersTypeDTO>();
        }




        public void Post([FromBody] HouseControllerDTO houseControllerDTO)
        {
            genericMappingService.Add<HouseControllerDTO, HouseController>(houseControllerDTO);
        }

 
        public void Put([FromBody] HouseControllerDTO houseControllerDTO)
        {
            genericMappingService.Edit<HouseControllerDTO, HouseController>(houseControllerDTO);
        }

        public void Delete(int id)
        {
            genericMappingService.Delete<HouseController>(id);
        }



  
    }
}
