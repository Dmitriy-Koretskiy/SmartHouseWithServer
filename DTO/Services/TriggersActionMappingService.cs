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

namespace DTO.Services
{
    class TriggersActionMappingService
    {
         IRepository repository { get; set; }

        public TriggersActionMappingService()    // should use IoC
        {
            this.repository = new Repository();
        }

        public TriggersActionDTO GetById(int? id)  
        {
            return Mapper.Map<TriggersAction, TriggersActionDTO>(repository.Get<TriggersAction>(id));
        }

        public IEnumerable<TriggersActionDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<TriggersAction>, List<TriggersActionDTO>>(repository.GetAll<TriggersAction>());
        }

        public IEnumerable<TriggersActionDTO> GetByRoomId(int roomId)
        {
            return Mapper.Map<IEnumerable<TriggersAction>, List<TriggersActionDTO>>(repository.GetAll<TriggersAction>().Where(t => t.Trigger.RoomId == roomId));
        }

        public void Add(TriggersActionDTO oldObject)
        {
            TriggersAction newObject = Mapper.Map<TriggersActionDTO, TriggersAction>(oldObject);
            repository.Add<TriggersAction>(newObject);
            repository.SaveChanges();
        }

        public void Edit(TriggersActionDTO oldObject)
        {
            var newObject = Mapper.Map<TriggersActionDTO, TriggersAction>(oldObject);
            repository.Update<TriggersAction>(newObject);
            repository.SaveChanges();
        }

        public void Delete(int? id)
        {
            var obj = repository.Get<TriggersAction>(id);
            repository.Delete<TriggersAction>(obj);
            repository.SaveChanges();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
