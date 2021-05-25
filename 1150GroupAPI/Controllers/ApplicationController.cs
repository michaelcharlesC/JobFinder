using _1150GroupAPI.Models.Application2Model;
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

    [Authorize]
    public class ApplicationController : ApiController
    {
        private ApplicationServices CreateApplicationServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var applicationService = new ApplicationServices(userId);
            return applicationService;
        }

        public IHttpActionResult PostApplication(ApplicationCreate model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model is null)
                return BadRequest("You cannot have an empty input");
            if (model.ApplicantId == 0 || model.JobId == 0)
                return BadRequest("Id cannot be null");

            var service = CreateApplicationServices();

            if (!service.CreateApplication(model))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult GetAllApplication()
        {
            var applicationService = CreateApplicationServices();
            var applications = applicationService.GetAllApplication();
            return Ok(applications);

        }
        public IHttpActionResult GetApplicationById(int id)
        {
            var applicationService = CreateApplicationServices();
            var application = applicationService.GetApplicationById(id);
            return Ok(application);

        }
        public IHttpActionResult GetApplicationByCompanyName(string CompanyName)
        {
            var applicationService = CreateApplicationServices();
            var application = applicationService.GetApplicationsByCompanyName(CompanyName);
            return Ok(application);

        }
        [HttpPut]
        public IHttpActionResult UpdateApplication(ApplicationEdit model, int id)
        {
            var applicationService = CreateApplicationServices();
            var application = applicationService.UpdateApplication(model,id);
            return Ok("Update successfull");

        }
        public IHttpActionResult DeleteAplication(int id)
        {
            var applicationService = CreateApplicationServices();
            var application = applicationService.DeleteApplication( id);
            return Ok("Application Deleted Successfully");
        }
    }
}
