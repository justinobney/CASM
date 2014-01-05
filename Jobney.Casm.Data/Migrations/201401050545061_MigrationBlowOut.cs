namespace Jobney.Casm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationBlowOut : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pilot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Airplane_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airplane", t => t.Airplane_Id)
                .Index(t => t.Airplane_Id);
            
            CreateTable(
                "dbo.Passenger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Waypoint",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(),
                        Airport = c.String(),
                        Fbo = c.String(),
                        Departing = c.DateTime(nullable: false),
                        Arriving = c.DateTime(),
                        Appointment = c.DateTime(nullable: false),
                        AppointmentLocation = c.String(),
                        Notes = c.String(),
                        Trip_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trip", t => t.Trip_Id)
                .Index(t => t.Trip_Id);
            
            CreateTable(
                "dbo.WaypointPassenger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WaypointId = c.Int(nullable: false),
                        PassengerId = c.Int(nullable: false),
                        PassengerType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passenger", t => t.PassengerId, cascadeDelete: true)
                .ForeignKey("dbo.Waypoint", t => t.WaypointId, cascadeDelete: true)
                .Index(t => t.PassengerId)
                .Index(t => t.WaypointId);
            
            CreateTable(
                "dbo.WaypointRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Responsible = c.String(),
                        Notes = c.String(),
                        Complete = c.Boolean(nullable: false),
                        Waypoint_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Waypoint", t => t.Waypoint_Id)
                .Index(t => t.Waypoint_Id);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AirplaneId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        RequestedBy = c.String(),
                        ScheduledBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airplane", t => t.AirplaneId, cascadeDelete: true)
                .Index(t => t.AirplaneId);
            
            CreateTable(
                "dbo.Airplane",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CallSign = c.String(),
                        Type = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TripPilot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TripId = c.Int(nullable: false),
                        PilotId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pilot", t => t.PilotId, cascadeDelete: true)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .Index(t => t.PilotId)
                .Index(t => t.TripId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Waypoint", "Trip_Id", "dbo.Trip");
            DropForeignKey("dbo.TripPilot", "TripId", "dbo.Trip");
            DropForeignKey("dbo.TripPilot", "PilotId", "dbo.Pilot");
            DropForeignKey("dbo.Trip", "AirplaneId", "dbo.Airplane");
            DropForeignKey("dbo.Pilot", "Airplane_Id", "dbo.Airplane");
            DropForeignKey("dbo.WaypointRequest", "Waypoint_Id", "dbo.Waypoint");
            DropForeignKey("dbo.WaypointPassenger", "WaypointId", "dbo.Waypoint");
            DropForeignKey("dbo.WaypointPassenger", "PassengerId", "dbo.Passenger");
            DropIndex("dbo.Waypoint", new[] { "Trip_Id" });
            DropIndex("dbo.TripPilot", new[] { "TripId" });
            DropIndex("dbo.TripPilot", new[] { "PilotId" });
            DropIndex("dbo.Trip", new[] { "AirplaneId" });
            DropIndex("dbo.Pilot", new[] { "Airplane_Id" });
            DropIndex("dbo.WaypointRequest", new[] { "Waypoint_Id" });
            DropIndex("dbo.WaypointPassenger", new[] { "WaypointId" });
            DropIndex("dbo.WaypointPassenger", new[] { "PassengerId" });
            DropTable("dbo.TripPilot");
            DropTable("dbo.Airplane");
            DropTable("dbo.Trip");
            DropTable("dbo.WaypointRequest");
            DropTable("dbo.WaypointPassenger");
            DropTable("dbo.Waypoint");
            DropTable("dbo.Passenger");
            DropTable("dbo.Pilot");
        }
    }
}
