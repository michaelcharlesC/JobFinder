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
                OwnerId=_UserId,
                JobPosition = model.JobPosition,
                JobRequirement = model.JobRequirement,
                JobDescription = model.JobDescription,
                JobType = model.JobType,
                Salary = model.Salary

            };

            using(var ctx=new ApplicationDbContext())
            {
                ctx.Jobs.Add(jobEntity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
