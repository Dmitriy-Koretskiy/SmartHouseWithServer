using BLL;
using Interfaces;
using Interfaces.DTO;
using Interfaces.InteractionWithouyApplications;
using Interfaces.MappingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHouseWebApi.Controllers
{
    public class RoomController : ApiController
    {
        IRoomMappingService roomMappingService { get; set; }
        ISensorsValueMappingService sensorsValueMappingService { get; set; }
        IServer server;

        public RoomController(IRoomMappingService roomMapService, ISensorsValueMappingService sensorMapService, IServer server)
        {
            this.roomMappingService = roomMapService;
            this.sensorsValueMappingService = sensorMapService;
            this.server = new Server();
        }

        [HttpGet]
        [ActionName("checkConfig")]
        public List<MissingDevice> CheckConfig()
        {
            return server.CheckConfiguration();   
        }

        // GET api/room/5
        public IEnumerable<RoomContentDTO> Get(int roomId)
        {
            if (roomId <= 0)
            {
                return null;
            }
            var room = roomMappingService.GetRoomById((int)roomId);
            var triggersStates = roomMappingService.GetLastStatesOfTriggers((int)roomId);
            return triggersStates;
        }
    }
}
