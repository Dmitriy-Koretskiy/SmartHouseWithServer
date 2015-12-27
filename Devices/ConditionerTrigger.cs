using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class ConditionerTrigger: Trigger, ITrigger
    {
      

        public ConditionerTrigger(ISensor sensor, IController controller, int condition) : base(sensor, controller, condition)
        {
            
        }


        public override void CheckSensor() 
        {
            if ( sensor.GenerateValue() > condition)
            {
                if (!alreadyWork) 
                {
                    controller.On();
                    alreadyWork = true;
                }
            }
            else 
            {
                if (alreadyWork)
                {
                    controller.Off();
                    alreadyWork = false;
                }
            }
        }
    }
}
