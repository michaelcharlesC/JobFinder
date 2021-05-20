using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class CompanyLocation
    {
        [Key, ForeignKey(nameof(CompanyProfile))]
        public int CompanyID { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }

        //[required]
        //public string locationname { get; set; }

        public string Address
        {
            get
            {
                return (Street + " " + City + "," + State + " " + Zip);
            }
        }

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
