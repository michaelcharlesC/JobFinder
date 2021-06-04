using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using static _1150GroupAPI.Data.ApplicationDbContext;

namespace _1150GroupAPI.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
        {
            public IdentityUserLoginConfiguration()
            {
                HasKey(iul => iul.UserId);
            }
        }
        public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
        {
            public IdentityUserRoleConfiguration()
            {
                HasKey(iur => iur.UserId);
            }
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<CompanyProfile> Companies { get; set; }
        public DbSet<CompanyLocation> CompanyLocations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

            /*   modelBuilder.Entity<CompanyLocation>()
              //.HasKey(s => s.CompanyID)
              .HasRequired(s => s.CompanyProfile)
              .WithRequiredDependent()
              .WillCascadeOnDelete(true);*/





            modelBuilder.Entity<CompanyProfile>()
            .HasOptional(p => p.CompanyLocation)// can create a company profile without having a company location.
            .WithRequired(c => c.CompanyProfile)
            .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyLocation>()
                .HasKey(cl => cl.CompanyID);
            //.WithRequired(s => s.);
        }
    }
}