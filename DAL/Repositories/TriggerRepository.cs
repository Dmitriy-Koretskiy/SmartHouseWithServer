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
    public class TriggerRepository : IRepository<Trigger>
    {
        private SmartHouseContext db;

        public TriggerRepository(SmartHouseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Trigger> GetAll()
        {
            return db.Triggers;
        }

        public Trigger Get(int id)
        {
            return db.Triggers.Find(id);
        }

        public void Create(Trigger trigger)
        {
            db.Triggers.Add(trigger);
        }

        public void Update(Trigger trigger)
        {
            db.Entry(trigger).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Trigger trigger = db.Triggers.Find(id);
            if (trigger != null)
            {
                db.Triggers.Remove(trigger);
            }
        }
    }
}
