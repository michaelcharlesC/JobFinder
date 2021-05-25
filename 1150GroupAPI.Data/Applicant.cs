using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }
        public Guid OwnerId { get; set; }
                
        [Required]
        public string  ApplicantFirstName { get; set; }
        [Required]
        public string ApplicantLastName { get; set; }
        public string AllicantFullName
        {
            get
            {
               return  ApplicantFirstName + " " + ApplicantLastName;
            }
        }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ApplicantEmail { get; set; }


    }
}
