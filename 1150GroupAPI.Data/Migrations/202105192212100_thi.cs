namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyLocation", "CompanyID", "dbo.CompanyProfile");
            DropIndex("dbo.CompanyLocation", new[] { "CompanyID" });
            DropPrimaryKey("dbo.CompanyLocation");
            AddColumn("dbo.CompanyLocation", "LocationId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CompanyLocation", "LocationId");
            CreateIndex("dbo.CompanyLocation", "LocationId");
            AddForeignKey("dbo.CompanyLocation", "LocationId", "dbo.CompanyProfile", "CompanyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyLocation", "LocationId", "dbo.CompanyProfile");
            DropIndex("dbo.CompanyLocation", new[] { "LocationId" });
            DropPrimaryKey("dbo.CompanyLocation");
            DropColumn("dbo.CompanyLocation", "LocationId");
            AddPrimaryKey("dbo.CompanyLocation", "CompanyID");
            CreateIndex("dbo.CompanyLocation", "CompanyID");
            AddForeignKey("dbo.CompanyLocation", "CompanyID", "dbo.CompanyProfile", "CompanyID");
        }
    }
}
