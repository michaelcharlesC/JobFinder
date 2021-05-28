namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyLocation", "CompanyID", "dbo.CompanyProfile");
            AddColumn("dbo.CompanyProfile", "CompanyLocation_CompanyID", c => c.Int());
            CreateIndex("dbo.CompanyProfile", "CompanyLocation_CompanyID");
            AddForeignKey("dbo.CompanyProfile", "CompanyLocation_CompanyID", "dbo.CompanyLocation", "CompanyID");
            AddForeignKey("dbo.CompanyLocation", "CompanyID", "dbo.CompanyProfile", "CompanyID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyLocation", "CompanyID", "dbo.CompanyProfile");
            DropForeignKey("dbo.CompanyProfile", "CompanyLocation_CompanyID", "dbo.CompanyLocation");
            DropIndex("dbo.CompanyProfile", new[] { "CompanyLocation_CompanyID" });
            DropColumn("dbo.CompanyProfile", "CompanyLocation_CompanyID");
            AddForeignKey("dbo.CompanyLocation", "CompanyID", "dbo.CompanyProfile", "CompanyID");
        }
    }
}
