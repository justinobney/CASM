namespace Jobney.Casm.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPropertiesUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Email");
        }
    }
}
