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

        public SensorsValueController(ISensorsValueMappingService sensorsValueMapService)
        {
            this.sensorsValueMappingService = sensorsValueMapService;
        }
        // GET api/sensorsvalue/5
        public IEnumerable<SensorsValueDTO> Get(int roomId)
        {
            if (roomId <= 0)
            {
                return null;
            }
            else
            {
                var sensorsValues = sensorsValueMappingService.GetByRoomId(roomId);
                return sensorsValues;
            }
        }

        [ActionName("forDay")]
        public object GetSensorStatisticThisDay(int sensorIdForDay)
        {
            if (sensorIdForDay >= 0)
            {
                return sensorsValueMappingService.GetThisDayBySensorId(sensorIdForDay);
            }
            else
            {
                return null;
            }
        }

        [ActionName("forHour")]
        public object GetSensorStatisticLastHour(int sensorIdForHour)
        {
//            var oldDate = sensorsValueMappingService.GetById(1);
////???
//            var date = (DateTime.Now - oldDate.TimeMeasurement).Days;

            if (sensorIdForHour >= 0)
            {
                return sensorsValueMappingService.GetLastHourBySensorId(sensorIdForHour);
            }
            else
            {
                return null;
            }
        }
    }
}
