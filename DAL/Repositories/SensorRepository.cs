using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Tables;
using Interfaces;

namespace DAL.Repositories
{
    public class SensorRepository : IRepository<Sensor>
    {
        private SmartHouseContext db;

        public SensorRepository(SmartHouseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Sensor> GetAll()
        {
            return db.Sensors;
        }

        public Sensor Get(int id)
        {
            return db.Sensors.Find(id);
        }

        public void Create(Sensor sensor)
        {
            db.Sensors.Add(sensor);
        }

        public void Update(Sensor sensor)
        {
            db.Entry(sensor).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Sensor sensor = db.Sensors.Find(id);
            if (sensor != null)
            {
                db.Sensors.Remove(sensor);
            }
        }
    }
}
