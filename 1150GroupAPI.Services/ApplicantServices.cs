﻿using System;
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
            var entity = new Applicant()
            {
                OwnerId = _userId,
                ApplicantFirstName = model.ApplicantFirstName,
                ApplicantEmail = model.ApplicantEmail,
                ApplicantLastName = model.ApplicantLastName,
               

            };

            using (var ctx = new ApplicationDbContext())
            {
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
                var query = ctx.Applicants.Single(e => e.ApplicantId == id && e.OwnerId == _userId);

                return new ApplicantDataDetail
                {
                    ApplicantId = query.ApplicantId,
                    ApplicantFirstName = query.ApplicantFirstName,
                    ApplicantLastName = query.ApplicantLastName,
                    ApplicantEmail = query.ApplicantEmail,
                    
                };



            }
        }

        public ApplicantDataDetail GetApplicationsByJobId(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var queryJob = ctx.Jobs.FirstOrDefault(e => e.JobId == jobId && e.OwnerId == _userId);


                return new ApplicantDataDetail
                {
                    ApplicantId = queryJob.JobId,
                    //ApplicantDate = queryJob.CreatedUtc
                };

            }
        }

        public bool UpdateApplicant(ApplicantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Applicants.Single(e => e.ApplicantId == model.ApplicantId && e.OwnerId == _userId);
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
                var entity = ctx.Applicants.Single(e => e.ApplicantId == applicationId && e.OwnerId == _userId);
                ctx.Applicants.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        
    }
}