using AutoMapper;
using DAL;
using Interfaces;
using Interfaces.DTO;
using Interfaces.MappingServices;
using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servises.Services
{
    public class SensorsValueMappingService : ISensorsValueMappingService
    {
        IRepository repository;

        public SensorsValueMappingService(IRepository rep)    // should use IoC
        {
            this.repository = rep;
        }

        public SensorsValueDTO GetById(int? id)
        {
            return Mapper.Map<SensorsValue, SensorsValueDTO>(repository.Get<SensorsValue>(id));
        }

        public IEnumerable<SensorsValueDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<SensorsValue>, List<SensorsValueDTO>>(repository.GetAll<SensorsValue>());
        }

        public IEnumerable<SensorsValueDTO> GetByRoomId(int roomId)
        {
            return Mapper.Map<IEnumerable<SensorsValue>, List<SensorsValueDTO>>(repository.GetAll<SensorsValue>().Where(t => t.Sensor.RoomId == roomId));
        }

        public IEnumerable<SensorsValueDTO> GetLastHourBySensorId(int sensorId)
        {
            var currentDate = DateTime.Now.AddHours(-1);
            return Mapper.Map<IEnumerable<SensorsValue>, List<SensorsValueDTO>>(repository.GetAll<SensorsValue>()
                .Where(t => t.Sensor.Id == sensorId)
                .Where(t=>t.TimeMeasurement>= currentDate));
        }

        public IEnumerable<SensorsValueDTO> GetThisDayBySensorId(int sensorId)
        {
            var currentDate = DateTime.Now.AddDays(-1);
            return Mapper.Map<IEnumerable<SensorsValue>, List<SensorsValueDTO>>(repository.GetAll<SensorsValue>()
                .Where(t => t.Sensor.Id == sensorId  )
                .Where(t => t.TimeMeasurement >= currentDate));
        }

        public void Add(SensorsValueDTO oldObject)
        {
            SensorsValue newObject = Mapper.Map<SensorsValueDTO, SensorsValue>(oldObject);
            repository.Add<SensorsValue>(newObject);
            repository.SaveChanges();
        }

        public void Edit(SensorsValueDTO oldObject)
        {
            var newObject = Mapper.Map<SensorsValueDTO, SensorsValue>(oldObject);
            repository.Update<SensorsValue>(newObject);
            repository.SaveChanges();
        }

        public void Delete(int? id)
        {
            var obj = repository.Get<SensorsValue>(id);
            repository.Delete<SensorsValue>(obj);
            repository.SaveChanges();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
