using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.MappingServices
{
    public interface IGenericMappingService
    {
        N MapById<O, N>(int? id)
            where N : class
            where O : class;
              
        IEnumerable<N> MapAll<O, N>()
            where N : class
            where O : class;

        void Add<O, N>(O oldObject)
            where O : class
            where N : class;

        void Edit<O, N>(O oldObject)
            where N : class
            where O : class;

        void Delete<O>(int? id)
           where O : class;

        void Dispose();
    }
}
