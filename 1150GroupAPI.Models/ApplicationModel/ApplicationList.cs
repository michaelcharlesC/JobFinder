using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1150GroupAPI.Data;

namespace _1150GroupAPI.Models.ApplicationModel
{
    public class ApplicationList
    {
        public string ApplicantFirstName { get; set; }
        public string ApplicantLastName { get; set; }
        public string ApplicantEmail { get; set; }
        public virtual ICollection<Job> ListOfJobs { get; set; }
    }
}
