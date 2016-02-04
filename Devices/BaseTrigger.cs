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
        public int id;
        protected  ISensor sensor;
        protected  IController controller;
        protected readonly string condition;
        protected bool alreadyWork = false;
        protected ConditionsHandler conditionsHandler = new ConditionsHandler();
        protected IRepository repository = new Repository();

        public  BaseTrigger(int id, ISensor sensor, IController controller, string condition) 
        {
            this.id = id;
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
                    TriggersAction triggerAction = new TriggersAction() { TriggerId = id, TimeChange = DateTime.Now, Description = "On"};
                    repository.Add(triggerAction);
                    repository.SaveChanges();
                    controller.On();
                    alreadyWork = true;
                    TriggersActionDTO ta = new TriggersActionDTO() {TimeChange = DateTime.Now, Description = "On"};
                }
            }
            else
            {
                if (alreadyWork)
                {
                    TriggersAction triggerAction = new TriggersAction() { TriggerId = id, TimeChange = DateTime.Now, Description = "Off" };
                    repository.Add(triggerAction);
                    repository.SaveChanges();
                    controller.Off();
                    alreadyWork = false;
                }
            }
        }
    }
}
