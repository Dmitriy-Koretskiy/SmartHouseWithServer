using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Devices
{
    class LightTrigger: Trigger, ITrigger
    {
        public LightTrigger(int id, ISensor sensor, IController controller, string condition)
            : base(id, sensor, controller, condition) 
        {
        }     
    }
}
