namespace Jobney.Casm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTripId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Waypoint", "Trip_Id", "dbo.Trip");
            DropIndex("dbo.Waypoint", new[] { "Trip_Id" });
            RenameColumn(table: "dbo.Waypoint", name: "Trip_Id", newName: "TripId");
            AlterColumn("dbo.Waypoint", "TripId", c => c.Int(nullable: false));
            CreateIndex("dbo.Waypoint", "TripId");
            AddForeignKey("dbo.Waypoint", "TripId", "dbo.Trip", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Waypoint", "TripId", "dbo.Trip");
            DropIndex("dbo.Waypoint", new[] { "TripId" });
            AlterColumn("dbo.Waypoint", "TripId", c => c.Int());
            RenameColumn(table: "dbo.Waypoint", name: "TripId", newName: "Trip_Id");
            CreateIndex("dbo.Waypoint", "Trip_Id");
            AddForeignKey("dbo.Waypoint", "Trip_Id", "dbo.Trip", "Id");
        }
    }
}
