namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secc : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CompanyLocation", name: "CompanyLocationId", newName: "CompanyID");
            RenameIndex(table: "dbo.CompanyLocation", name: "IX_CompanyLocationId", newName: "IX_CompanyID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CompanyLocation", name: "IX_CompanyID", newName: "IX_CompanyLocationId");
            RenameColumn(table: "dbo.CompanyLocation", name: "CompanyID", newName: "CompanyLocationId");
        }
    }
}
