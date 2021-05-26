using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1150GroupAPI.Data;

namespace _1150GroupAPI.Models.ApplicantModel
{
    public class ApplicantList
    {
        [Display(Name = "Applicant First Name")]
        public string ApplicantFirstName { get; set; }
        [Display(Name = "Applicant Last Name")]
        public string ApplicantLastName { get; set; }
        [Display(Name = "Applicant Email Address")]
        public string ApplicantEmail { get; set; }
        
    }
}
