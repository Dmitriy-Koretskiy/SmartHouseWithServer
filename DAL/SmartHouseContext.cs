using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Tables;

namespace DAL
{
    public class SmartHouseContext : DbContext
    {
        public SmartHouseContext()
        {
         Database.SetInitializer<SmartHouseContext>(new DbInitializer());
        }

        public DbSet<HouseController> HouseControllers { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Trigger> Triggers { get; set; }
        public DbSet<SensorsValue> SensorsValues { get; set; }
        public DbSet<TriggersAction> TriggersActions { get; set; }
    }
}
