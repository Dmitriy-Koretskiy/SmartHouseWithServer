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
    public class SensorsValueController : ApiController
    {
        ISensorsValueMappingService sensorsValueMappingService;

        // GET api/sensorsvalue/5
        public IEnumerable<SensorsValueDTO> Get(int roomId)
        {
            if (roomId != 0)
            {
                var sensorsValues = sensorsValueMappingService.GetByRoomId(roomId);
                return sensorsValues;
            }
            else
            {
                var sensorsValues = sensorsValueMappingService.GetAll();
                return sensorsValues;
            }
        }
    }
}
