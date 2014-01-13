namespace Jobney.Casm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airplane",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CallSign = c.String(nullable: false),
                        Type = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Trip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RequestedBy = c.String(),
                        ScheduledBy = c.String(),
                        StatusId = c.Int(nullable: false),
                        AirplaneId = c.Int(nullable: false),
                        Passenger_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passenger", t => t.Passenger_Id)
                .ForeignKey("dbo.TripStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Airplane", t => t.AirplaneId, cascadeDelete: true)
                .Index(t => t.Passenger_Id)
                .Index(t => t.StatusId)
                .Index(t => t.AirplaneId);
            
            CreateTable(
                "dbo.WaypointPassenger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TripId = c.Int(nullable: false),
                        PassengerId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Waypoint_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passenger", t => t.PassengerId, cascadeDelete: true)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .ForeignKey("dbo.Waypoint", t => t.Waypoint_Id)
                .Index(t => t.PassengerId)
                .Index(t => t.TripId)
                .Index(t => t.Waypoint_Id);
            
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
                "dbo.TripStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                        Departing = c.DateTime(),
                        Arriving = c.DateTime(),
                        Appointment = c.DateTime(),
                        AppointmentLocation = c.String(),
                        Notes = c.String(),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.WaypointRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Responsible = c.String(),
                        Notes = c.String(),
                        Complete = c.Boolean(nullable: false),
                        TypeId = c.Int(nullable: false),
                        WaypointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WaypointRequestType", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Waypoint", t => t.WaypointId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.WaypointId);
            
            CreateTable(
                "dbo.WaypointRequestType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PilotTrip",
                c => new
                    {
                        Pilot_Id = c.Int(nullable: false),
                        Trip_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pilot_Id, t.Trip_Id })
                .ForeignKey("dbo.Pilot", t => t.Pilot_Id, cascadeDelete: true)
                .ForeignKey("dbo.Trip", t => t.Trip_Id, cascadeDelete: true)
                .Index(t => t.Pilot_Id)
                .Index(t => t.Trip_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trip", "AirplaneId", "dbo.Airplane");
            DropForeignKey("dbo.Pilot", "Airplane_Id", "dbo.Airplane");
            DropForeignKey("dbo.PilotTrip", "Trip_Id", "dbo.Trip");
            DropForeignKey("dbo.PilotTrip", "Pilot_Id", "dbo.Pilot");
            DropForeignKey("dbo.Waypoint", "TripId", "dbo.Trip");
            DropForeignKey("dbo.WaypointRequest", "WaypointId", "dbo.Waypoint");
            DropForeignKey("dbo.WaypointRequest", "TypeId", "dbo.WaypointRequestType");
            DropForeignKey("dbo.WaypointPassenger", "Waypoint_Id", "dbo.Waypoint");
            DropForeignKey("dbo.Trip", "StatusId", "dbo.TripStatus");
            DropForeignKey("dbo.WaypointPassenger", "TripId", "dbo.Trip");
            DropForeignKey("dbo.WaypointPassenger", "PassengerId", "dbo.Passenger");
            DropForeignKey("dbo.Trip", "Passenger_Id", "dbo.Passenger");
            DropIndex("dbo.Trip", new[] { "AirplaneId" });
            DropIndex("dbo.Pilot", new[] { "Airplane_Id" });
            DropIndex("dbo.PilotTrip", new[] { "Trip_Id" });
            DropIndex("dbo.PilotTrip", new[] { "Pilot_Id" });
            DropIndex("dbo.Waypoint", new[] { "TripId" });
            DropIndex("dbo.WaypointRequest", new[] { "WaypointId" });
            DropIndex("dbo.WaypointRequest", new[] { "TypeId" });
            DropIndex("dbo.WaypointPassenger", new[] { "Waypoint_Id" });
            DropIndex("dbo.Trip", new[] { "StatusId" });
            DropIndex("dbo.WaypointPassenger", new[] { "TripId" });
            DropIndex("dbo.WaypointPassenger", new[] { "PassengerId" });
            DropIndex("dbo.Trip", new[] { "Passenger_Id" });
            DropTable("dbo.PilotTrip");
            DropTable("dbo.WaypointRequestType");
            DropTable("dbo.WaypointRequest");
            DropTable("dbo.Waypoint");
            DropTable("dbo.TripStatus");
            DropTable("dbo.Passenger");
            DropTable("dbo.WaypointPassenger");
            DropTable("dbo.Trip");
            DropTable("dbo.Pilot");
            DropTable("dbo.Airplane");
        }
    }
}
