using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository: IDisposable
    {
        IEnumerable<T> GetAll<T>() where T: class;
        T Get<T>(int? id) where T : class;
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        void Update<T>(T entity) where T : class;
        void SaveChanges();
    }
}
