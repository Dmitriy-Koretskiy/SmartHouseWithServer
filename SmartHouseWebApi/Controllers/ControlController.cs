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
    public class ControlController : ApiController
    {
        ITriggersStateMappingService triggersStateMappingService;

        public ControlController(ITriggersStateMappingService triggersStateMappingService)
        {
            this.triggersStateMappingService = triggersStateMappingService;
        }

        // GET api/control
        public IEnumerable<TriggersStateDTO> Get(int roomId)
        {
            if (roomId <= 0)
            {
                return null;
            }
            var triggersStates = triggersStateMappingService.GetLastTriggersStates(roomId);
            return triggersStates;
        }

        [ActionName("triggersInitState")]
        public IEnumerable<TriggersStateInitDTO> GetInitState(int roomIdForInit)
        {
            if (roomIdForInit <= 0)
            {
                return null;
            }
            var triggersStates = triggersStateMappingService.GetLastTriggersStatesInit(roomIdForInit);
            return triggersStates;
        }

        [ActionName("triggerState")]
        public string GetTriggerState(int triggerId)
        {
            if (triggerId <= 0)
            {
                return null;
            }
            string room = triggersStateMappingService.GetRoomNameById(triggerId);
            var triggersState = triggersStateMappingService.GetLastTriggersState(triggerId);
            return triggersState;
        }

        [ActionName("serverstatus")]
        public string GetServerStatus()
        {

           return triggersStateMappingService.CheckSystemWorkStatus();
            
        }

        // POST api/control
        public void Post([FromBody] TriggersStateDTO value)
        {
            triggersStateMappingService.SetLastTriggerState(value);
        }

        // PUT api/control/5\
        [ActionName("putserverstatus")]
        public string PutServerStatus([FromBody] SystemWorkStatus value)
        {
            triggersStateMappingService.RecordWorkStatusToDB(value.Status);
            return value.Status;
        }

        // DELETE api/control/5
        public void Delete(int id)
        {
        }
    }
}
