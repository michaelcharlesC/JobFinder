namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyProfile", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.CompanyProfile", "LocationID", "dbo.CompanyLocation");
            DropIndex("dbo.CompanyProfile", new[] { "LocationID" });
            DropIndex("dbo.CompanyProfile", new[] { "CategoryID" });
            DropPrimaryKey("dbo.CompanyLocation");
            AlterColumn("dbo.CompanyProfile", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.CompanyLocation", "LocationID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CompanyLocation", "LocationID");
            CreateIndex("dbo.CompanyProfile", "CategoryID");
            CreateIndex("dbo.CompanyLocation", "LocationID");
            AddForeignKey("dbo.CompanyProfile", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
            DropColumn("dbo.CompanyProfile", "LocationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyProfile", "LocationID", c => c.Int());
            DropForeignKey("dbo.CompanyProfile", "CategoryID", "dbo.Category");
            DropIndex("dbo.CompanyLocation", new[] { "LocationID" });
            DropIndex("dbo.CompanyProfile", new[] { "CategoryID" });
            DropPrimaryKey("dbo.CompanyLocation");
            AlterColumn("dbo.CompanyLocation", "LocationID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CompanyProfile", "CategoryID", c => c.Int());
            AddPrimaryKey("dbo.CompanyLocation", "LocationID");
            CreateIndex("dbo.CompanyProfile", "CategoryID");
            CreateIndex("dbo.CompanyProfile", "LocationID");
            AddForeignKey("dbo.CompanyProfile", "LocationID", "dbo.CompanyLocation", "LocationID");
            AddForeignKey("dbo.CompanyProfile", "CategoryID", "dbo.Category", "CategoryID");
        }
    }
}
