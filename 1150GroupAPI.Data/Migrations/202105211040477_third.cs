namespace _1150GroupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicant", "ApplicationSubmitted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Applicant", "WasSubmitted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicant", "WasSubmitted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Applicant", "ApplicationSubmitted");
        }
    }
}
