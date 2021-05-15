using _1150GroupAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Services
{
    public class CompanyLocationServices
    {
        public bool CreateCompanyLocation(CompanyLocation model)
        {
            var entity =
                new CompanyLocation()
                {
                    LocationID = model.CompanyProfileID.CompanyID,
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CompanyLocations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
