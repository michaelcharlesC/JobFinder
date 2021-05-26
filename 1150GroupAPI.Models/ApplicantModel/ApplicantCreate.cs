using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Models.ApplicationModel
{
    public class ApplicantCreate
    {
        [Required]
        [MinLength(2,ErrorMessage ="Please enter at least 2 characters")]
        public string ApplicantFirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        public string ApplicantLastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ApplicantEmail { get; set; }

    }
}
