using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IMappingService<T> : IDisposable where T : BaseEntityDTO
    {
        T GetById(int? id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetByRoomId(int roomId);

        void Add(T oldObject);

        void Edit(T oldObject);

        void Delete(int? id);
    }
}
