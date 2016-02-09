using DAL;
using Interfaces;
using Interfaces.CheckResults;
using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class Server
    {
        IRepository repository = new Repository();
        Assembly assembly = Assembly.LoadFrom(@"..\..\..\Devices\bin\Debug\Devices.dll");
        private bool systemWork = true;
        private int amountTactsToWriteToDB = 1;
        private int currentTact = 0;

        private List<object> ConfigureSystem()
        {      
            Dictionary<string, object> sensorsDict = GetSensorsDictionary();
            Dictionary<string, object> controllersDict = GetControllersDictionary();
            List<object> triggersList = GetTriggersList(sensorsDict, controllersDict);

            return triggersList;            
        }

        public void StartSystemWork(){

            systemWork = true;
            var triggers = ConfigureSystem();

            if(systemWork == false)
            {
                Thread.Sleep(100000);
                StartSystemWork();
            }

            StartMainProsses(triggers);
        }

        private void StartMainProsses(List<object> triggersList)
        {
            while (systemWork)
            {
                Parallel.ForEach(triggersList, UseTrigger);
                Thread.Sleep(1000);
            }
        }

        public void StopWork()
        {
            this.systemWork = false;
        }

        private void UseTrigger(object obj)
        {
            Repository repository1 = new Repository();
            ITrigger trigger = (ITrigger)obj;
            trigger.CheckSensor();

            //TODO: Should add to another class. To DAL or BLL?
            if (trigger.StateAfterChange != null)
            {
                TriggersAction triggerAction = new TriggersAction() { TriggerId = trigger.Id, TimeChange = DateTime.Now, Description = trigger.StateAfterChange };
                repository1.Add(triggerAction);
            }

            currentTact++;
            if (currentTact >= amountTactsToWriteToDB)
            {
                SensorsValue sensorsValue = new SensorsValue() { SensorId = trigger.SensorId, TimeMeasurement = DateTime.Now, Value = trigger.SensorValue };

                repository1.Add(sensorsValue);
                currentTact = 0;
            }

            repository.SaveChanges();
        }

        private Dictionary<string, object> GetSensorsDictionary()
        {
            Dictionary<string, object> sensorsDict = new Dictionary<string, object>();
            Type type;
            foreach (Sensor sensorElement in repository.GetAll<Sensor>().Where(s => s.Enable == true))
            {
                type = GetDeviceTypeTry(sensorElement.SensorsType.Name);

                if (type == null)
                {
                    systemWork = false;
                    break;
                }
                else
                {
                    sensorsDict.Add(sensorElement.Id.ToString(), Activator.CreateInstance(type, sensorElement.Id));
                } 
            }
            return sensorsDict;
        }

        private  Dictionary<string, object> GetControllersDictionary()
        {
            Dictionary<string, object> controllersDict = new Dictionary<string, object>();
            Type type;
            foreach (HouseController controllerElement in repository.GetAll<HouseController>().Where(c => c.Enable == true))
            {
                type = GetDeviceTypeTry(controllerElement.HouseControllersType.Name);

                if (type == null)
                {
                    systemWork = false;
                    break;
                }
                else
                {
                    controllersDict.Add(controllerElement.Id.ToString(), Activator.CreateInstance(type, controllerElement.Id));
                }   
            }
            return controllersDict;
        }

        private List<object> GetTriggersList(Dictionary<string, object> sensorsDict, Dictionary<string, object> controllersDict)
        {
            List<object> triggersList = new List<object>();
            Type type; 
            foreach (Trigger triggerElement in repository.GetAll<Trigger>().Where(t => t.Enable == true))
            {
                type = GetDeviceTypeTry("BaseTrigger");

                if (type == null)
                {
                    systemWork = false;
                    break;
                }
                else
                {
                    object obj = Activator.CreateInstance(type, triggerElement.Id, sensorsDict[triggerElement.Sensor.Id.ToString()],
                        controllersDict[triggerElement.HouseController.Id.ToString()], triggerElement.Condition);
                    triggersList.Add(obj);
                }
            }
            return triggersList;
        }

        private Type GetDeviceTypeTry(string typeDevice)
        {
            try
            {
                return assembly.GetType("Devices." + typeDevice, true, true);
            }
            catch
            {
                return null;
            }
        }

        public CheckConfigurationResult CheckConfiguration()
        {
            CheckConfigurationResult checkResult = new CheckConfigurationResult();
            Type type;

            foreach (Sensor sensorElement in repository.GetAll<Sensor>().Where(s => s.Enable == true))
            {
                try
                {
                    type = assembly.GetType("Devices." + sensorElement.SensorsType.Name, true, true);
                }
                catch
                {
                    checkResult.errorExist = true;
                    checkResult.missingDevice.Add(sensorElement.SensorsType.Name);

                }
            }
            foreach (HouseController controllerElement in repository.GetAll<HouseController>().Where(c => c.Enable == true))
            {
                try
                {
                    type = assembly.GetType("Devices." + controllerElement.HouseControllersType.Name, true, true);
                }
                catch
                {
                    checkResult.errorExist = true;
                    checkResult.missingDevice.Add(controllerElement.HouseControllersType.Name);
                }
            }
            foreach (Trigger triggerElement in repository.GetAll<Trigger>().Where(t => t.Enable == true))
            {
                try
                {
                    type = assembly.GetType("Devices." + triggerElement.TriggersType.Name, true, true);
                }
                catch
                {
                    checkResult.errorExist = true;
                    checkResult.missingDevice.Add(triggerElement.TriggersType.Name);
                }
            }

            return checkResult;
        }
    }
}
