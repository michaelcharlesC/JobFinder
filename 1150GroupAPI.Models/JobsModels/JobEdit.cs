using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Models.JobsModels
{
    public class JobEdit
    {
        public string JobPosition { get; set; }
        public string JobDescription { get; set; }
        public string JobType { get; set; }
        public string JobRequirement { get; set; }
        public double? Salary { get; set; }
    }
}
