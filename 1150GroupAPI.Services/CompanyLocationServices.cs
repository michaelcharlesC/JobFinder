using _1150GroupAPI.Data;
using _1150GroupAPI.Models;
using _1150GroupAPI.Models.CompanyLocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data;

namespace _1150GroupAPI.Services
{
    public class CompanyLocationServices 
    {

        private Guid _userId;

        public CompanyLocationServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCompanyLocation(CompanyLocationCreate model)
        {
            var entity =
                new CompanyLocation()
                {
                    CompanyID = model.CompanyID,
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip,
                };
            
            var profile = (new CompanyProfileServices(_userId).GetCompanyByCompanyId(model.CompanyID));
            //profile.
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CompanyLocations.Add(entity);
                ctx.SaveChanges();
                DataTable table = new DataTable("Companies");
                foreach (DataRow dr in table.Rows) 
                {
                    if ((int)dr["CompanyID"] == model.CompanyID)
                    {
                        dr["CompanyLocation_ComapnyID"] = model.CompanyID;
                    } 
                }
                 ctx.SaveChanges();
                return true;
            }

        }

        public CompanyLocationDetail GetCompanyLocationById(int locationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CompanyLocations
                        .Single(e => e.CompanyID == locationID);
                return
                    new CompanyLocationDetail
                    {
                        CompanyID = entity.CompanyID,
                        Street = entity.Street,
                        City = entity.City,
                        State = entity.State,
                        Zip = entity.Zip
                    };
            }
        }

        public IEnumerable<CompanyLocationListItem> GetAllCompanyLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CompanyLocations
                        .Select(
                        e =>
                        new CompanyLocationListItem
                        {
                            CompanyID = e.CompanyID,
                            City = e.City,
                            State = e.State
                        });
                return query.ToArray();
            }
        }

        public bool UpdateCompanyLocation(CompanyLocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CompanyLocations
                        .Single(e => e.CompanyID == model.CompanyID);
                entity.Street = model.Street;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zip = model.Zip;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCompanyLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CompanyLocations
                        .Single(e => e.CompanyID == locationId);

                ctx.CompanyLocations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
