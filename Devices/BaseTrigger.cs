using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Tables;
using Interfaces.DTO;
using DAL;


namespace Devices
{
    class BaseTrigger:ITrigger
    {
       
        protected  ISensor sensor;
        protected  IController controller;
        protected string condition;
        protected bool alreadyWork = false;
        protected ConditionsHandler conditionsHandler = new ConditionsHandler();

        public int Id { get; set; }
        public int SensorValue { get;  set; }
        public string StateAfterChange { get;  set; }
        public int SensorId { get;  set; }

        public  BaseTrigger(int id, ISensor sensor, IController controller, string condition) 
        {
            this.Id = id;
            this.sensor = sensor;
            this.controller = controller;
            this.condition = condition;
            this.SensorId = sensor.Id;
        }

        public void CheckSensor() 
        {
            StateAfterChange = null;
            SensorValue = sensor.CurrentValue;
            if (conditionsHandler.CheckCondtion(condition, SensorValue))
            {
                if (!alreadyWork)
                {
                    StateAfterChange = "On";
                    controller.On();
                    alreadyWork = true;
                    //TriggersActionDTO ta = new TriggersActionDTO() {TimeChange = DateTime.Now, Description = "On"};
                }
            }
            else
            {
                if (alreadyWork)
                {
                    StateAfterChange = "Off";
                    controller.Off();
                    alreadyWork = false;
                }
            }
        }
    }
}
