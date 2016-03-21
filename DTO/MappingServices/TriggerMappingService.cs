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

namespace Servises.MappingServices
{
    public class TriggerMappingService : IMappingService<TriggersSettingDTO>
    {
        IRepository repository;

        public TriggerMappingService(IRepository rep)    // should use IoC
        {
            this.repository = rep;
        }

        public TriggersSettingDTO GetById(int? id)
        {
            return Mapper.Map<Trigger, TriggersSettingDTO>(repository.Get<Trigger>(id));
        }

        public IEnumerable<TriggersSettingDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Trigger>, List<TriggersSettingDTO>>(repository.GetAll<Trigger>());
        }

        public IEnumerable<TriggersSettingDTO> GetByRoomId(int roomId)
        {
            return Mapper.Map<IEnumerable<Trigger>, List<TriggersSettingDTO>>(repository.GetAll<Trigger>().Where(t => t.RoomId == roomId));
        }

        public void Add(TriggersSettingDTO oldObject)
        {
            Trigger newObject = Mapper.Map<TriggersSettingDTO, Trigger>(oldObject);
            repository.Add<Trigger>(newObject);
            repository.SaveChanges();
        }

        

        public void Edit(TriggersSettingDTO oldObject)
        {
            var newObject = Mapper.Map<TriggersSettingDTO, Trigger>(oldObject);
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
