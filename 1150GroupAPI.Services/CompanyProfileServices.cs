using _1150GroupAPI.Data;
using _1150GroupAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Services
{
    public class CompanyProfileServices
    {
        private Guid _userID;
        public CompanyProfileServices(Guid userid)
        {
            _userID = userid;
        }
        public bool CreateCompany(CompanyProfileCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var companyentity = new CompanyProfile();
                companyentity.CompanyID = model.CompanyID;
                companyentity.CompanyName = model.CompanyName;

                ctx.Companies.Add(companyentity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
