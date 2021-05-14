using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class CompanyLocation
    {
        [ForeignKey(nameof(LocationID))]
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address
        {
            get
            {
                return (Street + " " + City + "," + State + " " + Zip);
            }
        }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }
    }
}
