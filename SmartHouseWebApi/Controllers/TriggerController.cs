using Interfaces.DTO;
using Interfaces.MappingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHouseWebApi.Controllers
{
    public class TriggerController : ApiController
    {
        IMappingService<TriggerDTO> triggerMappingService;
        IGenericMappingService genericMappingService;

        public TriggerController(IGenericMappingService genericMapService, IMappingService<TriggerDTO> triggerMapService)
        {
            this.triggerMappingService = triggerMapService;
            this.genericMappingService = genericMapService;
        }

        // GET api/trigger/5
        public IEnumerable<TriggerDTO> Get(int roomId)
        {
            if (roomId != 0)
            {
                var triggers = triggerMappingService.
                    GetByRoomId(roomId);
                return triggers;
            }
            else
            {
                var triggers = triggerMappingService.GetAll();
                return triggers;
            }
        }

        // POST api/trigger
        public void Post([FromBody]string value)
        {
        }

        // PUT api/trigger/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/trigger/5
        public void Delete(int id)
        {
        }
    }
}
