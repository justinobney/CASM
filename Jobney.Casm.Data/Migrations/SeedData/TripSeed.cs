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
                Airplane = new Airplane{Name = "SkyThunder", CallSign = "1337"},
                Name = "Justin's Fancy Trip",
                RequestedBy = "Justin Obney",
                Waypoints = waypoints
            };
            context.Set<Trip>().AddOrUpdate(trip => trip.Name, thisTrip);
            context.SaveChanges();
        }

        private static List<Waypoint> GetWaypoints(DataContext context)
        {
            var wp1 = new Waypoint
            {
                Airport = "KBTR",
                Appointment = DateTime.Now.AddDays(1),
                AppointmentLocation = "Go to the bar",
                Arriving = null,
                BoardingPassengers = GetBoardingPassengers(context),
                DepartingPassengers = GetBoardingPassengers(context),
                Departing = DateTime.Now.AddDays(1).AddHours(-5),
                City = "Baton Rouge",
                State = "LA",
                Zip = "70817",
                Fbo = "Willie's FBO",
                Notes = "This is going to be awesome"
            };

            var entityList = new List<Waypoint>
            {
                wp1
            };

            return entityList;
        }

        private static List<WaypointPassenger> GetBoardingPassengers(DataContext context)
        {
            return context.Set<Passenger>().Take(() => 5).Select(x => new WaypointPassenger
            {
                PassengerId = x.Id
            }).ToList();
        }
    }
}