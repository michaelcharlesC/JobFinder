using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1150GroupAPI.Models.ApplicationModel;
using _1150GroupAPI.Data;

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
            var entity = new Application()
            {
                ApplicantFirstName = model.ApplicantFirstName,
                ApplicantEmail = model.ApplicantEmail,
                ApplicantLastName = model.ApplicantLastName,
               

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Applications.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ApplicationList> GetAllApplications()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Applications.Where(e => e.OwnerId == _userId)
                    .Select(e => new ApplicationList
                    {
                        ApplicantEmail = e.ApplicantEmail,
                        ApplicantFirstName = e.ApplicantFirstName,
                        ApplicantLastName = e.ApplicantLastName,
                    });

                return query.ToList();
            }
        }

        public ApplicationDetail GetAplicationById(int id)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var query = ctx.Applications.Single(e => e.ApplicationId == id && e.OwnerId == _userId);

                return new ApplicationDetail
                {
                    ApplicationId = query.ApplicationId,
                    ApplicantFirstName = query.ApplicantFirstName,
                    ApplicantLastName = query.ApplicantLastName,
                    ApplicantEmail = query.ApplicantEmail,
                    ApplicationDate = query.ApplicationDate
                };



            }
        }

        public ApplicationDetail GetApplicationsByJobId(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queryJob = ctx.Jobs.FirstOrDefault(e => e.JobId == jobId && e.OwnerId == _userId);


                return new ApplicationDetail
                {
                    ApplicationId = queryJob.JobId,
                    ApplicationDate = queryJob.CreatedUtc
                };

            }
        }

        public bool UpdateApplication(ApplicationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Applications.Single(e => e.ApplicationId == model.ApplicationId && e.OwnerId == _userId);
                entity.ApplicantFirstName = model.ApplicantFirstName;
                entity.ApplicantLastName = model.ApplicantLastName;
                entity.ApplicantEmail = model.ApplicantEmail;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteApplication(int applicationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Applications.Single(e => e.ApplicationId == applicationId && e.OwnerId == _userId);
                ctx.Applications.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        
    }
}
