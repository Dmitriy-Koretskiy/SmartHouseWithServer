using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Interfaces
{
    public interface IGenericService
    {
        N GetController<N, O>(int? id)
            where N : class
            where O : class;
              
        IEnumerable<N> GetControllers<N, O>()
            where N : class
            where O : class;

        void Dispose();
    }
}
