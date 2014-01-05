using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Jobney.Casm.Domain;

namespace Jobney.Casm.Data.Migrations.SeedData
{
    public class TripSeed
    {
        public void Seed(DataContext context)
        {
            var waypoints = GetWaypoints(context);
            var thisTrip = new Trip
            {
                AirplaneId = context.Set<Airplane>().FirstOrDefault().Id,
                Name = "Justin's Fancy Trip",
                ScheduledBy = "Justin Obney",
                Waypoints = waypoints
            };
            context.Set<Trip>().AddOrUpdate(trip => trip.Name, thisTrip);
            context.SaveChanges();
        }

        private static List<Waypoint> GetWaypoints(DataContext context)
        {
            var wp1 = new Waypoint
            {
                Arriving = null,
                Airport = "KBTR",
                Appointment = DateTime.Now.AddDays(1),
                AppointmentLocation = "Go to the bar",
                City = "Baton Rouge",
                State = "LA",
                Zip = "70817",
                Fbo = "Willie's FBO",
                Notes = "This is going to be awesome",
                Departing = DateTime.Now.AddDays(1).AddHours(-5),
                Passengers = GetBoardingPassengers(context),
                SpecialRequests = new List<WaypointRequest>
                {
                    new WaypointRequest{Type = WaypointRequestType.Catering, Description = "Make me an Omlete", Notes = "Bacon!!"}
                }
            };

            var entityList = new List<Waypoint>
            {
                wp1
            };

            return entityList;
        }

        private static List<WaypointPassenger> GetBoardingPassengers(DataContext context)
        {
            return context.Set<Passenger>().Take(() => 5).AsEnumerable().Select(x => new WaypointPassenger
            {
                PassengerId = x.Id,
                PassengerType = new Random().Next(199) % 2 == 1 ? WaypointPassengerType.Boarding : WaypointPassengerType.Departing
            }).ToList();
        }
    }
}