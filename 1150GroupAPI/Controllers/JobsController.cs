using _1150GroupAPI.Models.JobsModels;
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
        public IHttpActionResult PostJob(JobCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model is null)
                return BadRequest("You cannot have an empty input");

            var service = CreateJobServices();

            if (!service.CreateJob(model))
                return InternalServerError();

            return Ok();
        }
    }
}
