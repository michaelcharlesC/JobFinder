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
        public IHttpActionResult GetAllJob()
        {
            JobServices jobService = CreateJobServices();
            var jobs = jobService.GetAllJobs();
            return Ok(jobs);

        }
        [Route("api/Job/{id}")]
        public IHttpActionResult GetJobById([FromUri]int id)
        {
            JobServices jobServices = CreateJobServices();
            var job = jobServices.GetJobByJobId(id);
            return Ok(job);
        }
        [Route("api/Job/{zipcode}")]
        public IHttpActionResult GetJobByZipCode(int zipcode)
        {
            JobServices jobservices = CreateJobServices();
            var job = jobservices.GetJobByZipCode(zipcode);
            return Ok(job);
        }
    }
}
