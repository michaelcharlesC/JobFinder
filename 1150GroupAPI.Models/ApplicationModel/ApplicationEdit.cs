using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Models.ApplicationModel
{
    public class ApplicationEdit
    {
        [Required]
        [Display(Name = "Applicant ID")]
        public int ApplicationId { get; set; }
        [Display(Name = "Applicant First Name")]
        public string ApplicantFirstName { get; set; }
        [Display(Name = "Applicant Last Name")]
        public string ApplicantLastName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Applicant Email Address")]
        public string ApplicantEmail { get; set; }
    }
}
