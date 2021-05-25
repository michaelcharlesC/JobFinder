namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ex : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyProfile", "CategoryID", "dbo.Category");
            DropIndex("dbo.CompanyProfile", new[] { "CategoryID" });
            AddColumn("dbo.Applicant", "ApplicationSubmitted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CompanyProfile", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.CompanyProfile", "CategoryID");
            AddForeignKey("dbo.CompanyProfile", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
            DropColumn("dbo.Applicant", "WasSubmitted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicant", "WasSubmitted", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.CompanyProfile", "CategoryID", "dbo.Category");
            DropIndex("dbo.CompanyProfile", new[] { "CategoryID" });
            AlterColumn("dbo.CompanyProfile", "CategoryID", c => c.Int());
            DropColumn("dbo.Applicant", "ApplicationSubmitted");
            CreateIndex("dbo.CompanyProfile", "CategoryID");
            AddForeignKey("dbo.CompanyProfile", "CategoryID", "dbo.Category", "CategoryID");
        }
    }
}
