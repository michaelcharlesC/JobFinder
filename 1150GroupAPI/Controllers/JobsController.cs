using _1150GroupAPI.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1150GroupAPI.Controllers
{
    public class JobsController : ApiController
    {
        private JobServices CreateJobServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var jservices = new JobServices(userid);
            return jservices;

        }
    }
}
