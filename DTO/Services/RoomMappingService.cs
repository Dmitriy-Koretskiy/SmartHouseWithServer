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

namespace DTO.Services
{
    public class RoomMappingService : IRoomMappingService
    {
        IRepository repository;

        //public RoomMappingService()
        //{
        //    this.repository = new Repository();
        //}

        public RoomMappingService(IRepository rep)
        {
            this.repository = rep;
        }

        public RoomDTO GetRoomById(int roomId)
        {
            return Mapper.Map<Room, RoomDTO>(repository.Get<Room>(roomId));
        }

        public string GetLastStateOfTrigger(int triggerId)
        {
            return Mapper.Map<TriggersAction, RoomContentDTO>(repository.GetAll<TriggersAction>()
                    .OrderByDescending(x => x.TimeChange)
                    .First(t => t.Trigger.Id == triggerId))
                    .LastState;
        }

        public IEnumerable<RoomContentDTO> GetLastStatesOfTriggers(int roomId)
        {
            List<RoomContentDTO> roomContentList = new List<RoomContentDTO>();
            List<Trigger> triggerList = repository.GetAll<Trigger>().Where(t => t.RoomId == roomId).ToList();
            foreach (Trigger trigger in triggerList)
            {
                RoomContentDTO roomContent = Mapper.Map<TriggersAction, RoomContentDTO>(repository.GetAll<TriggersAction>()
                    .OrderByDescending(x => x.TimeChange)
                    .First(t => t.Trigger.RoomId == roomId && t.Trigger.Id == trigger.Id));
                roomContentList.Add(roomContent);
            }

            return roomContentList;
        }
    }
}
