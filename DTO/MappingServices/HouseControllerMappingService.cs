using AutoMapper;
using DAL;
using Interfaces;
using Interfaces.DTO;
using Interfaces.MappingServices;
using Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servises.Services
{
    public class HouseControllerMappingService : IMappingService<HouseControllerDTO>
    {
        IRepository repository;

        public HouseControllerMappingService(IRepository rep)    // should use IoC
        {
            this.repository = rep;
        }

        public HouseControllerDTO GetById(int? id)  
        {
            return Mapper.Map<HouseController, HouseControllerDTO>(repository.Get<HouseController>(id));
        }

        public IEnumerable<HouseControllerDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<HouseController>, List<HouseControllerDTO>>(repository.GetAll<HouseController>());
        }

        public IEnumerable<HouseControllerDTO> GetByRoomId(int roomId)
        {
            return Mapper.Map<IEnumerable<HouseController>, List<HouseControllerDTO>>(repository.GetAll<HouseController>().Where(t => t.RoomId == roomId));
        }

        public void Add(HouseControllerDTO oldObject)
        {
            HouseController newObject = Mapper.Map<HouseControllerDTO, HouseController>(oldObject);
            repository.Add<HouseController>(newObject);
            repository.SaveChanges();
        }

        public void Edit(HouseControllerDTO oldObject)
        {
            var newObject = Mapper.Map<HouseControllerDTO, HouseController>(oldObject);
            repository.Update<HouseController>(newObject);
            repository.SaveChanges();
        }

        public void Delete(int? id)
        {
            var obj = repository.Get<HouseController>(id);
            repository.Delete<HouseController>(obj);
            repository.SaveChanges();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
