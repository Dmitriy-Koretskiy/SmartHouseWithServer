using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IMappingService
    {
        TriggerDTO GetByIdFromDB(int? id);

        IEnumerable<TriggerDTO> GetAllFromDB();

        void AddToDB(TriggerDTO oldObject);

        void Edit(TriggerDTO oldObject);

        void Delete(int? id);

        void Dispose();
    }
}
