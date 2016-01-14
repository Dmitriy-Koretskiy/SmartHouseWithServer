using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Interfaces
{
    public interface IGenericMappingService
    {
        N MapById<O, N>(int? id)
            where N : class
            where O : class;
              
        IEnumerable<N> MapAll<O, N>()
            where N : class
            where O : class;

        void AddToDB<O, N>(O oldObject)
            where N : class
            where O : class;

        void Dispose();
    }
}
