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
using Interfaces.MappingServices;

namespace Servises.Services
{
    public class TriggerMappingService: IMappingService<TriggerDTO>
    {
        IRepository repository;

        public TriggerMappingService(IRepository rep)    // should use IoC
        {
            this.repository = rep;
        }

        public TriggerDTO GetById(int? id)  
        {
            return Mapper.Map<Trigger, TriggerDTO>(repository.Get<Trigger>(id));
        }

        public IEnumerable<TriggerDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Trigger>, List<TriggerDTO>>(repository.GetAll<Trigger>());
        }

        public IEnumerable<TriggerDTO> GetByRoomId(int roomId)
        {
            return Mapper.Map<IEnumerable<Trigger>, List<TriggerDTO>>(repository.GetAll<Trigger>().Where(t => t.RoomId == roomId));
        }

        public void Add(TriggerDTO oldObject)
        {
            Trigger newObject = Mapper.Map<TriggerDTO, Trigger>(oldObject);
            repository.Add<Trigger>(newObject);
            repository.SaveChanges();
        }

        public void Edit(TriggerDTO oldObject)
        {
            var newObject = Mapper.Map<TriggerDTO, Trigger>(oldObject);
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
