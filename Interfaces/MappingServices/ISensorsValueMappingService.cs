using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.MappingServices
{
    public interface ISensorsValueMappingService
    {
        SensorsValueDTO GetById(int? id);

        IEnumerable<SensorsValueDTO> GetAll();
           
        IEnumerable<SensorsValueDTO> GetByRoomId(int roomId);

        IEnumerable<SensorsValueDTO> GetLastHourBySensorId(int sensorId);

        IEnumerable<SensorsValueDTO> GetThisDayBySensorId(int sensorId);
       
        void Add(SensorsValueDTO oldObject);

        void Edit(SensorsValueDTO oldObject);
       
        void Delete(int? id);
        
    }
}
