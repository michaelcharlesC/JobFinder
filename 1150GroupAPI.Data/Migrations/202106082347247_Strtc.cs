namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Strtc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applicant", "Job_JobId", "dbo.Job");
            DropIndex("dbo.Applicant", new[] { "Job_JobId" });
            AddColumn("dbo.CompanyProfile", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Applicant", "Job_JobId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicant", "Job_JobId", c => c.Int());
            DropColumn("dbo.CompanyProfile", "OwnerId");
            CreateIndex("dbo.Applicant", "Job_JobId");
            AddForeignKey("dbo.Applicant", "Job_JobId", "dbo.Job", "JobId");
        }
    }
}
