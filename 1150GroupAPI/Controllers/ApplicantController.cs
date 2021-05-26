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
        private ApplicantServices CreateAplicationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ApplicantService = new ApplicantServices(userId);
            return ApplicantService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            ApplicantServices ApplicantService = CreateAplicationService();
            var Applicant = ApplicantService.GetAllApplicants();
            return Ok(Applicant);
        }
        [HttpPost]
        public IHttpActionResult Post(ApplicantCreate Applicant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAplicationService();

            if (!service.CreateApplicant(Applicant))
                return InternalServerError();

            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ApplicantServices ApplicantService = CreateAplicationService();
            var Applicant = ApplicantService.GetApplicantsById(id);
            return Ok(Applicant);
        }
       
        [HttpPut]
        public IHttpActionResult Put(ApplicantEdit Applicant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAplicationService();

            if (!service.UpdateApplicant(Applicant))
                return InternalServerError();

            return Ok();


        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAplicationService();

            if (!service.DeleteApplicant(id))
                return InternalServerError();

            return Ok();
        }
    }
}
