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
    public class SensorsValueRepository : IRepository<SensorsValue>
    {
        private SmartHouseContext db;

        public SensorsValueRepository(SmartHouseContext context)
        {
            this.db = context;
        }

        public IEnumerable<SensorsValue> GetAll()
        {
            return db.SensorsValues;
        }

        public SensorsValue Get(int id)
        {
            return db.SensorsValues.Find(id);
        }

        public void Create(SensorsValue sensorsValue)
        {
            db.SensorsValues.Add(sensorsValue);
        }

        public void Update(SensorsValue sensorsValue)
        {
            db.Entry(sensorsValue).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            SensorsValue sensorsValue = db.SensorsValues.Find(id);
            if (sensorsValue != null)
            {
                db.SensorsValues.Remove(sensorsValue);
            }
        }
    }
}
