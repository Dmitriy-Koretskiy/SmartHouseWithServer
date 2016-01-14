using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

using System.Data.Entity;

namespace DAL
{
    public class Repository: IRepository
    {
        private readonly SmartHouseContext db;

        public Repository()
        {
            this.db = new SmartHouseContext();
        }

        public IEnumerable<T> GetAll<T>() where T: class
        {
            return db.Set<T>();
        }

        public T Get<T>(int? id) where T: class 
        {
            return db.Set<T>().Find(id);
        }

        public void Add<T>(T entity) where T : class
        {
            this.db.Set<T>().Add(entity);
            this.db.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            this.db.Set<T>().Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }
    }
}
