using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DbInitializer : DropCreateDatabaseAlways<SmartHouseContext>
    {
        protected override void Seed(SmartHouseContext db)
        {
            Room r1 = new Room { Name = "Living room", Image = "assets/images/LivingRoom.jpg" };
            Room r2 = new Room { Name = "Kitchen", Image = "assets/images/Kitchen.jpg" };

            SensorsType st1 = new SensorsType { Name = "LightSensor" };
            SensorsType st2 = new SensorsType { Name = "TemperatureSensor" };

            Sensor s1 = new Sensor { Name = "Living room light sensor", Enable = true, Room = r1, SensorsType = st1 };
            Sensor s2 = new Sensor { Name = "Living room temperature sensor", Enable = true, Room = r1, SensorsType = st2 };
            Sensor s3 = new Sensor { Name = "Kitchen light sensor", Enable = true, Room = r2, SensorsType = st1 };

            HouseControllersType ct1 = new HouseControllersType { Name = "LightController" };
            HouseControllersType ct2 = new HouseControllersType { Name = "ConditionerController" };

            HouseController c1 = new HouseController { Name = "Living room light controller", Enable = true, Room = r1, HouseControllersType = ct1 };
            HouseController c2 = new HouseController { Name = "Living room conditioner controller", Enable = true, Room = r1, HouseControllersType = ct2 };
            HouseController c3 = new HouseController { Name = "Kitchen light controller", Enable = true, Room = r2, HouseControllersType = ct1 };

            TriggersType tt1 = new TriggersType { Name = "LightTrigger", Image = "assets/images/Lamp.bmp" };
            TriggersType tt2 = new TriggersType { Name = "ConditionerTrigger", Image = "assets/images/Conditioner.bmp" };

            Trigger t1 = new Trigger
            {
                Name = "Living room light trigger",
                Sensor = s1,
                HouseController = c1,
                Enable = true,
                Room = r1,
                TriggersType = tt1,
                Condition = "value < 475 ",
            };
            Trigger t2 = new Trigger
            {
                Name = "Living room conditioner trigger",
                Sensor = s2,
                HouseController = c2,
                Enable = true,
                Room = r1,
                TriggersType = tt2,
                Condition = "value > 27"
            };
            Trigger t3 = new Trigger
            {
                Name = "Kitchen light trigger",
                Sensor = s3,
                HouseController = c3,
                Enable = true,
                Room = r2,
                TriggersType = tt1,
                Condition = "value< 465"
            };

            SensorsValue sv1 = new SensorsValue { Sensor = s1, TimeMeasurement = DateTime.Now, Value = 470 };
            SensorsValue sv2 = new SensorsValue { Sensor = s2, TimeMeasurement = DateTime.Now, Value = 24 };
            SensorsValue sv3 = new SensorsValue { Sensor = s3, TimeMeasurement = DateTime.Now, Value = 490 };

            TriggersAction ta1 = new TriggersAction { Trigger = t1, TimeChange = DateTime.Now, Description = "Off" };
            TriggersAction ta2 = new TriggersAction { Trigger = t2, TimeChange = DateTime.Now, Description = "On" };
            TriggersAction ta3 = new TriggersAction { Trigger = t3, TimeChange = DateTime.Now, Description = "Off" };

            SystemWorkStatus sws = new SystemWorkStatus { Status = "Init" }; 

            db.Rooms.Add(r1);
            db.Rooms.Add(r2);
            db.HouseControllersTypes.Add(ct1);
            db.HouseControllersTypes.Add(ct2);
            db.SensorsTypes.Add(st1);
            db.SensorsTypes.Add(st2);
            db.TriggersTypes.Add(tt1);
            db.TriggersTypes.Add(tt2);
            db.Sensors.Add(s1);
            db.Sensors.Add(s2);
            db.Sensors.Add(s3);
            db.HouseControllers.Add(c1);
            db.HouseControllers.Add(c2);
            db.HouseControllers.Add(c3);
            db.Triggers.Add(t1);
            db.Triggers.Add(t2);
            db.Triggers.Add(t1);
            db.Triggers.Add(t2);
            db.Triggers.Add(t3);
            db.SensorsValues.Add(sv1);
            db.SensorsValues.Add(sv2);
            db.SensorsValues.Add(sv3);
            db.TriggersActions.Add(ta1);
            db.TriggersActions.Add(ta2);
            db.TriggersActions.Add(ta3);
            db.SystemWorkStatus.Add(sws);
            db.SaveChanges();
        }
    }
}



