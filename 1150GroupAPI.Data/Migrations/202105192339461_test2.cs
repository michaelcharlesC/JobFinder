namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CompanyLocation", "CompanyID");
            RenameColumn(table: "dbo.CompanyLocation", name: "LocationId", newName: "CompanyID");
            RenameIndex(table: "dbo.CompanyLocation", name: "IX_LocationId", newName: "IX_CompanyID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CompanyLocation", name: "IX_CompanyID", newName: "IX_LocationId");
            RenameColumn(table: "dbo.CompanyLocation", name: "CompanyID", newName: "LocationId");
            AddColumn("dbo.CompanyLocation", "CompanyID", c => c.Int(nullable: false));
        }
    }
}
