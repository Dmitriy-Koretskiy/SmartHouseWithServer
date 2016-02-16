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
    public class SensorMappingService : IMappingService<SensorDTO>
    {
        IRepository repository;

        public SensorMappingService(IRepository rep)    // should use IoC
        {
            this.repository = rep;
        }

        public SensorDTO GetById(int? id)  
        {
            return Mapper.Map<Sensor, SensorDTO>(repository.Get<Sensor>(id));
        }

        public IEnumerable<SensorDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Sensor>, List<SensorDTO>>(repository.GetAll<Sensor>());
        }

        public IEnumerable<SensorDTO> GetByRoomId(int roomId)
        {
            return Mapper.Map<IEnumerable<Sensor>, List<SensorDTO>>(repository.GetAll<Sensor>().Where(t => t.RoomId == roomId));
        }

        public void Add(SensorDTO oldObject)
        {
            Sensor newObject = Mapper.Map<SensorDTO, Sensor>(oldObject);
            repository.Add<Sensor>(newObject);
            repository.SaveChanges();
        }

        public void Edit(SensorDTO oldObject)
        {
            var newObject = Mapper.Map<SensorDTO, Sensor>(oldObject);
            repository.Update<Sensor>(newObject);
            repository.SaveChanges();
        }

        public void Delete(int? id)
        {
            var obj = repository.Get<Sensor>(id);
            repository.Delete<Sensor>(obj);
            repository.SaveChanges();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
