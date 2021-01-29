using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Hotspot> Get()
        {

            List<Hotspot> hs = new List<Hotspot>();
            hs = GetStats.getAllStats();

            return hs;

        }
        // GET api/values/5
        public List<Hotspot> Get(string id)
        {
            List<Hotspot> hs = new List<Hotspot>();
            hs = GetStats.getStatForProvince(id);

            return hs;

        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
