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
        Repository repository = new Repository();
        Assembly assembly = Assembly.LoadFrom(@"..\..\..\Devices\bin\Debug\Devices.dll");

        public void StartWork()
        {      
            Dictionary<string, object> sensorsDict = GetSensorsDictionary();
            Dictionary<string, object> controllersDict = GetControllersDictionary();
            List<object> triggersList = GetTriggersList(sensorsDict, controllersDict);
           
            for (; ; )
            {
                Parallel.ForEach(triggersList, UseTrigger);
                Thread.Sleep(1000);
            }
        }

        private void UseTrigger(object obj)
        {
            ITrigger trigger = (ITrigger)obj;
            trigger.CheckSensor();
        }

        private Dictionary<string, object> GetSensorsDictionary()
        {
            Dictionary<string, object> sensorsDict = new Dictionary<string, object>();
            Type type;
            foreach (Sensor sensorElement in repository.GetAll<Sensor>().Where(s => s.Enable == true))
            {
                type = assembly.GetType("Devices." + sensorElement.SensorsType.Name, true, true);
                sensorsDict.Add(sensorElement.Id.ToString(), Activator.CreateInstance(type, sensorElement.Id));
            }
            return sensorsDict;
        }

        private  Dictionary<string, object> GetControllersDictionary()
        {
            Dictionary<string, object> controllersDict = new Dictionary<string, object>();
            Type type;
            foreach (HouseController controllerElement in repository.GetAll<HouseController>().Where(c => c.Enable == true))
            {
                type = assembly.GetType("Devices." + controllerElement.HouseControllersType.Name, true, true);
                controllersDict.Add(controllerElement.Id.ToString(), Activator.CreateInstance(type, controllerElement.Id));
            }
            return controllersDict;
        }

        private List<object> GetTriggersList(Dictionary<string, object> sensorsDict, Dictionary<string, object> controllersDict)
        {
            List<object> triggersList = new List<object>();
            Type type;
            foreach (Trigger triggerElement in repository.GetAll<Trigger>().Where(t => t.Enable == true))
            {
                type = assembly.GetType("Devices." + triggerElement.TriggersType.Name, true, true);

                object obj = Activator.CreateInstance(type, triggerElement.Id, sensorsDict[triggerElement.Sensor.Id.ToString()],
                    controllersDict[triggerElement.HouseController.Id.ToString()], triggerElement.Condition);
                triggersList.Add(obj);
            }
            return triggersList;
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
