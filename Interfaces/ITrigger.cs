using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITrigger
    {
        int Id { get; set; }
        int SensorValue { get; set; }
        string StateAfterChange { get; set; }
        int SensorId { get; set; }

         void CheckSensor();
    }
}
