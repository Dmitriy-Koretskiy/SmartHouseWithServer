using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHouseWebApi.Controllers
{
    public class StatisticController : ApiController
    {
        // GET api/statistic
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/statistic/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/statistic
        public void Post([FromBody]string value)
        {
        }

        // PUT api/statistic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/statistic/5
        public void Delete(int id)
        {
        }
    }
}
