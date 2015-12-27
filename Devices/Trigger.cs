﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class Trigger:ITrigger
    {
         ISensor sensor;
        IController controller;
        private readonly int condition;
        protected bool alreadyWork = false;
 
        public  Trigger(ISensor sensor, IController controller, int condition) 
        {
            this.sensor = sensor;
            this.controller = controller;
            this.condition = condition;
        }

        public virtual void CheckSensor() 
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
