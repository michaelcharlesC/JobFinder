namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _71 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobApplicant", "Job_JobId", "dbo.Job");
            DropForeignKey("dbo.JobApplicant", "Applicant_ApplicantId", "dbo.Applicant");
            DropIndex("dbo.JobApplicant", new[] { "Job_JobId" });
            DropIndex("dbo.JobApplicant", new[] { "Applicant_ApplicantId" });
            AddColumn("dbo.Applicant", "Job_JobId", c => c.Int());
            CreateIndex("dbo.Applicant", "Job_JobId");
            AddForeignKey("dbo.Applicant", "Job_JobId", "dbo.Job", "JobId");
            DropTable("dbo.JobApplicant");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobApplicant",
                c => new
                    {
                        Job_JobId = c.Int(nullable: false),
                        Applicant_ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_JobId, t.Applicant_ApplicantId });
            
            DropForeignKey("dbo.Applicant", "Job_JobId", "dbo.Job");
            DropIndex("dbo.Applicant", new[] { "Job_JobId" });
            DropColumn("dbo.Applicant", "Job_JobId");
            CreateIndex("dbo.JobApplicant", "Applicant_ApplicantId");
            CreateIndex("dbo.JobApplicant", "Job_JobId");
            AddForeignKey("dbo.JobApplicant", "Applicant_ApplicantId", "dbo.Applicant", "ApplicantId", cascadeDelete: true);
            AddForeignKey("dbo.JobApplicant", "Job_JobId", "dbo.Job", "JobId", cascadeDelete: true);
        }
    }
}
