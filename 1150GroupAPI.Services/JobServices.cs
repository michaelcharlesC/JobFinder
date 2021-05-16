using _1150GroupAPI.Data;
using _1150GroupAPI.Models.JobsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Services
{
    public class JobServices
    {
        private readonly Guid _UserId;
        public JobServices(Guid userid)
        {
            _UserId = userid;
        }

        public bool CreateJob(JobCreate model)
        {
            var jobEntity = new Job()
            {
                OwnerId = _UserId,
                JobPosition = model.JobPosition,
                JobRequirement = model.JobRequirement,
                JobDescription = model.JobDescription,
                JobType = model.JobType,
                Salary = model.Salary,
                CompanyId=model.CompanyId

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(jobEntity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<JobListItem> GetAllJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Jobs
                                .Select(e => new JobListItem()
                                {
                                    JobId = e.JobId,
                                    JobPosition = e.JobPosition,
                                    JobType = e.JobType
                                });
                return query.ToList();
            }
        }
        public JobDetail GetJobByJobId(int jobid)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query = ctx
                                .Jobs
                                .SingleOrDefault(e => e.JobId == jobid);
                if (query is null)
                    return null;
                var jobdetail = new JobDetail()
                {
                    JobId = query.JobId,
                    JobPosition = query.JobPosition,
                    JobDescription = query.JobDescription,
                    JobRequirement = query.JobRequirement,
                    JobType = query.JobType,
                    Salary = query.Salary
                };
                return jobdetail;
            }
        }
        public IEnumerable<JobListItem> GetJobByZipCode(int zipcode)
        {
            using(var ctx =new ApplicationDbContext())
            {
                var query = ctx
                                .Jobs
                                .Where(e => e.CompanyProfile.CompanyLocation.Zip == zipcode)
                                .Select(e => new JobListItem()
                                {
                                    JobId = e.JobId,
                                    JobPosition = e.JobPosition,
                                    JobType = e.JobType
                                }).ToList();
                return query;
            }
            
        }
        public IEnumerable<JobListItem>GetJobByCompanyName(string companyname)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query =ctx
                                .Jobs
                                .Where(e=>e.CompanyProfile.CompanyName==companyname)
                                .Select(e => new JobListItem()
                                {
                                    JobId = e.JobId,
                                    JobPosition = e.JobPosition,
                                    JobType = e.JobType
                                }).ToList();
                return query;
            }
        }
        public IEnumerable<JobListItem>GetJobByCompanyNameAndSalary(double salary,string comapnyname,string joptype)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Jobs
                                .Where(e => e.CompanyProfile.CompanyName == comapnyname && e.Salary >= salary && e.JobType == joptype)
                                .Select(e => new JobListItem()
                                {
                                    JobId = e.JobId,
                                    JobPosition = e.JobPosition,
                                    JobType = e.JobType
                                }).ToList();
                return query;
            }
        }
        
        
    }
}
