using AutoMapper;
using DAL;
using Interfaces;
using Interfaces.DTO;
using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Services
{
    public class SensorsValueMappingService : IMappingService<SensorsValueDTO>
    {
        IRepository repository { get; set; }

        public SensorsValueMappingService()    // should use IoC
        {
            this.repository = new Repository();
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
            var currentDate = DateTime.Now;
            return Mapper.Map<IEnumerable<SensorsValue>, List<SensorsValueDTO>>(repository.GetAll<SensorsValue>()
                .Where(t => t.Sensor.Id == sensorId)
                .Where(t => t.TimeMeasurement.Year == currentDate.Year
                         && t.TimeMeasurement.Month == currentDate.Month
                         && t.TimeMeasurement.Day == currentDate.Day
                         && (t.TimeMeasurement.Hour == currentDate.Hour || t.TimeMeasurement.Hour == currentDate.Hour-1)));
        }

        public IEnumerable<SensorsValueDTO> GetThisDayBySensorId(int sensorId)
        {
            var currentDate = DateTime.Now;
            return Mapper.Map<IEnumerable<SensorsValue>, List<SensorsValueDTO>>(repository.GetAll<SensorsValue>()
                .Where(t => t.Sensor.Id == sensorId  )
                .Where(t => t.TimeMeasurement.Year == currentDate.Year
                         && t.TimeMeasurement.Month == currentDate.Month
                         && (t.TimeMeasurement.Day == currentDate.Day || t.TimeMeasurement.Day == currentDate.Day-1)))
                ;
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
