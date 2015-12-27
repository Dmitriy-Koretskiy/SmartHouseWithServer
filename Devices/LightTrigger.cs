using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class LightTrigger: Trigger, ITrigger
    {
      
        public  LightTrigger(LightSensor sensor, LightController controller, int condition) : base(sensor, controller, condition) 
        {
        }

       
    }
}
