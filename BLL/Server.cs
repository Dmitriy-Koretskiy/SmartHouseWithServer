using DAL;
using Interfaces;
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
    public static class Server
    {
       public static void StartWork ()
       {
            Repository repository = new Repository();
            Assembly asm = Assembly.LoadFrom(@"..\..\..\Devices\bin\Debug\Devices.dll");
            Dictionary<string, object> sensorsDict = GetSensorsDictionary(repository, asm);
            Dictionary<string, object> controllersDict = GetControllersDictionary(repository, asm);
            List<object> triggersList = GetTriggersList(repository, asm, sensorsDict, controllersDict);
            for (; ; )
            {
                Parallel.ForEach(triggersList, UseTrigger);
                Thread.Sleep(1000);
            }
        }
        
        private static void UseTrigger(object obj)
        {
            ITrigger trigger = (ITrigger)obj;
            trigger.CheckSensor();
        }


        private static Dictionary<string, object> GetSensorsDictionary(Repository repository, Assembly assembly)
       {
           Dictionary<string, object> sensorsDict = new Dictionary<string, object>();
           Type type;
           foreach (Sensor sensorElement in repository.GetAll<Sensor>())
           {
               type = assembly.GetType("Devices." + sensorElement.SensorsType.Name, true, true);
               sensorsDict.Add(sensorElement.Id.ToString(), Activator.CreateInstance(type, sensorElement.Id));
           }
           return sensorsDict;
       }

        private static Dictionary<string, object> GetControllersDictionary(Repository repository, Assembly assembly)
       {
           Dictionary<string, object> controllersDict = new Dictionary<string, object>();
           Type type;
           foreach (HouseController controllerElement in repository.GetAll<HouseController>())
           {
               type = assembly.GetType("Devices." + controllerElement.HouseControllersType.Name, true, true);
               controllersDict.Add(controllerElement.Id.ToString(), Activator.CreateInstance(type, controllerElement.Id));
           }
           return controllersDict;
       }

        private static List<object> GetTriggersList(Repository repository, Assembly assembly,
           Dictionary<string, object> sensorsDict, Dictionary<string, object> controllersDict)
       {
           List<object> triggersList = new List<object>();
           Type type;
           foreach (Trigger triggerElement in repository.GetAll<Trigger>())
           {
               type = assembly.GetType("Devices." + triggerElement.TriggersType.Name, true, true);

               object obj = Activator.CreateInstance(type, triggerElement.Id ,sensorsDict[triggerElement.Sensor.Id.ToString()],
                   controllersDict[triggerElement.HouseController.Id.ToString()], triggerElement.Condition);
               triggersList.Add(obj);
           }
           return triggersList;
       }
    }   
}
