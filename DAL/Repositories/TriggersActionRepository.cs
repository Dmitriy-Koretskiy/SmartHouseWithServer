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
    public class TriggersActionRepository : IRepository<TriggersAction>
    {
        private SmartHouseContext db;

        public TriggersActionRepository(SmartHouseContext context)
        {
            this.db = context;
        }

        public IEnumerable<TriggersAction> GetAll()
        {
            return db.TriggersActions;
        }

        public TriggersAction Get(int id)
        {
            return db.TriggersActions.Find(id);
        }

        public void Create(TriggersAction triggersAction)
        {
            db.TriggersActions.Add(triggersAction);
        }

        public void Update(TriggersAction triggersAction)
        {
            db.Entry(triggersAction).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TriggersAction triggersAction = db.TriggersActions.Find(id);
            if (triggersAction != null)
            {
                db.TriggersActions.Remove(triggersAction);
            }
        }
    }
}
