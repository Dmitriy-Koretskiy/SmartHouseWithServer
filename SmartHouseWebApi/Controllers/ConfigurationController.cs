﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHouseWebApi.Controllers
{
    public class ConfigurationController : ApiController
    {
        // GET api/configuration
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/configuration/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/configuration
        public void Post([FromBody]string value)
        {
        }

        // PUT api/configuration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/configuration/5
        public void Delete(int id)
        {
        }
    }
}
