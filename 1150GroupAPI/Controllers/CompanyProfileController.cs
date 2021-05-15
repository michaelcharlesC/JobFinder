using _1150GroupAPI.Models;
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
    public class CompanyProfileController : ApiController
    {
        private CompanyProfileServices CreateCompanyProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var companyService = new CompanyProfileServices(userId);
            return companyService;
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            CompanyProfileServices companyService = CreateCompanyProfileService();
            var companies = companyService.GetCompanyByCompanyId(id);
            return Ok(companies);
        }
        [HttpPost]
        public IHttpActionResult Post(CompanyProfileCreate company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCompanyProfileService();

            if (!service.CreateCompany(company))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(CompanyProfileEdit company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCompanyProfileService();

            if (!service.UpdateCompany(company))
                return InternalServerError();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCompanyProfileService();

            if (!service.DeleteCompanyProfile(id))
                return InternalServerError();

            return Ok();
        }
    }
}
