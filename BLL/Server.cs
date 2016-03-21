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
using System.Timers;

namespace BLL
{
    public class Server : IServer
    {
        static string path = @"C:\Users\пкпк\Documents\Visual Studio 2012\VS_Projects\SmartHouseWithServer\Devices\bin\Debug\Devices.dll";
        static Assembly assembly = Assembly.LoadFrom(path);
        private static bool systemWork = true;
        private static bool recordingSensorsValueToDB = false;
        private static bool serverDisable = false; 
        private static System.Timers.Timer aTimer;

        private static int periodicityOfSensorsValuesRecording = 10;
        private static int periodicityOfCheckingWorkStatus = 15;
        private static int periodicityOfTimerTick = 7000;

        public void Initialize()
        {
            StartCheckingSystemWorkStatus();
            SetTimer();
       //     StartSystemWork();
            Console.ReadLine();
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(periodicityOfTimerTick);
            aTimer.Elapsed += new ElapsedEventHandler(StartSystemWork);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }


        private static List<object> ConfigureSystem()
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

        private static void StartSystemWork(Object source, ElapsedEventArgs e)
        {
            if (!serverDisable)
            {

                systemWork = true;
                var triggers = ConfigureSystem();

                if (triggers == null || systemWork == false)
                {
                    Thread.Sleep(100000);
                }
                else
                {
                    RecordWorkStatusToDB("ServerWork");
                         aTimer.Stop();
                    while (systemWork && !serverDisable)
                    {
                        Parallel.ForEach(triggers, UseTrigger);
                        Thread.Sleep(1000);
                    }
                       aTimer.Start();
                }
            }
        }

        private static void RecordWorkStatusToDB(string status)
        {
            using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {
                var statusInDB = repository.GetAll<SystemWorkStatus>().First();

                statusInDB.Status = status;
                repository.Update<SystemWorkStatus>(statusInDB);
                repository.SaveChanges();
            }
        }

        //private void StartMainProsses(List<object> triggersList)
        //{

        //}

        private static void StartRecordingSensorsValues(List<object> sensorsList)
        {
            if (recordingSensorsValueToDB == false)
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
                var res =  repository.GetAll<SystemWorkStatus>().First().Status;
                if (res != "ServerWork")
                {
                    systemWork = false;
                }
                else {
                    systemWork = true;
                }
                 if(res =="ServerDisable"){
                     serverDisable = true;
                 }
                 else{
                    serverDisable = false;
                 }  
            }
        }

        public void StopWork()
        {
            RecordWorkStatusToDB("Error");
        }

        private static void UseTrigger(object obj)
        {
            ITrigger trigger = (ITrigger)obj;
            trigger.CheckSensor();

            if (trigger.StateAfterChange != null)
            {
                using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
                {    
                    TriggersAction triggerAction = new TriggersAction() { TriggerId = trigger.Id, TimeChange = DateTime.Now, Description = trigger.StateAfterChange };
                    repository.Add(triggerAction);
                    repository.SaveChanges();
                }
 
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
