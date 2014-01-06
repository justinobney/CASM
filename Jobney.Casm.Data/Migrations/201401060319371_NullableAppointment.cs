namespace Jobney.Casm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableAppointment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Waypoint", "Appointment", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Waypoint", "Appointment", c => c.DateTime(nullable: false));
        }
    }
}
