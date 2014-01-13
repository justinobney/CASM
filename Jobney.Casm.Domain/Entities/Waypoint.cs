using System;
using System.Collections.Generic;
using tcdev.Core.Domain;

namespace Jobney.Casm.Domain.Entities
{
    public class Waypoint : EntityBase
    {
        public int Order { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Airport { get; set; }
        public string Fbo { get; set; }
        public DateTime? Departing { get; set; }
        public DateTime? Arriving { get; set; }
        public DateTime? Appointment { get; set; }
        public string AppointmentLocation { get; set; }
        public string Notes { get; set; }

        public ICollection<WaypointRequest> SpecialRequests { get; set; }
        public ICollection<WaypointPassenger> Passengers { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}