using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Applicant))]
        public int ApplicantId { get; set; }
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public DateTimeOffset ApplicationDate { get; set; }
        //private bool _applicationSubmitted;
        //public bool ApplicationSubmitted
        //{
        //    get
        //    {
        //        return Job.JobPosition != null;
        //    }
        //}
        public Guid Ownerid { get; set; }
        public virtual Job Job { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}
