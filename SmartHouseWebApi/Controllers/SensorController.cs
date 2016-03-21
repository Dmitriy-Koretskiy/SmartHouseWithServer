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
    public class SensorController : ApiController
    {
        IMappingService<SensorDTO> sensorMappingService;
        IGenericMappingService genericMappingService;

        public SensorController(IMappingService<SensorDTO> sensorMapService, IGenericMappingService genericMapService)
        {
            this.sensorMappingService = sensorMapService;
            this.genericMappingService = genericMapService;
        }

        // GET api/sensor/5
         [ActionName("getSensorsByRoomId")]
        public IEnumerable<SensorDTO> Get(int roomId)
        {
            if (roomId <= 0)
            {
                return null;
            }
            else
            {
                var sensors = sensorMappingService.GetByRoomId(roomId);
                return sensors;
            }
        }

        [ActionName("getSensorById")]
        public SensorDTO GetSensorById(int sensorId)
        {
            return genericMappingService.MapById<Sensor, SensorDTO>(sensorId);
        }

        [ActionName("getSensorsTypes")]
        public IEnumerable<SensorsTypeDTO> GetSensorsType()
        {
             return genericMappingService.MapAll<SensorsType, SensorsTypeDTO>();
        }

        // POST api/sensor

        [HttpPost]
        public void Post([FromBody] SensorDTO sensorDTO)
        {
            genericMappingService.Add<SensorDTO, Sensor>(sensorDTO);
        }

 
        [HttpPut]
        public void Put([FromBody] SensorDTO sensorDTO)
        {     
             genericMappingService.Edit<SensorDTO, Sensor>(sensorDTO);
        }

        public void Delete(int id)
        {
            genericMappingService.Delete<Sensor>(id);
        }
    }
}
