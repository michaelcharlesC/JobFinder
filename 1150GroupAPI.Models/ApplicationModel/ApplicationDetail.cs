using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1150GroupAPI.Data;

namespace _1150GroupAPI.Models.ApplicationModel
{
    public class ApplicationDetail
    {
        public int ApplicationId { get; set; }
        [Display(Name = "Submitted on")]
        public DateTimeOffset ApplicationDate { get; set; }
        [Display(Name = "Applicant First Name")]
        public string ApplicantFirstName { get; set; }
        [Display(Name = "Applicant Last Name")]
        public string ApplicantLastName { get; set; }
        [Display(Name = "Applicant Email Address")]
        public string ApplicantEmail { get; set; }
        [Display(Name = "List of Applied Jobs")]
        public virtual ICollection<Job> ListOfJobs { get; set; }
    }
}
