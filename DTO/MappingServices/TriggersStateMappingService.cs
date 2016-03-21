using AutoMapper;
using Interfaces;
using Interfaces.DTO;
using Interfaces.MappingServices;
using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servises.MappingServices
{
    public class TriggersStateMappingService : ITriggersStateMappingService
    {
         IRepository repository;

        public TriggersStateMappingService(IRepository rep)
        {
            this.repository = rep;
        }

        public string GetRoomNameById(int roomId)
        {
            return Mapper.Map<Room, RoomDTO>(repository.Get<Room>(roomId)).Name;
        }

        public IEnumerable<TriggersStateInitDTO>  GetLastTriggersStatesInit(int roomId) {
            List<TriggersStateInitDTO> triggersStatetList = new List<TriggersStateInitDTO>();
            List<Trigger> triggerList = repository.GetAll<Trigger>().Where(t => t.RoomId == roomId).ToList();
            foreach (Trigger trigger in triggerList)
            {
                TriggersStateInitDTO state = GetLastTriggersStateInit(trigger.Id);
                triggersStatetList.Add(state);
            }

            return triggersStatetList;

        }

        private TriggersStateInitDTO GetLastTriggersStateInit(int triggerId) 
        {
            try
            {
                return Mapper.Map<TriggersAction, TriggersStateInitDTO>(repository.GetAll<TriggersAction>()
                       .OrderByDescending(x => x.TimeChange)
                       .First(t => t.Trigger.Id == triggerId));
            }
            catch
            {
                Trigger trig = repository.Get<Trigger>(triggerId);
                return new TriggersStateInitDTO()
                {
                    LastState = "off",
                    Image = trig.TriggersType.Image,
                    Name = trig.Name
                };

            }
        }
 
        public string GetLastTriggersState(int triggerId)
        {
            return Mapper.Map<TriggersAction, TriggersStateDTO>(repository.GetAll<TriggersAction>()
                    .OrderByDescending(x => x.TimeChange)
                    .First(t => t.Trigger.Id == triggerId))
                    .LastState;
        }

        public void SetLastTriggerState(TriggersStateDTO oldObject)
        {
            TriggersAction newObject = Mapper.Map<TriggersStateDTO, TriggersAction>(oldObject);
            repository.Add<TriggersAction>(newObject);
            repository.SaveChanges();
        }

        public void SetLastTriggerState(string Id)
        {
            TriggersStateDTO oldObject = new TriggersStateDTO() { 
                Id = Id,
                LastState = "Off"            
            };
            TriggersAction newObject = Mapper.Map<TriggersStateDTO, TriggersAction>(oldObject);
            repository.Add<TriggersAction>(newObject);
            repository.SaveChanges();
        }

        public void RecordWorkStatusToDB(string status)
        {
            var statusInDB = repository.GetAll<SystemWorkStatus>().First();
            statusInDB.Status = status;
            repository.Update<SystemWorkStatus>(statusInDB);
            repository.SaveChanges();
        }

        public string CheckSystemWorkStatus()
        {
            return repository.GetAll<SystemWorkStatus>().First().Status;
        }

        public IEnumerable<TriggersStateDTO> GetLastTriggersStates(int roomId)
        {
            List<TriggersStateDTO> triggersStatetList = new List<TriggersStateDTO>();
            List<Trigger> triggerList = repository.GetAll<Trigger>().Where(t => t.RoomId == roomId).ToList();
            foreach (Trigger trigger in triggerList)
            {
                TriggersStateDTO roomContent = Mapper.Map<TriggersAction, TriggersStateDTO>(repository.GetAll<TriggersAction>()
                    .OrderByDescending(x => x.TimeChange)
                    .First(t => t.Trigger.RoomId == roomId && t.Trigger.Id == trigger.Id));
                triggersStatetList.Add(roomContent);
            }

            return triggersStatetList;
        }
    }
}
