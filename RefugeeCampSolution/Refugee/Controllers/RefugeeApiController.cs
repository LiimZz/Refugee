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
        public RefugeeApiController()
        {
            rs = new RefugService();
        }

        // GET: api/RefugeeApi
        public IEnumerable<Refug> Get()
        {
            return rs.GetAllRefug();
        }

        // GET: api/RefugeeApi/5
        public Refug Get(int id)
        {
            return rs.GetRefugByID(id);
        }

        // POST: api/RefugeeApi
        public void Post([FromBody]Refug rf,[FromUri] string adminID )
        {
            Refug r = new Refug
            {

            };
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
