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
        [ForeignKey(nameof(Address))]
        public string Address { get; set; }
        public virtual CompanyLocation CompanyAddress { get; set; }
        public ICollection<Job> ListOfJobs { get; set; }
        [ForeignKey(nameof(Category))]
        public virtual Category Category { get; set; }

    }
}
