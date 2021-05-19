using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Models
{
    public class CompanyProfileListItem
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int? LocationID { get; set; }
        public int? CategoryID { get; set; }
    }
}
