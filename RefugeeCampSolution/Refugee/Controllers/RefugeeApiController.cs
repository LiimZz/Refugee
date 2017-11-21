using Refugee.Data;
using Refugee.Domain.Entities;
using Refugee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
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
    
        //public HttpResponseMessage Get()
        //{
        //    var response = Request.CreateResponse(HttpStatusCode.OK, new List<Refug>());

        //    // Set headers for paging
        //    CookieHeaderValue hc = new CookieHeaderValue("bouda","bader");
        //    hc.Expires = DateTimeOffset.Now.AddDays(1);
        //    hc.Domain = Request.RequestUri.Host;
        //    hc.Path = "/";

        //    response.Headers.Add("token","bouda");
        //    response.Headers.AddCookies(new CookieHeaderValue[] { hc });
          
        //    // Return the response
        //    return response;
        //}

        // POST: api/RefugeeApi
        public void Post([FromBody]Refug rf)
        {
            rs.CreateRefug(rf);
        }

        // GET: api/RefugeeApi/5
        public Refug Get(int id)
        {
            return rs.GetRefugByID(id);
        }

    }
}
