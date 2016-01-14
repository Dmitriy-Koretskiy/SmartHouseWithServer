using AutoMapper;
using DAL;
using Interfaces;
using Interfaces.Tables;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenericMappingService: IGenericMappingService
    {
        IRepository repository { get; set; }

        public GenericMappingService()    // should use IoC
        {
            this.repository = new Repository();
        }

        public N MapById<O,N>(int? id) 
            where O: class
            where N: class 
        {
            var oldObject = repository.Get<O>(id);
            return Mapper.Map<O, N>(oldObject);
        }

        public IEnumerable<N> MapAll<O,N>()
            where N : class
            where O : class
        {
            return Mapper.Map<IEnumerable<O>, List<N>>(repository.GetAll<O>());
        }

        public void Add<O, N>(O oldObject)
            where O : class
            where N : class
        {
            var newObject = Mapper.Map<O, N>(oldObject);
            repository.Add<N>(newObject);
            repository.SaveChanges();
        }

        public void Edit<O, N>(O oldObject)
            where O : class
            where N : class
        {
            var newObject = Mapper.Map<O, N>(oldObject);
            repository.Update<N>(newObject);
            repository.SaveChanges();
        }

        public void Delete<O>(int id)
            where O : class
        {
            var obj = repository.Get<O>(id);
            repository.Delete<O>(obj);
            repository.SaveChanges();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
