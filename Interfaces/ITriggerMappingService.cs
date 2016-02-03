using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITriggerMappingService
    {
        TriggerDTO GetById(int? id);

        IEnumerable<TriggerDTO> GetAll();
        IEnumerable<TriggerDTO> GetByRoomId(int roomId);

        void Add(TriggerDTO oldObject);

        void Edit(TriggerDTO oldObject);

        void Delete(int? id);

        void Dispose();
    }
}
