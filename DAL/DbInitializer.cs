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
        
            HouseController c1 = new HouseController{Name = "LightController", Device= new Device{Name="Lamp"}};
            HouseController c2 = new HouseController{Name = "ConditionerController", Device= new Device{Name="Conditioner"}};

            Trigger t1 = new Trigger {Name = "LightTrigger", Sensor = s1, HouseController = c1, Condition = "((value < 475) OR value > 500 ) AND value/10 < 51" };
            Trigger t2 = new Trigger {Name = "ConditionerTrigger", Sensor = s2, HouseController = c2, Condition = "79 / 9 * ( value - 25) < 13" };

            db.Sensors.Add(s1);
            db.Sensors.Add(s2);
            db.HouseControllers.Add(c1);
            db.HouseControllers.Add(c2);
            db.Triggers.Add(t1);
            db.Triggers.Add(t2);
            db.SaveChanges();
       
        }
    }
}

 

