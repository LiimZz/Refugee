using Microsoft.AspNet.Identity;
using Refugee.Domain.Entities;
using Refugee.Services;
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
        UserService us;

        public AccountApiController()
        {
            us = new UserService();
        }

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

            User u = us.getUserByToken(token);
            var response = Request.CreateResponse(HttpStatusCode.OK, u);
            response.Headers.Add("token", token);

            return response;
        }

    }
}
