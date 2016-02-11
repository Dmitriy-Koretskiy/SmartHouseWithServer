using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.MappingServices
{
    public interface IRoomMappingService
    {
        RoomDTO GetRoomById(int roomId);

        string GetLastStateOfTrigger(int triggerId);
        
        IEnumerable<RoomContentDTO> GetLastStatesOfTriggers(int roomId);
    }
}
