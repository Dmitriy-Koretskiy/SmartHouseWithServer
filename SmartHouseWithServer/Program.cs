using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Interfaces;
using DAL;
using DAL.Tables;

namespace SmartHouseWithServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Assembly asm = Assembly.LoadFrom(@"..\..\..\Devices\bin\Debug\Devices.dll");
            Dictionary<string, object> sensorsDict = GetSensorsDictionary(unitOfWork, asm);
            Dictionary<string, object> controllersDict = GetControllersDictionary(unitOfWork, asm);
            List<object> triggersList = GetTriggersList(unitOfWork, asm, sensorsDict, controllersDict);
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


        private static Dictionary<string, object> GetSensorsDictionary(UnitOfWork unitOfWork, Assembly assembly)
       {
           Dictionary<string, object> sensorsDict = new Dictionary<string, object>();
           Type type;
           foreach (Sensor sensorElement in unitOfWork.Sensors.GetAll())
           {
               type = assembly.GetType("Devices." + sensorElement.Name, true, true);
               sensorsDict.Add(sensorElement.Name, Activator.CreateInstance(type));
           }
           return sensorsDict;
       }

        private static Dictionary<string, object> GetControllersDictionary(UnitOfWork unitOfWork, Assembly assembly)
       {
           Dictionary<string, object> controllersDict = new Dictionary<string, object>();
           Type type;
           foreach (Controller controllerElement in unitOfWork.Controllers.GetAll())
           {
               type = assembly.GetType("Devices." + controllerElement.Name, true, true);
               controllersDict.Add(controllerElement.Name, Activator.CreateInstance(type));
           }
           return controllersDict;
       }

        private static List<object> GetTriggersList(UnitOfWork unitOfWork, Assembly assembly,
           Dictionary<string, object> sensorsDict, Dictionary<string, object> controllersDict)
       {
           List<object> triggersList = new List<object>();
           Type type;
           foreach (Trigger triggerElement in unitOfWork.Triggers.GetAll())
           {
               type = assembly.GetType("Devices." + triggerElement.Name, true, true);

               object obj = Activator.CreateInstance(type, sensorsDict[triggerElement.Sensor.Name],
                   controllersDict[triggerElement.Controller.Name], triggerElement.Condition);
               triggersList.Add(obj);
           }
           return triggersList;
       }
    }
}
