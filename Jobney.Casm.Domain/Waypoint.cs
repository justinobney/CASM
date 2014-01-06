using System;
using System.Collections.Generic;
using Jobney.Core.Domain;

namespace Jobney.Casm.Domain
{
    public class Waypoint : Entity
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
        public List<WaypointPassenger> Passengers { get; set; }
        public List<WaypointRequest> SpecialRequests { get; set; }
    }
}