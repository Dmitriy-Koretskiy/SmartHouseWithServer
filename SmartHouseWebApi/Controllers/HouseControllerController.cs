using Interfaces.DTO;
using Interfaces.MappingServices;
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

        // GET api/housecontroller/5
        public IEnumerable<HouseControllerDTO> GetControllersByRoomId(int roomId)
        {
            if (roomId != 0)
            {
                var houseControllers = houseControllerMappingService.GetByRoomId(roomId);
                return houseControllers;
            }
            else
            {
                var houseControllers = houseControllerMappingService.GetAll();
                return houseControllers;
            }
        }

        public IEnumerable<HouseControllerDTO> GetControllersByGroupId(int roomId)
        {
            if (roomId != 0)
            {
                var houseControllers = houseControllerMappingService.GetByRoomId(roomId);
                return houseControllers;
            }
            else
            {
                var houseControllers = houseControllerMappingService.GetAll();
                return houseControllers;
            }
        }

        // POST api/housecontroller
        public void Post([FromBody]string value)
        {
        }

        // PUT api/housecontroller/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/housecontroller/5
        public void Delete(int id)
        {
        }
    }
}
