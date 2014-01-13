using tcdev.Core.Domain;

namespace Jobney.Casm.Domain.Entities
{
    public class WaypointPassenger : EntityBase
    {
        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public int TypeId { get; set; }
        public WaypointPassengerType Type { get; set; }
    }
}