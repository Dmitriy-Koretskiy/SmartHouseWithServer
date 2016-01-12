using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Devices
{
    class Trigger:ITrigger
    {
        protected  ISensor sensor;
        protected  IController controller;
        protected readonly string condition;
        protected bool alreadyWork = false;
        protected ConditionsHandler conditionsHandler = new ConditionsHandler();
     
        public  Trigger(ISensor sensor, IController controller, string condition) 
        {
            this.sensor = sensor;
            this.controller = controller;
            this.condition = condition;
        }

        public virtual void CheckSensor() 
        {
            if (conditionsHandler.CheckCondtion(condition, sensor.GenerateValue()))
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
