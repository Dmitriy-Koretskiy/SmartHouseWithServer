using AutoMapper;
using DAL;
using Interfaces;
using Interfaces.Tables;
using SmartHouseWithServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWithServer.Services
{
    public class GenericService: IGenericService
    {
        IRepository repository { get; set; }

        public GenericService()    // should use IoC
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

        public void AddToDB<O, N>(O oldObject)
            where O : class
            where N : class
        {
            var newObject = Mapper.Map<O, N>(oldObject);
            repository.Update<N>(newObject);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
