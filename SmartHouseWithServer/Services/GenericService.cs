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

        public N GetController<N , O>(int? id) 
            where O: class
            where N: class 
        {
            var controller = repository.Get<O>(id);
            return Mapper.Map<O, N>(controller);
        }

        public IEnumerable<N> GetControllers<N,O>()
            where N : class
            where O : class
        {
            return Mapper.Map<IEnumerable<O>, List<N>>(repository.GetAll<O>());
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
