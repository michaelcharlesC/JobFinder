using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _1150GroupAPI.Models.ApplicationModel;
using _1150GroupAPI.Services;
using Microsoft.AspNet.Identity;

namespace _1150GroupAPI.Controllers
{
   [Authorize]
    public class ApplicationController : ApiController
    {
        private ApplicationServices CreateAplicationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var applicationService = new ApplicationServices(userId);
            return applicationService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            ApplicationServices applicationService = CreateAplicationService();
            var application = applicationService.GetAllApplications();
            return Ok(application);
        }
        [HttpPost]
        public IHttpActionResult Post(ApplicationCreate application)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAplicationService();

            if (!service.CreateApplication(application))
                return InternalServerError();

            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ApplicationServices applicationService = CreateAplicationService();
            var application = applicationService.GetAplicationById(id);
            return Ok(application);
        }
        [HttpGet]
        public IHttpActionResult GetByJobId(int jobId)
        {
            ApplicationServices applicationService = CreateAplicationService();
            var application = applicationService.GetApplicationsByJobId(jobId);
            return Ok(application);
        }
        [HttpPut]
        public IHttpActionResult Put(ApplicationEdit application)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAplicationService();

            if (!service.UpdateApplication(application))
                return InternalServerError();

            return Ok();


        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAplicationService();

            if (!service.DeleteApplication(id))
                return InternalServerError();

            return Ok();
        }
    }
}
