using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class CompanyProfile
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public virtual CompanyLocation CompanyLocation { get; set; }

        public ICollection<Job> ListOfJobs { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public CompanyProfile()
        {
            ListOfJobs = new HashSet<Job>();
        }

    }
}
