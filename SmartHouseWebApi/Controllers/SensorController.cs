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
    public class SensorController : ApiController
    {
        IMappingService<SensorDTO> sensorMappingService;
        IGenericMappingService genericMappingService;

        // GET api/sensor/5
        public IEnumerable<SensorDTO> Get(int roomId)
        {
            if (roomId != 0)
            {
                var sensors = sensorMappingService.GetByRoomId(roomId);
                return sensors;
            }
            else
            {
                var sensors = sensorMappingService.GetAll();
                return sensors;
            }
        }

        // POST api/sensor
        public void Post([FromBody]string value)
        {
        }

        // PUT api/sensor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/sensor/5
        public void Delete(int id)
        {
        }
    }
}
