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
        [Route("api/Jobs/{id}")]
        public IHttpActionResult GetJobById([FromUri]int id)
        {
            JobServices jobServices = CreateJobServices();
            var job = jobServices.GetJobByJobId(id);
            return Ok(job);
        }
        [Route("api/Jobs/Zipcode/{zipcode}")]
        public IHttpActionResult GetJobByZipCode(int zipcode)
        {
            JobServices jobservices = CreateJobServices();
            var job = jobservices.GetJobByZipCode(zipcode);
            return Ok(job);
        }
        [Route("api/Jobs/companyName")]
        public IHttpActionResult GetAllJobsByCompanyName(string companyName)
        {
            JobServices jobservices = CreateJobServices();
            var jobs = jobservices.GetJobByCompanyName(companyName);
            return Ok(jobs);
        }
        [Route("api/Jobs/companyNameandSalary")]
        public IHttpActionResult GetJobsBySalaryAndJobType(double salary, string comapnyname, string joptype)
        {
            JobServices jobservices = CreateJobServices();
            var jobs = jobservices.GetJobByCompanyNameAndSalary(salary, comapnyname, joptype);
            return Ok(jobs);
        }
        [HttpPut]
        public IHttpActionResult UpdateJob(JobEdit model,int jobid)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model?.JobId != jobid)
                return BadRequest("Job id do not match with the model Id");
            JobServices jobservices = CreateJobServices();
            var jobs = jobservices.UpdateJob(model, jobid);
            if (jobs is false)
                return InternalServerError();
            return Ok("job updated successfully");
        }
        [HttpDelete]
        public IHttpActionResult DeleteJob(int jobid)
        {
            JobServices jobservices = CreateJobServices();
            var job = jobservices.DeleteJob(jobid);
            if (job is false)
                return InternalServerError();
            return Ok("Job Deleted succesfully");
        }
    }
}
