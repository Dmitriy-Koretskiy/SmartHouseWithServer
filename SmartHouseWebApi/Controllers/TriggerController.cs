using Interfaces.DTO;
using Interfaces.MappingServices;
using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHouseWebApi.Controllers
{
    public class TriggerController : ApiController
    {
        IMappingService<TriggersSettingDTO> triggerMappingService;
        IGenericMappingService genericMappingService;
        ITriggersStateMappingService triggersStateMappingService;

        public TriggerController(IGenericMappingService genericMapService, IMappingService<TriggersSettingDTO> triggerMapService, ITriggersStateMappingService triggersStateMapService)
        {
            this.triggerMappingService = triggerMapService;
            this.genericMappingService = genericMapService;
            this.triggersStateMappingService= triggersStateMapService;;
        }

        // GET api/trigger/5
        [ActionName("getTriggersByRoomId")]
        public IEnumerable<TriggersSettingDTO> Get(int roomId)
        {
            if (roomId <= 0)
            {
                return null;
            }
            else
            {
                var triggers = triggerMappingService.GetByRoomId(roomId);
                return triggers;
            }
        }

        [ActionName("getTriggerById")]
        public TriggersSettingDTO GetTriggerById(int triggerId)
        {
            return genericMappingService.MapById<Trigger, TriggersSettingDTO>(triggerId);
        }

        [ActionName("getTriggersTypes")]
        public IEnumerable<TriggersTypeDTO> GetTriggersType()
        {
            return genericMappingService.MapAll<TriggersType, TriggersTypeDTO>();
        }

 

        // POST api/trigger
        public void Post([FromBody] TriggersSettingDTO triggerDTO)
        {
            genericMappingService.Add<TriggersSettingDTO, Trigger>(triggerDTO);
      //      triggersStateMappingService.SetLastTriggerState(triggerDTO.Id.ToString());
        }

        // PUT api/trigger/5
        public void Put([FromBody] TriggersSettingDTO triggerDTO)
        {
            genericMappingService.Edit<TriggersSettingDTO, Trigger>(triggerDTO);
        }

        public void Delete(int id)
        {
            genericMappingService.Delete<Trigger>(id);
        }
    }
}
