using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class LightTrigger: ITrigger
    {
        ISensor sensor;
        IController controller;
        private readonly int condition;
        private bool alreadyWork = false;

        public  LightTrigger(LightSensor sensor, LightController controller, int condition) 
        {
            this.sensor = sensor;
            this.controller = controller;
            this.condition = condition;
        }

        public void CheckSensor() 
        {
            if (sensor.GenerateValue() < condition)
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
