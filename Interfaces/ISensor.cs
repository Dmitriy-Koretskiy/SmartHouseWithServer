using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISensor
    {
        int Id { get; set; }
        int CurrentValue { get; set; }
    }
}
