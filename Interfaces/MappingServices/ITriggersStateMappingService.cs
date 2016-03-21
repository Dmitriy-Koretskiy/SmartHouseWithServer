using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.MappingServices
{
    public interface ITriggersStateMappingService
    {
        string GetRoomNameById(int roomId);

        string GetLastTriggersState(int triggerId);

        IEnumerable<TriggersStateInitDTO> GetLastTriggersStatesInit(int roomId);

        void SetLastTriggerState(TriggersStateDTO oldObject);

        void SetLastTriggerState(string Id);

        void RecordWorkStatusToDB(string status);
       
        string CheckSystemWorkStatus();
        

        IEnumerable<TriggersStateDTO> GetLastTriggersStates(int roomId);
    }
}
