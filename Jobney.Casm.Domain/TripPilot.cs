using System.Collections.Generic;
using Jobney.Core.Domain;

namespace Jobney.Casm.Domain
{
    public class TripPilot:Entity
    {
        public int TripId { get; set; }
        public int PilotId { get; set; }
        public virtual Pilot Pilot { get; set; }
        public string RequestedBy { get; set; }
        public string ScheduledBy { get; set; }
        public List<Waypoint> Waypoints { get; set; }
    }
}