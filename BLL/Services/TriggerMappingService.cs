using AutoMapper;
using Interfaces.DTO;
using DAL;
using Interfaces;
using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TriggerMappingService: IMappingService
    {
        IRepository repository { get; set; }

        public TriggerMappingService()    // should use IoC
        {
            this.repository = new Repository();
        }

        public TriggerDTO GetByIdFromDB(int? id)  
        {
            return Mapper.Map<Trigger, TriggerDTO>(repository.Get<Trigger>(id));
        }

        public IEnumerable<TriggerDTO> GetAllFromDB()
        {
            return Mapper.Map<IEnumerable<Trigger>, List<TriggerDTO>>(repository.GetAll<Trigger>());
        }

        public void AddToDB(TriggerDTO oldObject)
        {
            Trigger newObject = Mapper.Map<TriggerDTO, Trigger>(oldObject);
            Sensor sensor = repository.GetAll<Sensor>().First(opt => opt.Name == oldObject.Sensor);
            HouseController houseController = repository.GetAll<HouseController>().First(opt => opt.Name == oldObject.HouseController);
            newObject.HouseControllerId = houseController.Id;
            newObject.SensorId = sensor.Id;
            repository.Add<Trigger>(newObject);
            repository.SaveChanges();
        }

        public void Edit(TriggerDTO oldObject)
        {
            var newObject = Mapper.Map<TriggerDTO, Trigger>(oldObject);
            Sensor sensor = repository.GetAll<Sensor>().First(opt => opt.Name == oldObject.Sensor);
            HouseController houseController = repository.GetAll<HouseController>().First(opt => opt.Name == oldObject.HouseController);
            newObject.HouseControllerId = houseController.Id;
            newObject.SensorId = sensor.Id;
            repository.Update<Trigger>(newObject);
            repository.SaveChanges();
        }

        public void Delete(int? id)
        {
            var obj = repository.Get<Trigger>(id);
            repository.Delete<Trigger>(obj);
            repository.SaveChanges();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
