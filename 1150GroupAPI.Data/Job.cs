using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobType { get; set; }
        public string JobRequirement { get; set; }
        public decimal Salary { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ICollection<Application> Applications { get; set; }
        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual CompanyProfile CompanyProfile { get; set; }
    }
}
