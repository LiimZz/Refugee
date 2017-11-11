using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Refugee.Controllers
{
    public class AccountApiController : ApiController
    {
        // GET: api/AccountApi
     
       
        // GET: api/AccountApi/5
        public HttpResponseMessage Gettoken()
        {
            var re = Request;
            var headers = re.Headers;
            string token = "";
            if (headers.Contains("Jtoken"))
            {
                 token = headers.GetValues("Jtoken").First();
            }
            Services.UserService us = new Services.UserService();
            User u =
            us.getUserByToken(token);
            var response = Request.CreateResponse(HttpStatusCode.OK, u);
            response.Headers.Add("token", token);

            return response;
        }

        // POST: api/AccountApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AccountApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AccountApi/5
        public void Delete(int id)
        {
        }
    }
}
