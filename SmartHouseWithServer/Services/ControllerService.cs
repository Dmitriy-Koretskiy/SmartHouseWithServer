using SmartHouseWithServer.Interfaces;
using SmartHouseWithServer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Tables;
using AutoMapper;
using DAL;

namespace SmartHouseWithServer.Services
{
    public class ControllerService : IControllerService
    {
        IRepository repository { get; set; }

        public ControllerService()    // should use IoC
        {
            this.repository = new Repository();
        }

        public ControllerDTO GetController(int? id)
        {
            var controller = repository.Get<Controller>(id);
            Mapper.CreateMap<Controller, ControllerDTO>();
            return Mapper.Map<Controller, ControllerDTO>(controller);
        }

        public IEnumerable<ControllerDTO> GetControllers()
        {
            Mapper.CreateMap<Controller, ControllerDTO>();
            return Mapper.Map<IEnumerable<Controller>, List<ControllerDTO>>(repository.GetAll<Controller>());
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
