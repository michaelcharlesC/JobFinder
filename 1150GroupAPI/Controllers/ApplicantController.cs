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
    public class ApplicantController : ApiController
    {
        private ApplicantServices CreateApplicantServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var applicationService = new ApplicantServices(userId);
            return applicationService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            ApplicantServices applicationService = CreateApplicantServices();
            var application = applicationService.GetAllApplicant();
            return Ok(application);
        }
        [HttpPost]
        public IHttpActionResult Post(ApplicantCreate application)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateApplicantServices();

            if (!service.CreateApplicant(application))
                return InternalServerError();

            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ApplicantServices applicationService = CreateApplicantServices();
            var application = applicationService.GetApplicantById(id);
            return Ok(application);
        }

        [HttpPut]
        public IHttpActionResult Put(ApplicantEdit application)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateApplicantServices();

            if (!service.UpdateApplicant(application))
                return InternalServerError();

            return Ok();


        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateApplicantServices();

            if (!service.DeleteApplicant(id))
                return InternalServerError();

            return Ok();
        }
    }
}
