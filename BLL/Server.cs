using DAL;
using Interfaces;
using Interfaces.CheckResults;
using Interfaces.Tables;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class Server : IServer
    {
        static string path = @"C:\Users\пкпк\Documents\Visual Studio 2012\VS_Projects\SmartHouseWithServer\Devices\bin\Debug\Devices.dll";
        Assembly assembly = Assembly.LoadFrom(path);
        private bool systemWork = true;

        private List<object> ConfigureSystem()
        {
            Dictionary<string, object> sensorsDict = GetSensorsDictionary();
            Dictionary<string, object> controllersDict = GetControllersDictionary();
            List<object> triggersList = GetTriggersList(sensorsDict, controllersDict);

            var sensorsList = sensorsDict.Values.ToList();
            WorkWithThreads workWithThreads= new WorkWithThreads();
            ChangesOfDB changesOfDB = new ChangesOfDB();
            Action<List<object>> write;
            write = sl=>  changesOfDB.WriteSensorsValuesToDB(sl);
            workWithThreads.Periodic(() => { write(sensorsList); }, TimeSpan.FromSeconds(10), CancellationToken.None);

            return triggersList;
        }

        public void StartSystemWork()
        {
            systemWork = true;
            var triggers = ConfigureSystem();

            if (systemWork == false)
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
            ITrigger trigger = (ITrigger)obj;
            trigger.CheckSensor();

            using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {

                if (trigger.StateAfterChange != null)
                {
                    TriggersAction triggerAction = new TriggersAction() { TriggerId = trigger.Id, TimeChange = DateTime.Now, Description = trigger.StateAfterChange };
                    repository.Add(triggerAction);
                }
                repository.SaveChanges();
            }
        }

        private Dictionary<string, object> GetSensorsDictionary()
        {

            Dictionary<string, object> sensorsDict = new Dictionary<string, object>();
            Type type;

            //using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())

            using ( IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {
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
            }
            return sensorsDict;
        }

        private Dictionary<string, object> GetControllersDictionary()
        {
            Dictionary<string, object> controllersDict = new Dictionary<string, object>();
            Type type;

            using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {
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
            }
            return controllersDict;
        }

        private List<object> GetTriggersList(Dictionary<string, object> sensorsDict, Dictionary<string, object> controllersDict)
        {
            List<object> triggersList = new List<object>();
            Type type;

            using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {

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
            using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {
                foreach (Sensor sensorElement in repository.GetAll<Sensor>().Where(s => s.Enable == true))
                {
                    try
                    {
                        type = assembly.GetType("Devices1." + sensorElement.SensorsType.Name, true, true);
                    }
                    catch
                    {
                        checkResult.errorExist = true;
                        var device = new MissingDevice() {RoomName = sensorElement.Room.Name, DeviceName = sensorElement.Name };

                        checkResult.missingDevices.Add(device);

                    }
                }

                foreach (HouseController controllerElement in repository.GetAll<HouseController>().Where(c => c.Enable == true))
                {
                    try
                    {
                        type = assembly.GetType("Devices1." + controllerElement.HouseControllersType.Name, true, true);
                    }
                    catch
                    {
                        checkResult.errorExist = true;
                        var device = new MissingDevice() { RoomName = controllerElement.Room.Name, DeviceName = controllerElement.Name };
                        
                        checkResult.missingDevices.Add(device);
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
                        var device = new MissingDevice() { RoomName = triggerElement.Room.Name, DeviceName = triggerElement.Name };

                        checkResult.missingDevices.Add(device);
                    }
                }
            }
            return checkResult;
        }
    }
}
