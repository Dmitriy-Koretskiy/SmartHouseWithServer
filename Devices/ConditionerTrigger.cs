using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Devices
{
    class ConditionerTrigger: Trigger, ITrigger
    {
      
        public ConditionerTrigger(ISensor sensor, IController controller, string condition) : base(sensor, controller, condition)
        {
            
        }
    }
}
