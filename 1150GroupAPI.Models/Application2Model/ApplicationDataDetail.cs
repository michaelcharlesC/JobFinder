using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Models.Application2Model
{
    public class ApplicationDataDetail
    {
        public int Id { get; set; }
        public DateTimeOffset ApplicationDate { get; set; }
        public string JobPosition { get; set; }
        public string CompanyName { get; set; }
        public string ApplicantName { get; set; }
        
    }
}
