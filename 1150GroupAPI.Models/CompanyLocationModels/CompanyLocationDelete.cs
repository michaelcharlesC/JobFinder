using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Models.CompanyLocationModels
{
    public class CompanyLocationDelete
    {
        public string CompanyProfileID { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int Zip { get; set; }
    }
}
