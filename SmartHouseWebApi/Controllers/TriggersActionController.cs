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
    public class TriggersActionController : ApiController
    {
        IMappingService<TriggersActionDTO> triggersActionMappingService { get; set; }

        // GET api/triggersaction/5
        public IEnumerable<TriggersActionDTO> Get(int roomId)
        {
            if (roomId != 0)
            {
                var triggersActions = triggersActionMappingService.GetByRoomId(roomId);
                return triggersActions;
            }
            else
            {
                var triggersActions = triggersActionMappingService.GetAll();
                return triggersActions;
            }
        }
    }
}
