using DAL;
using Interfaces;
using Interfaces.InteractionWithouyApplications;
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
        private bool recordingSensorsValueToDB = false;

        private int periodicityOfSensorsValuesRecording = 10;
        private int periodicityOfCheckingWorkStatus = 15;

        public void Initialize()
        {
            StartCheckingSystemWorkStatus();
            StartSystemWork();
        }

        private List<object> ConfigureSystem()
        {
            using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {
                DevisesAssembler devisesAssembler = new DevisesAssembler(assembly);
                
                Dictionary<string, object> sensorsDict = devisesAssembler.GetSensorsDictionary(repository);
                if (sensorsDict == null)
                {
                    RecordWorkStatusToDB("Error");
                    systemWork = false;
                    return null;
                }
                Dictionary<string, object> controllersDict = devisesAssembler.GetControllersDictionary(repository);
                if (controllersDict == null)
                {
                    RecordWorkStatusToDB("Error");
                    systemWork = false;
                    return null;
                }

                bool triggersAssemblingExeption = false;

                List<object> triggersList = devisesAssembler.GetTriggersList(sensorsDict, controllersDict, repository, out triggersAssemblingExeption);
                if (!triggersList.Any())
                {
                    if (triggersAssemblingExeption == false)
                    {
                        RecordWorkStatusToDB("SensorsWork");
                        return null;
                    }
                    else
                    {
                        RecordWorkStatusToDB("Error");
                    }
                }

                var sensorsList = sensorsDict.Values.ToList();
                StartRecordingSensorsValues(sensorsList);

                return triggersList;
            }
        }

        private void StartSystemWork()
        {
            systemWork = true;
            var triggers = ConfigureSystem();

            if (triggers == null || systemWork == false)
            {                
                Thread.Sleep(100000);
                StartSystemWork();
            }

            RecordWorkStatusToDB("ServerWork");
            StartMainProsses(triggers);
        }

        private void RecordWorkStatusToDB(string status)
        {
            using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {
                var statusInDB = repository.GetAll<SystemWorkStatus>().First();

                statusInDB.Status = status;
                repository.Update<SystemWorkStatus>(statusInDB);
                repository.SaveChanges();
            }
        }

        private void StartMainProsses(List<object> triggersList)
        {
            while (systemWork)
            {
                Parallel.ForEach(triggersList, UseTrigger);
                Thread.Sleep(1000);
            }
            StartSystemWork();
        }

        private void StartRecordingSensorsValues(List<object> sensorsList)
        {
            if (this.recordingSensorsValueToDB == false)
            {
                WorkWithThreads workWithThreads = new WorkWithThreads();
                ChangesOfDB changesOfDB = new ChangesOfDB();

                workWithThreads.Periodic(() => { changesOfDB.WriteSensorsValuesToDB(sensorsList); },
                    TimeSpan.FromSeconds(periodicityOfSensorsValuesRecording), CancellationToken.None);

                recordingSensorsValueToDB = true;
            }
        }

        private void StartCheckingSystemWorkStatus()
        {

            WorkWithThreads workWithThreads = new WorkWithThreads();

            workWithThreads.Periodic(CheckSystemWorkStatus, TimeSpan.FromSeconds(periodicityOfCheckingWorkStatus), CancellationToken.None);
        }

        private void CheckSystemWorkStatus()
        {
            using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {
                if (repository.GetAll<SystemWorkStatus>().First().Status != "ServerWork")
                {
                    systemWork = false;
                }
            }
        }

        public void StopWork()
        {
            RecordWorkStatusToDB("Error");
         //   this.systemWork = false;
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

        public List<MissingDevice> CheckConfiguration()
        {
            List<MissingDevice> missingDevices = new List<MissingDevice>();


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
                        var device = new MissingDevice() { RoomName = sensorElement.Room.Name, DeviceName = sensorElement.Name };

                        missingDevices.Add(device);

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
                        var device = new MissingDevice() { RoomName = controllerElement.Room.Name, DeviceName = controllerElement.Name };

                        missingDevices.Add(device);
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
                        var device = new MissingDevice() { RoomName = triggerElement.Room.Name, DeviceName = triggerElement.Name };

                        missingDevices.Add(device);
                    }
                }
            }
            return missingDevices;
        }
    }
}
