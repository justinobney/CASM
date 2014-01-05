namespace Jobney.Casm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WaypointDepartingNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Waypoint", "Departing", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Waypoint", "Departing", c => c.DateTime(nullable: false));
        }
    }
}
