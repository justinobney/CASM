using System.Collections.Generic;
using tcdev.Core.Domain;

namespace Jobney.Casm.Domain.Entities
{
    public class Trip : EntityBase
    {
        public string Name { get; set; }
        public string RequestedBy { get; set; }
        public string ScheduledBy { get; set; }

        public int StatusId { get; set; }
        public TripStatus Status { get; set; }

        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public ICollection<WaypointPassenger> Passengers { get; set; }
        public ICollection<Pilot> Pilots { get; set; }
        public ICollection<Waypoint> Waypoints { get; set; }
    }
}