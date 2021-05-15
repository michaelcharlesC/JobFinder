using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [ForeignKey (nameof(CompanyProfile))]
        public int CompanyId { get; set; }
        [Required]
        [Display(Name ="Job Position")]
        public string JobPosition { get; set; }
        [Required, MaxLength(50, ErrorMessage ="There are too many characters in this field")]
        public string JobDescription { get; set; }
        [Required]
        public string JobType { get; set; }
        [Required, MaxLength(200, ErrorMessage = "There are too many characters in this field")]
        public string JobRequirement { get; set; }
        public double? Salary { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid OwnerId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }       // One to many relationship with CompanyProfile
        public virtual List<Application> Applications { get; set; }      //Many to Manay relationship with Application
    }
}
