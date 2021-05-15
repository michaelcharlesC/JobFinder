namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class example : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        WasSubmitted = c.Boolean(nullable: false),
                        ApplicantFirstName = c.String(nullable: false),
                        ApplicantLastName = c.String(nullable: false),
                        ApplicantEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        JobDescription = c.String(),
                        JobType = c.String(),
                        JobRequirement = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.CompanyProfile", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.CompanyProfile",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        LocationID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.CompanyLocation", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.CompanyLocation",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.JobApplication",
                c => new
                    {
                        Job_JobId = c.Int(nullable: false),
                        Application_ApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_JobId, t.Application_ApplicationId })
                .ForeignKey("dbo.Job", t => t.Job_JobId, cascadeDelete: true)
                .ForeignKey("dbo.Application", t => t.Application_ApplicationId, cascadeDelete: true)
                .Index(t => t.Job_JobId)
                .Index(t => t.Application_ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Job", "CompanyID", "dbo.CompanyProfile");
            DropForeignKey("dbo.CompanyProfile", "LocationID", "dbo.CompanyLocation");
            DropForeignKey("dbo.CompanyProfile", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.JobApplication", "Application_ApplicationId", "dbo.Application");
            DropForeignKey("dbo.JobApplication", "Job_JobId", "dbo.Job");
            DropIndex("dbo.JobApplication", new[] { "Application_ApplicationId" });
            DropIndex("dbo.JobApplication", new[] { "Job_JobId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CompanyProfile", new[] { "CategoryID" });
            DropIndex("dbo.CompanyProfile", new[] { "LocationID" });
            DropIndex("dbo.Job", new[] { "CompanyID" });
            DropTable("dbo.JobApplication");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.CompanyLocation");
            DropTable("dbo.Category");
            DropTable("dbo.CompanyProfile");
            DropTable("dbo.Job");
            DropTable("dbo.Application");
        }
    }
}
