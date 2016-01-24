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
        TriggerDTO GetById(int? id);

        IEnumerable<TriggerDTO> GetAll();

        void Add(TriggerDTO oldObject);

        void Edit(TriggerDTO oldObject);

        void Delete(int? id);

        void Dispose();
    }
}
