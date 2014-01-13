namespace Jobney.Casm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "Key", c => c.String(nullable: false));
            AddColumn("dbo.Settings", "Value", c => c.String(nullable: false));
            DropColumn("dbo.Settings", "City");
            DropColumn("dbo.Settings", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "State", c => c.String());
            AddColumn("dbo.Settings", "City", c => c.String());
            DropColumn("dbo.Settings", "Value");
            DropColumn("dbo.Settings", "Key");
        }
    }
}
