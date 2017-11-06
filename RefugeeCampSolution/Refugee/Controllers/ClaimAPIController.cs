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
    public class ClaimAPIController : ApiController
    {
        IClaimService clmserv;
        public ClaimAPIController()
        {
            clmserv = new ClaimService();
        }

        // GET: api/ClaimAPI
        public IEnumerable<PostClaims> Get()
        {
            return clmserv.getAllClaims(); ;
        }

        // GET: api/ClaimAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ClaimAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ClaimAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ClaimAPI/5
        public void Delete(int id)
        {
        }
    }
}
