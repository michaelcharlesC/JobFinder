﻿using _1150GroupAPI.Data;
using _1150GroupAPI.Models.CompanyLocationModels;
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

        public CompanyLocationDetail GetCompanyLocationById(int locationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CompanyLocations
                        .Single(e => e.LocationID == locationID);
                return
                    new CompanyLocationDetail
                    {
                        LocationID = entity.LocationID,
                        Street = entity.Street,
                        City = entity.City,
                        State = entity.State,
                        Zip = entity.Zip
                    };
            }
        }

        public bool UpdateCompanyLocation(CompanyLocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CompanyLocations
                        .Single(e => e.LocationID == model.LocationID);

                entity.LocationID = model.LocationID;

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
                        .Single(e => e.LocationID == locationId);

                ctx.CompanyLocations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}