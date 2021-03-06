using _1150GroupAPI.Data;
using _1150GroupAPI.Models.Application2Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Services
{
    public class ApplicationServices
    {
        private Guid _userId;

        public ApplicationServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateApplication(ApplicationCreate model)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var job = ctx.Jobs.Find(model.JobId);
                if (job is null)
                    return false;
                var applicant = ctx.Applicants.Find(model.ApplicantId);
                if (applicant is null)
                    return false;
                if (applicant.OwnerId != _userId)
                    return false;
                var job1 = ctx
                                .Applications
                                .SingleOrDefault(e => e.Id != 0 && (e.ApplicantId == model.ApplicantId && e.JobId == model.JobId));// Ensuring that there is no duplicate application for the same job by the same applicant
                if (job1 != null)
                    return false;
                var entity = new Application()
                {

                    ApplicantId = model.ApplicantId,
                    JobId = model.JobId,
                    Ownerid = _userId,
                    ApplicationDate = DateTimeOffset.Now.Date

                };
                ctx.Applications.Add(entity);
                return ctx.SaveChanges() == 1;
            }
            
        }
        public IEnumerable<ApplicationListItem> GetAllApplication()
        {
            using(var  ctx=new ApplicationDbContext())
            {
                var query = ctx
                               .Applications
                               .Where(e=>e.Job.OwnerId==_userId||e.Ownerid==_userId) //getting Applications by either the jobs administrator that posted the job or the the applicant
                               .Select(e => new ApplicationListItem()
                               {
                                   ApplicationId = e.Id,
                                   ApplicantName = e.Applicant.ApplicantFirstName,
                                   CompanyName = e.Job.CompanyProfile.CompanyName,
                                   JobName = e.Job.JobPosition
                               }).ToList();
                return query;
            }
        }
        public ApplicationDataDetail GetApplicationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Applications
                                .SingleOrDefault(e=>e.Id==id&& (e.Job.OwnerId==_userId||e.Ownerid==_userId));//getting application a single by  the applicant or the job admin
                if (query is null)
                    return null;
                return new ApplicationDataDetail()
                {
                    Id = query.Id,
                    ApplicantName = query.Applicant.ApplicantFirstName,
                    CompanyName = query.Job.CompanyProfile.CompanyName,
                    ApplicationDate = query.ApplicationDate,
                    JobPosition = query.Job.JobPosition
                };
            }
        }
        public IEnumerable<ApplicationListItem> GetApplicationsByCompanyName(string CompanyName)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query = ctx
                                .Applications
                                .Where(e => e.Job.CompanyProfile.CompanyName == CompanyName&&(e.Job.OwnerId==_userId||e.Ownerid==_userId))//Ensuring only job admin and the user can search for submitted application
                                .Select(e => new ApplicationListItem()
                                {

                                    ApplicationId = e.Id,
                                    ApplicantName = e.Applicant.ApplicantFirstName,
                                    CompanyName = e.Job.CompanyProfile.CompanyName,
                                    JobName = e.Job.JobPosition
                                }).ToList();
                return query;
            }
        }
        public bool UpdateApplication(ApplicationEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Applications
                                .SingleOrDefault(e=>e.Id==id && e.Ownerid==_userId);
                if (query is null)
                    return false;
                if (query.Id != id)
                    return false;
                query.JobId = model.JobId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteApplication(int id)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query = ctx
                               .Applications
                               .SingleOrDefault(e=>e.Ownerid==_userId);
                if (query is null)
                    return false;
                ctx.Applications.Remove(query);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
