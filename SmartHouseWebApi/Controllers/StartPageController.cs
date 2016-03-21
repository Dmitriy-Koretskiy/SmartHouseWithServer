using DAL;
using Interfaces;
using Interfaces.DTO;
using Interfaces.MappingServices;
using Interfaces.Tables;
using Servises.MappingServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHouseWebApi.Controllers
{
    public class StartPageController : ApiController
    {
        IGenericMappingService genericMappingService;
        IServer server;

        public StartPageController(IGenericMappingService mapService, IServer server)
        {
            this.genericMappingService = mapService;
            this.server = server;
        }
        // GET api/startpage

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            var rooms = genericMappingService.MapAll<Room, RoomDTO>();
            response = Request.CreateResponse<IEnumerable<RoomDTO>>(HttpStatusCode.OK, rooms);
            return response;
        }
    }
}
