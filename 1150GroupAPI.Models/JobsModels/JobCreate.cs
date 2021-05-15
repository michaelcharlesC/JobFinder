using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Models.JobsModels
{
    public class JobCreate
    {
        [Required]
        [Display(Name = "Job Position")]
        public string JobPosition { get; set; }
        [Required, MaxLength(50, ErrorMessage = "There are too many characters in this field")]
        public string JobDescription { get; set; }
        [Required]
        public string JobType { get; set; }
        [Required, MaxLength(200, ErrorMessage = "There are too many characters in this field")]
        public string JobRequirement { get; set; }
        public double? Salary { get; set; }
        
        
    }
}
