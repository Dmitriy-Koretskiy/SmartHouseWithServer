using DAL;
using Interfaces;
using Interfaces.DTO;
using Interfaces.MappingServices;
using Interfaces.Tables;
using Servises.Services;
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

        //public StartPageController()
        //{
        //    genericMappingService = new GenericMappingService(new Repository(new SmartHouseContext()));

        //}

        public StartPageController(IGenericMappingService mapService, IServer server)
        {
            this.genericMappingService = mapService;
            this.server = server;
        }
        //// GET api/startpage

        ////public HttpResponseMessage Get()
        ////{
        ////    HttpResponseMessage response = null;
        ////    var rooms = genericMappingService.MapAll<Room, RoomDTO>();
        ////    response = Request.CreateResponse<IEnumerable<RoomDTO>>(HttpStatusCode.OK, rooms);
        ////    return response;
        ////}


        public IEnumerable<RoomDTO> Get()
        {
            HttpResponseMessage response = null;
            var rooms = genericMappingService.MapAll<Room, RoomDTO>();
            response = Request.CreateResponse<IEnumerable<RoomDTO>>(HttpStatusCode.OK, rooms);
            return rooms;
        }

        // GET api/startpage/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/startpage
        public void Post([FromBody]string value)
        {
        }

        // PUT api/startpage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/startpage/5
        public void Delete(int id)
        {
        }
    }
}
