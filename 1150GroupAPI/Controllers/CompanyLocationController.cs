using _1150GroupAPI.Models;
using _1150GroupAPI.Models.CompanyLocationModels;
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
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationServices CreateCompanyLocationService()
        {
            Guid userid = Guid.Parse(User.Identity.GetUserId());
            var companyLocationService = new CompanyLocationServices();
            return companyLocationService;
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            CompanyLocationServices companyLocationServices = CreateCompanyLocationService();
            var companies = companyLocationServices.GetCompanyLocationById(id);
            return Ok(companies);
        }
        [HttpPost]
        public IHttpActionResult Post(CompanyLocationCreate companyLocation )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCompanyLocationService();

            if (!service.CreateCompanyLocation(companyLocation))
                return InternalServerError();

            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(CompanyLocationEdit company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCompanyLocationService();

            if (!service.UpdateCompanyLocation(company))
                return InternalServerError();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCompanyLocationService();

            if (!service.DeleteCompanyLocation(id))
                return InternalServerError();

            return Ok();
        }
    }
}
