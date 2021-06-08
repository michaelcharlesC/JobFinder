using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1150GroupAPI.Data;
using _1150GroupAPI.Models.ApplicationModel;

namespace _1150GroupAPI.Services
{
    public class ApplicantServices
    {
        private Guid _userId;

        public ApplicantServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateApplicant(ApplicantCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var applicant = ctx.Applicants.SingleOrDefault(e => e.OwnerId == _userId);
                if (applicant != null)
                    return false;
                var entity = new Applicant()
                {
                    OwnerId = _userId,
                    ApplicantFirstName = model.ApplicantFirstName,
                    ApplicantEmail = model.ApplicantEmail,
                    ApplicantLastName = model.ApplicantLastName,


                };

                ctx.Applicants.Add(entity);
                return ctx.SaveChanges() == 1;


            }

           
        }

        public IEnumerable<ApplicantListItem> GetAllApplicant()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Applicants.Where(e => e.OwnerId == _userId)
                    .Select(e => new ApplicantListItem
                    {
                        ApplicantEmail = e.ApplicantEmail,
                        ApplicantFirstName = e.ApplicantFirstName,
                        ApplicantLastName = e.ApplicantLastName,
                    });

                return query.ToArray();
            }
        }

        public ApplicantDataDetail GetApplicantById(int id)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var query = ctx.Applicants.SingleOrDefault(e => e.ApplicantId == id && e.OwnerId == _userId);
                if (query is null)
                    return null;

                return new ApplicantDataDetail
                {
                    ApplicantId = query.ApplicantId,
                    ApplicantFirstName = query.ApplicantFirstName,
                    ApplicantLastName = query.ApplicantLastName,
                    ApplicantEmail = query.ApplicantEmail,
                    
                };



            }
        }

        public bool UpdateApplicant(ApplicantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Applicants.SingleOrDefault(e => e.ApplicantId == model.ApplicantId && e.OwnerId == _userId);
                if (entity is null)
                    return false;
                entity.ApplicantFirstName = model.ApplicantFirstName;
                entity.ApplicantLastName = model.ApplicantLastName;
                entity.ApplicantEmail = model.ApplicantEmail;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteApplicant(int applicationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Applicants.SingleOrDefault(e => e.ApplicantId == applicationId && e.OwnerId == _userId);
                if (entity is null)
                    return false;
                ctx.Applicants.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        
    }
}
