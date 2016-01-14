using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DbInitializer: DropCreateDatabaseAlways<SmartHouseContext>
    {
        protected override void Seed(SmartHouseContext db)
        {
            Sensor s1 = new Sensor{Name = "LightSensor"};
            Sensor s2 = new Sensor{Name = "TemperatureSensor"};
        
            HouseController c1 = new HouseController{Name = "LightController"};
            HouseController c2 = new HouseController{Name = "ConditionerController"};

            Trigger t1 = new Trigger {Name = "LightTrigger", Sensor = s1, HouseController = c1, Condition = "((value < 475) OR value > 500 ) AND value/10 < 51" };
            Trigger t2 = new Trigger {Name = "ConditionerTrigger", Sensor = s2, HouseController = c2, Condition = "79 / 9 * ( value - 25) < 13" };

            SensorsValue sv1 = new SensorsValue { Sensor = s1, TimeMeasurement = DateTime.Now, Value = 470};
            SensorsValue sv2 = new SensorsValue { Sensor = s2, TimeMeasurement = DateTime.Now, Value = 24 };

            TriggersAction ta1 = new TriggersAction { Trigger = t1, TimeChange = DateTime.Now, Description = "OFF"};
            TriggersAction ta2 = new TriggersAction { Trigger = t2, TimeChange = DateTime.Now, Description = "ON" };

            db.Sensors.Add(s1);
            db.Sensors.Add(s2);
            db.HouseControllers.Add(c1);
            db.HouseControllers.Add(c2);
            db.Triggers.Add(t1);
            db.Triggers.Add(t2);
            db.SensorsValues.Add(sv1);
            db.SensorsValues.Add(sv2);
            db.TriggersActions.Add(ta1);
            db.TriggersActions.Add(ta2);
            db.SaveChanges();
       
        }
    }
}

 

