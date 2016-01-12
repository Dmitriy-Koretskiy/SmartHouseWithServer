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
    public class ControllerRepository : IRepository<Controller>
    {

        private SmartHouseContext db;

        public ControllerRepository(SmartHouseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Controller> GetAll()
        {
            return db.Controllers;
        }

        public Controller Get(int id)
        {
            return db.Controllers.Find(id);
        }

        public void Create(Controller controller)
        {
            db.Controllers.Add(controller);
        }

        public void Update(Controller controller)
        {
            db.Entry(controller).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Controller controller = db.Controllers.Find(id);
            if (controller != null)
            {
                db.Controllers.Remove(controller);
            }
        }
    }
}