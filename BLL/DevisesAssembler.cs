using Interfaces;
using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DevisesAssembler
    {
        Assembly assembly;

        public DevisesAssembler(Assembly asm)
        {
            assembly = asm;
        }

        public Dictionary<string, object> GetSensorsDictionary(IRepository repository)
        {

            Dictionary<string, object> sensorsDict = new Dictionary<string, object>();
            Type type;

            foreach (Sensor sensorElement in repository.GetAll<Sensor>().Where(s => s.Enable == true))
            {
                type = GetDeviceTypeTry(sensorElement.SensorsType.Name);

                if (type == null)
                {
                    return null;
                }
                else
                {
                    sensorsDict.Add(sensorElement.Id.ToString(), Activator.CreateInstance(type, sensorElement.Id));
                }
            }

            return sensorsDict;
        }

        public Dictionary<string, object> GetControllersDictionary(IRepository repository)
        {
            Dictionary<string, object> controllersDict = new Dictionary<string, object>();
            Type type;

            foreach (HouseController controllerElement in repository.GetAll<HouseController>().Where(c => c.Enable == true))
            {
                type = GetDeviceTypeTry(controllerElement.HouseControllersType.Name);

                if (type == null)
                {
                    return null;
                }
                else
                {
                    controllersDict.Add(controllerElement.Id.ToString(), Activator.CreateInstance(type, controllerElement.Id));
                }
            }

            return controllersDict;
        }

        public List<object> GetTriggersList(Dictionary<string, object> sensorsDict, Dictionary<string, object> controllersDict, IRepository repository, out bool exeption)
        {
            List<object> triggersList = new List<object>();
            Type type;

            foreach (Trigger triggerElement in repository.GetAll<Trigger>().Where(t => t.Enable == true))
            {
                type = GetDeviceTypeTry("Trigger");

                if (type == null)
                {
                    exeption = true;
                    return null;
                }
                else
                {
                    object obj = Activator.CreateInstance(type, triggerElement.Id, sensorsDict[triggerElement.Sensor.Id.ToString()],
                        controllersDict[triggerElement.HouseController.Id.ToString()], triggerElement.Condition);
                    triggersList.Add(obj);
                }
            }

            exeption = false;
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
    }
}
