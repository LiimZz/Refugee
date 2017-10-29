using Refugee.Data;
using Refugee.Domain.Entities;
using Refugee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Refugee.Controllers
{
    public class RefugeeApiController : ApiController
    {
        IRefugService rs = null;
        RefugeeDbContext rd;
        // GET: api/RefugeeApi
        public IEnumerable<Refug> Get()
        {
            rs = new RefugService();
            return rs.GetAllRefug();
        }

        // GET: api/RefugeeApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RefugeeApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RefugeeApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RefugeeApi/5
        public void Delete(int id)
        {
        }
    }
}
