using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouseWithServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly asm = Assembly.LoadFrom(@"..\..\..\Devices\bin\Debug\Devices.dll");
            XDocument xdoc = XDocument.Load("DevicesInHouse.xml");
            Dictionary<string, object> sensorsDict = GetSensorsDictionary(xdoc, asm);
            Dictionary<string, object> controllersDict = GetControllersDictionary(xdoc, asm);
            List<object> triggersList = GetTriggersList(xdoc, asm, sensorsDict, controllersDict);
            for (; ; )
            {
                Parallel.ForEach(triggersList, UseTrigger);
                Thread.Sleep(1000);
            }
        }

        private static void UseTrigger(object obj)
        {
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod("CheckSensor");
            method.Invoke(obj, null);
        }

       private static Dictionary<string, object> GetSensorsDictionary(XDocument xdoc, Assembly assembly)
       {
           Dictionary<string, object> sensorsDict = new Dictionary<string, object>();
           Type type;
           foreach (XElement sensorElement in xdoc.Element("devices").Element("sensors").Elements("sensor"))
           {
               XAttribute nameAttribute = sensorElement.Attribute("name");
               type = assembly.GetType("Devices." + nameAttribute.Value, true, true);
               sensorsDict.Add(nameAttribute.Value, Activator.CreateInstance(type));
           }
           return sensorsDict;
       }

       private static Dictionary<string, object> GetControllersDictionary(XDocument xdoc, Assembly assembly)
       {
           Dictionary<string, object> controllersDict = new Dictionary<string, object>();
           Type type;
           foreach (XElement controllerElement in xdoc.Element("devices").Element("controllers").Elements("controller"))
           {
               XAttribute nameAttribute = controllerElement.Attribute("name");
               type = assembly.GetType("Devices." + nameAttribute.Value, true, true);
               controllersDict.Add(nameAttribute.Value, Activator.CreateInstance(type));
           }
           return controllersDict;
       }

       private static List<object> GetTriggersList(XDocument xdoc, Assembly assembly,
           Dictionary<string, object> sensorsDict, Dictionary<string, object> controllersDict)
       {
           List<object> triggersList = new List<object>();
           Type type;
           foreach (XElement triggerElement in xdoc.Element("devices").Element("triggers").Elements("trigger"))
           {
               XAttribute nameAttribute = triggerElement.Attribute("name");
               XAttribute sensorAttribute = triggerElement.Attribute("sensor");
               XAttribute controllerAttribute = triggerElement.Attribute("controller");
               XAttribute conditionAttribute = triggerElement.Attribute("condition");
               type = assembly.GetType("Devices." + nameAttribute.Value, true, true);

               object obj = Activator.CreateInstance(type, sensorsDict[sensorAttribute.Value],
                   controllersDict[controllerAttribute.Value], int.Parse(conditionAttribute.Value));
               triggersList.Add(obj);
           }
           return triggersList;
       }
    }
}
