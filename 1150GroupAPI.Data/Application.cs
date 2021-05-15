using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        public DateTime ApplicationDate
        {
            get
            {
                return DateTime.Now;
            }
        }
        [Required]
        public bool WasSubmitted { get; set; }
        [Required]
        public string  ApplicantFirstName { get; set; }
        [Required]
        public string ApplicantLastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ApplicantEmail { get; set; }
        [Required]
        public virtual ICollection<Job> ListOfJobs { get; set; }

        public Application()
        {
            ListOfJobs = new HashSet<Job>();
        }

    }
}
